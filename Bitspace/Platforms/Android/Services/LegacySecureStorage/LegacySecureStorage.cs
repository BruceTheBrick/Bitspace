using System.Security.Cryptography;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Security;
using Android.Security.Keystore;
using Java.Security;
using Javax.Crypto;
using Javax.Crypto.Spec;
using System.Text;
using Bitespace.Core;
using CipherMode = Javax.Crypto.CipherMode;

namespace Bitspace.Platforms.Droid.Services;

public class AndroidKeyStore
{
    private const string AndroidKeyStoreConstant = "AndroidKeyStore"; // this is an Android const value
    private const string AesAlgorithm = "AES";
    private const string CipherTransformationAsymmetric = "RSA/ECB/PKCS1Padding";
    private const string CipherTransformationSymmetric = "AES/GCM/NoPadding";
    private const string PrefsMasterKey = "SecureStorageKey";
    private const int InitializationVectorLen = 12; // Android supports an IV of 12 for AES/GCM

    private const string UseSymmetricPreferenceKey = "essentials_use_symmetric";
    private readonly Context _appContext;
    private readonly string _alias;
    private readonly bool _alwaysUseAsymmetricKey;

    private readonly KeyStore _keyStore;
    private bool _useSymmetric;
    internal AndroidKeyStore(Context context, string keystoreAlias, bool alwaysUseAsymmetricKeyStorage)
    {
        _alwaysUseAsymmetricKey = alwaysUseAsymmetricKeyStorage;
        _appContext = context;
        _alias = keystoreAlias;

        _keyStore = KeyStore.GetInstance(AndroidKeyStoreConstant);
        _keyStore.Load(null);
    }


    private ISecretKey GetKey()
    {
        // check to see if we need to get our key from past-versions or newer versions.
        // we want to use symmetric if we are >= 23, or we didn't set it previously.
        var hasApiLevel = Build.VERSION.SdkInt >= BuildVersionCodes.M;

        _useSymmetric = Preferences.Get(UseSymmetricPreferenceKey, hasApiLevel, _alias);

        // If >= API 23 we can use the KeyStore's symmetric key
        if (_useSymmetric && !_alwaysUseAsymmetricKey)
        {
            return GetSymmetricKey();
        }

        // NOTE: KeyStore in < API 23 can only store asymmetric keys
        // specifically, only RSA/ECB/PKCS1Padding
        // So we will wrap our symmetric AES key we just generated
        // with this and save the encrypted/wrapped key out to
        // preferences for future use.
        // ECB should be fine in this case as the AES key should be
        // contained in one block.

        // Get the asymmetric key pair
        var keyPair = GetAsymmetricKeyPair();
        var existingKeyStr = Preferences.Get(PrefsMasterKey, null, _alias);
        if (!string.IsNullOrEmpty(existingKeyStr))
        {
            try
            {
                var wrappedKey = Convert.FromBase64String(existingKeyStr);

                var unwrappedKey = UnwrapKey(wrappedKey, keyPair.Private);
                var kp = unwrappedKey.JavaCast<ISecretKey>();

                return kp;
            }
            catch (InvalidKeyException ikEx)
            {
                System.Diagnostics.Debug.WriteLine($"Unable to unwrap key: Invalid Key. This may be caused by system backup or upgrades. All secure storage items will now be removed. {ikEx.Message}");
            }
            catch (IllegalBlockSizeException ibsEx)
            {
                System.Diagnostics.Debug.WriteLine($"Unable to unwrap key: Illegal Block Size. This may be caused by system backup or upgrades. All secure storage items will now be removed. {ibsEx.Message}");
            }
            catch (BadPaddingException paddingEx)
            {
                System.Diagnostics.Debug.WriteLine($"Unable to unwrap key: Bad Padding. This may be caused by system backup or upgrades. All secure storage items will now be removed. {paddingEx.Message}");
            }

            LegacySecureStorageImpl.RemoveAll();
        }

        var keyGenerator = KeyGenerator.GetInstance(AesAlgorithm);
        var defSymmetricKey = keyGenerator.GenerateKey();

        var newWrappedKey = WrapKey(defSymmetricKey, keyPair.Public);

        Preferences.Set(PrefsMasterKey, Convert.ToBase64String(newWrappedKey), _alias);

        return defSymmetricKey;
    }

    // API 23+ Only
#pragma warning disable CA1416
    private ISecretKey GetSymmetricKey()
    {
        Preferences.Set(UseSymmetricPreferenceKey, true, _alias);

        var existingKey = _keyStore.GetKey(_alias, null);

        if (existingKey != null)
        {
            var existingSecretKey = existingKey.JavaCast<ISecretKey>();
            return existingSecretKey;
        }

        var keyGenerator = KeyGenerator.GetInstance(KeyProperties.KeyAlgorithmAes, AndroidKeyStoreConstant);
        var builder = new KeyGenParameterSpec.Builder(_alias, KeyStorePurpose.Encrypt | KeyStorePurpose.Decrypt)
            .SetBlockModes(KeyProperties.BlockModeGcm)
            .SetEncryptionPaddings(KeyProperties.EncryptionPaddingNone)
            .SetRandomizedEncryptionRequired(false);

        keyGenerator.Init(builder.Build());
        return keyGenerator.GenerateKey();
    }
#pragma warning restore CA1416

    private KeyPair GetAsymmetricKeyPair()
    {
        // set that we generated keys on pre-m device.
        Preferences.Set(UseSymmetricPreferenceKey, false, _alias);

        var asymmetricAlias = $"{_alias}.asymmetric";

        var privateKey = _keyStore.GetKey(asymmetricAlias, null)?.JavaCast<IPrivateKey>();
        var publicKey = _keyStore.GetCertificate(asymmetricAlias)?.PublicKey;

        // Return the existing key if found
        if (privateKey != null && publicKey != null)
        {
            return new KeyPair(publicKey, privateKey);
        }

        var originalLocale = Java.Util.Locale.Default;
        try
        {
            // Force to english for known bug in date parsing:
            // https://issuetracker.google.com/issues/37095309
            SetLocale(Java.Util.Locale.English);

            // Otherwise we create a new key
#pragma warning disable CA1416
            var generator = KeyPairGenerator.GetInstance(KeyProperties.KeyAlgorithmRsa, AndroidKeyStoreConstant);
#pragma warning restore CA1416

            var end = DateTime.UtcNow.AddYears(20);
            var startDate = new Java.Util.Date();
#pragma warning disable CS0618 // Type or member is obsolete
            var endDate = new Java.Util.Date(end.Year, end.Month, end.Day);
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618
            var builder = new KeyPairGeneratorSpec.Builder(Platform.AppContext)
                .SetAlias(asymmetricAlias)
                .SetSerialNumber(Java.Math.BigInteger.One)
                .SetSubject(new Javax.Security.Auth.X500.X500Principal($"CN={asymmetricAlias} CA Certificate"))
                .SetStartDate(startDate)
                .SetEndDate(endDate);

            generator.Initialize(builder.Build());
#pragma warning restore CS0618

            return generator.GenerateKeyPair();
        }
        finally
        {
            SetLocale(originalLocale);
        }
    }

    private byte[] WrapKey(IKey keyToWrap, IKey withKey)
    {
        var cipher = Cipher.GetInstance(CipherTransformationAsymmetric);
        cipher.Init(CipherMode.WrapMode, withKey);
        return cipher.Wrap(keyToWrap);
    }

#pragma warning disable CA1416
    private IKey UnwrapKey(byte[] wrappedData, IKey withKey)
    {
        var cipher = Cipher.GetInstance(CipherTransformationAsymmetric);
        cipher.Init(CipherMode.UnwrapMode, withKey);
        var unwrapped = cipher.Unwrap(wrappedData, KeyProperties.KeyAlgorithmAes, KeyType.SecretKey);
        return unwrapped;
    }
#pragma warning restore CA1416

    public string Decrypt(byte[] data)
    {
        if (data.Length < InitializationVectorLen)
        {
            return null;
        }

        var key = GetKey();

        // IV will be the first 16 bytes of the encrypted data
        var iv = new byte[InitializationVectorLen];
        Buffer.BlockCopy(data, 0, iv, 0, InitializationVectorLen);

        Cipher cipher;

        // Attempt to use GCMParameterSpec by default
        try
        {
            cipher = Cipher.GetInstance(CipherTransformationSymmetric);
            cipher.Init(CipherMode.DecryptMode, key, new GCMParameterSpec(128, iv));
        }
        catch (InvalidAlgorithmParameterException)
        {
            // If we encounter this error, it's likely an old bouncycastle provider version
            // is being used which does not recognize GCMParameterSpec, but should work
            // with IvParameterSpec, however we only do this as a last effort since other
            // implementations will error if you use IvParameterSpec when GCMParameterSpec
            // is recognized and expected.
            cipher = Cipher.GetInstance(CipherTransformationSymmetric);
            cipher.Init(CipherMode.DecryptMode, key, new IvParameterSpec(iv));
        }

        // Decrypt starting after the first 16 bytes from the IV
        var decryptedData = cipher.DoFinal(data, InitializationVectorLen, data.Length - InitializationVectorLen);

        return Encoding.UTF8.GetString(decryptedData);
    }

    internal void SetLocale(Java.Util.Locale locale)
    {
        Java.Util.Locale.Default = locale;
        var resources = _appContext.Resources;
        var config = resources.Configuration;

        if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
        {
            config.SetLocale(locale);
        }
        else
#pragma warning disable CS0618 // Type or member is obsolete
        {
            config.Locale = locale;
        }
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618 // Type or member is obsolete
        resources.UpdateConfiguration(config, resources.DisplayMetrics);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
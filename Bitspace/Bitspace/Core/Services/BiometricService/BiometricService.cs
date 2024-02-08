using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public class BiometricService : IBiometricService
{
    public async Task<AuthenticationType> BiometricType()
    {
        // return await CrossFingerprint.Current.GetAuthenticationTypeAsync();
        return new AuthenticationType();
    }

    public async Task<bool> HasBiometrics()
    {
        // var biometricAuthAvailable = await CrossFingerprint.Current.GetAvailabilityAsync();
        // return biometricAuthAvailable == FingerprintAvailability.Available;
        return false;
    }

    public async Task<FingerprintAuthenticationResult> Authenticate(string title, string message)
    {
        // var authenticationRequestConfig = new AuthenticationRequestConfiguration(title, message);
        // return await CrossFingerprint.Current.AuthenticateAsync(authenticationRequestConfig);
        return new FingerprintAuthenticationResult();
    }
}
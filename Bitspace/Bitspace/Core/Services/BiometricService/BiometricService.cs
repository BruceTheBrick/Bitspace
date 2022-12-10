using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace Bitspace.Core
{
    [ExcludeFromCodeCoverage]
    public class BiometricService : IBiometricService
    {
        public async Task<AuthenticationType> BiometricType()
        {
            return await CrossFingerprint.Current.GetAuthenticationTypeAsync();
        }

        public async Task<bool> HasBiometrics()
        {
            var biometricAuthAvailable = await CrossFingerprint.Current.GetAvailabilityAsync();
            return biometricAuthAvailable == FingerprintAvailability.Available;
        }

        public async Task<FingerprintAuthenticationResult> Authenticate(string title, string message)
        {
            var authenticationRequestConfig = new AuthenticationRequestConfiguration(title, message);
            return await CrossFingerprint.Current.AuthenticateAsync(authenticationRequestConfig);
        }
    }
}
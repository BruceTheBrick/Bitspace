using System.Threading.Tasks;
using Bitspace.Services.BiometricService.Models;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace Bitspace.Services.BiometricService;

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
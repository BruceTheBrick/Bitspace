using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public class BiometricService : IBiometricService
{
    public Task<AuthenticationType> BiometricType()
    {
        // return await CrossFingerprint.Current.GetAuthenticationTypeAsync();
        return Task.FromResult(new AuthenticationType());
    }

    public Task<bool> HasBiometrics()
    {
        // var biometricAuthAvailable = await CrossFingerprint.Current.GetAvailabilityAsync();
        // return biometricAuthAvailable == FingerprintAvailability.Available;
        return Task.FromResult(false);
    }

    public Task<FingerprintAuthenticationResult> Authenticate(string title, string message)
    {
        // var authenticationRequestConfig = new AuthenticationRequestConfiguration(title, message);
        // return await CrossFingerprint.Current.AuthenticateAsync(authenticationRequestConfig);
        return Task.FromResult(new FingerprintAuthenticationResult());
    }
}
using System.Diagnostics.CodeAnalysis;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public class BiometricService : IBiometricService
{
    public async Task<BiometricType> BiometricType()
    {
        var authenticationType = await CrossFingerprint.Current.GetAuthenticationTypeAsync();
        return ToBiometricType(authenticationType);
    }

    public async Task<bool> HasBiometrics()
    {
        var type = await BiometricType();
        return type != Core.BiometricType.None;
    }

    public async Task<AuthenticationResultModel> Authenticate(string title, string message)
    {
        var authenticationRequestConfig = new AuthenticationRequestConfiguration(title, message);
        var result = await CrossFingerprint.Current.AuthenticateAsync(authenticationRequestConfig);
        return new AuthenticationResultModel(result);
    }

    private BiometricType ToBiometricType(AuthenticationType type)
    {
        return type switch
        {
            AuthenticationType.Face => Core.BiometricType.Face,
            AuthenticationType.Fingerprint => Core.BiometricType.Fingerprint,
            _ => Core.BiometricType.None
        };
    }
}
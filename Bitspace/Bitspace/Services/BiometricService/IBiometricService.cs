using System.Threading.Tasks;
using Bitspace.Services.BiometricService.Models;
using Plugin.Fingerprint.Abstractions;

namespace Bitspace.Services.BiometricService;

public interface IBiometricService
{
    public Task<AuthenticationType> BiometricType();

    public Task<bool> HasBiometrics();

    public Task<FingerprintAuthenticationResult> Authenticate(string title = "Authenticate", string message = "Please authenticate to continue.");
}
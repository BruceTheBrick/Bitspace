using System.Threading.Tasks;
using Plugin.Fingerprint.Abstractions;

namespace Bitspace.Core
{
    public interface IBiometricService
    {
        public Task<AuthenticationType> BiometricType();

        public Task<bool> HasBiometrics();

        public Task<FingerprintAuthenticationResult> Authenticate(string title = "Authenticate", string message = "Please authenticate to continue.");
    }
}
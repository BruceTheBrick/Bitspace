namespace Bitspace.Core;

public interface IBiometricService
{
    public Task<BiometricType> BiometricType();

    public Task<bool> HasBiometrics();

    public Task<AuthenticationResultModel> Authenticate(
        string title = "Authenticate",
        string message = "Please authenticate to continue.");
}
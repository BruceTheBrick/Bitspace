namespace Bitspace.Services.BiometricService.Models;

public class AuthenticationResult
{
    public AuthenticationResult()
    {
    }

    public AuthenticationResult(bool success, string errorMessage)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public bool Success { get; }
    public string ErrorMessage { get; }
}
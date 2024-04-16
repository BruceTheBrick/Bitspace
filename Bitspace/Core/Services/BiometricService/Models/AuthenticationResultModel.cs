using System.Diagnostics.CodeAnalysis;
using Plugin.Fingerprint.Abstractions;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public class AuthenticationResultModel
{
    public AuthenticationResultModel()
    {
    }

    public AuthenticationResultModel(bool success, string errorMessage)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public AuthenticationResultModel(FingerprintAuthenticationResult result)
    {
        Success = result.Authenticated;
        ErrorMessage = result.ErrorMessage;
    }

    public bool Success { get; }
    public string ErrorMessage { get; }
}
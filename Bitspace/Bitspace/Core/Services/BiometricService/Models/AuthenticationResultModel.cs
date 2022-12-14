﻿using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core
{
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

        public bool Success { get; }
        public string ErrorMessage { get; }
    }
}
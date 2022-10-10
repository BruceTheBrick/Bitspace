using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class Accessibility
    {
        public static AccessibilityImplementation Current { get; set; }
    }
}
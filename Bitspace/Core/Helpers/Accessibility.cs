using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public static class Accessibility
{
    public static AccessibilityImplementation Current { get; set; }
}
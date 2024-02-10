using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public static class EffectHelper
{
    public const string EffectResolutionGroupingName = "BitspaceEffects";

    public static string GetLocalName<T>()
    {
        return $"{EffectResolutionGroupingName}.{typeof(T).Name}";
    }
}
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public static class ResourceHelper
{
    public static T GetResource<T>(string resourceName)
    {
        try
        {
            if (!Application.Current!.Resources.TryGetValue(resourceName, out var resource))
            {
                return default;
            }

            if (resource is T value)
            {
                return value;
            }

            return default;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return default;
        }
    }
}
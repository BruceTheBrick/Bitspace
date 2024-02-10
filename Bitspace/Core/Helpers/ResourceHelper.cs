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
            var resource = Application.Current.Resources[resourceName];
            if (resource is T)
            {
                return (T)resource;
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
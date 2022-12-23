using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace Bitspace.Core
{
    [ExcludeFromCodeCoverage]
    public static class ResourceHelper
    {
        public static T GetResource<T>(string resourceName)
        {
            try
            {
                var resource = Application.Current.Resources[resourceName];
                if (resource is T tResource)
                {
                    return tResource;
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
}
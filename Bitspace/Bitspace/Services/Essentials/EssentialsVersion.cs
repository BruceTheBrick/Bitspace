using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Services
{
    [ExcludeFromCodeCoverage]
    public class EssentialsVersion : IEssentialsVersion
    {
        public string CurrentVersion()
        {
            return Xamarin.Essentials.VersionTracking.CurrentVersion;
        }

        public string CurrentBuildNumber()
        {
            return Xamarin.Essentials.VersionTracking.CurrentBuild;
        }
    }
}
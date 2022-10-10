using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Services.Essentials
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
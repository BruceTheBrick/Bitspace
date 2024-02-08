using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public class EssentialsVersion : IEssentialsVersion
{
    public string CurrentVersion()
    {
        return VersionTracking.CurrentVersion;
    }

    public string CurrentBuildNumber()
    {
        return VersionTracking.CurrentBuild;
    }
}
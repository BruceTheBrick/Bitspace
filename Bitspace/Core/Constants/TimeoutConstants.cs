using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "TimeoutConstants need static scoping")]
[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "TimeoutConstants can have different casing")]
public static class TimeoutConstants
{
    public static int REMOTECONFIG_MIN_FETCH_INTERVAL = 10;
    public static int REMOTECONFIG_TIMEOUT = 10;
}
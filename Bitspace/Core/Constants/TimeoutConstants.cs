using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "TimeoutConstants need static scoping")]
[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "TimeoutConstants can have different casing")]
public static class TimeoutConstants
{
    public const int RemoteConfigMinimumFetchInterval = 10;
    public const int RemoteConfigTimeout = 10;
}
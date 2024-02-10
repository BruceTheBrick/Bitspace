using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "Contstants can contain underscores.")]
[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Constants can have inconsistent naming.")]
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Constants should not be private.")]
public static class RemoteConfigConstants
{
    public static string Homepage_Weather = nameof(Homepage_Weather);
    public static string Homepage_Martini = nameof(Homepage_Martini);
    public static string Homepage_Playground = nameof(Homepage_Playground);
}
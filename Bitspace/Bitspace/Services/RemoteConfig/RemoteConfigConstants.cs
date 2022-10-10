using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Services
{
    [ExcludeFromCodeCoverage]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "Contstants can contain underscores.")]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Constants can have inconsistent naming.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Constants should not be private.")]
    public static class RemoteConfigConstants
    {
        public static string HOMEPAGE_MENUITEM_WEATHER = nameof(HOMEPAGE_MENUITEM_WEATHER);
        public static string HOMEPAGE_MENUITEM_MARTINI = nameof(HOMEPAGE_MENUITEM_MARTINI);
    }
}
using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Services.FirebaseRemoteConfig
{
#pragma warning disable SA1404
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private")]
#pragma warning restore SA1404
    public class RemoteConfigConstants
    {
        public static string MAINPAGE_MENUITEM_WEATHER = nameof(MAINPAGE_MENUITEM_WEATHER);
        public static string MAINPAGE_MENUITEM_BARCODE_SCANNER = nameof(MAINPAGE_MENUITEM_BARCODE_SCANNER);
    }
}

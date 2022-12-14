using System.Diagnostics.CodeAnalysis;
using Bitspace.Features;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

namespace Bitspace.Core
{
    [ExcludeFromCodeCoverage]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "NavigationConstants need static scoping")]
    public static class NavigationConstants
    {
        #region Navigation Destinations

        public const string Homepage = $"/{nameof(NavigationPage)}/{nameof(HomePage)}";

        #endregion

        #region Global

        public static string Message = nameof(Message);
        public static string Icon = nameof(Icon);
        public static string Position = nameof(Position);

        #endregion

        #region ConnectFour

        public static string Winner = nameof(Winner);
        public static string Reset = nameof(Reset);

        #endregion

    }
}
using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core
{
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "NavigationConstants need static scoping")]
    public static class NavigationConstants
    {
        public static string Message = nameof(Message);
        public static string Icon = nameof(Icon);
        public static string Position = nameof(Position);
    }
}
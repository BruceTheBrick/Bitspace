using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "NavigationConstants need static scoping")]
public static class NavigationConstants
{
    public const string Homepage = $"/{nameof(NavigationPage)}/{nameof(HomePage)}";
    public const string Message = nameof(Message);
    public const string Icon = nameof(Icon);
    public const string Position = nameof(Position);
    public const string Winner = nameof(Winner);
    public const string Reset = nameof(Reset);
}
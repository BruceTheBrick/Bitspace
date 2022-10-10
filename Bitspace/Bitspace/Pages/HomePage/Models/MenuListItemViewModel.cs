using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Pages
{
    [ExcludeFromCodeCoverage]
    public class MenuListItemViewModel
    {
        public MenuListItemViewModel()
        {
        }

        public MenuListItemViewModel(string text, string icon, string actionIcon, string navigationConstant)
        {
            Text = text;
            Icon = icon;
            ActionIcon = actionIcon;
            NavigationConstant = navigationConstant;
        }

        public string Text { get; set; }
        public string Icon { get; set; }
        public string ActionIcon { get; set; }
        public string NavigationConstant { get; set; }
    }
}
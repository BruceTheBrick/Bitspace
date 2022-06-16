using Xamarin.Forms;

namespace Bitspace.Pages.Mainpage.Controls
{
    public partial class MenuItemTile
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(MenuItemTile),
            string.Empty,
            BindingMode.TwoWay);

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(string),
            typeof(MenuItemTile),
            string.Empty,
            BindingMode.TwoWay);
        public MenuItemTile()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
    }
}
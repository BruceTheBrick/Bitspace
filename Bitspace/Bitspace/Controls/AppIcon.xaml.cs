using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bitspace.Controls;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AppIcon
{
    public AppIcon()
    {
        InitializeComponent();
    }

    public Color Color { get; set; }
}
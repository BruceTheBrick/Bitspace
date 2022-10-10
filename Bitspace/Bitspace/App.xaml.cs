using System.Diagnostics.CodeAnalysis;
using Bitspace.Features;
using DLToolkit.Forms.Controls;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace Bitspace
{
    [ExcludeFromCodeCoverage]
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            FlowListView.Init();
            Sharpnado.MaterialFrame.Initializer.Initialize(false, true);
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(HomePage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           _ = new PlatformInitializer(containerRegistry);
        }
    }
}

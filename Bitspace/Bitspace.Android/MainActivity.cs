using Android.App;
using Android.Content.PM;
using Android.OS;
using Bitspace.Helpers;
using CarouselView.FormsPlugin.Droid;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Plugin.Fingerprint;

namespace Bitspace.Droid
{
    [Activity(Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.FontScale | ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            InitNugets(savedInstanceState);
            LoadApplication(new App(new PlatformInitializer()));
            TrackFontSize();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void TrackFontSize()
        {
            var size = Resources?.Configuration?.FontScale;
            if (size != null)
            {
                
            }
        }
        
        public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
        }

        private void InitNugets(Bundle savedInstanceState)
        {
            AndroidX.Core.SplashScreen.SplashScreen.InstallSplashScreen(this);
            Rg.Plugins.Popup.Popup.Init(this);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            CachedImageRenderer.Init(enableFastRenderer: true);
            SvgCachedImage.Init();
            _ = typeof(SvgCachedImage);
            CarouselViewRenderer.Init();
            CrossFingerprint.SetCurrentActivityResolver(() => Xamarin.Essentials.Platform.CurrentActivity);
        }

        private void InitHelpers()
        {
            Accessibility.Current = new Helpers.AccessibilityImplementation();
        }
    }
}


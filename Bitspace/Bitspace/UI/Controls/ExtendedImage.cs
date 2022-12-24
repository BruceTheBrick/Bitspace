using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Bitspace.Resources;
using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;
using ResourceHelper = Bitspace.Core.ResourceHelper;

namespace Bitspace.UI
{
    [ExcludeFromCodeCoverage]
    public class ExtendedImage : SvgCachedImage
    {
        public static new readonly BindableProperty SourceProperty = BindableProperty.Create(
            nameof(Source),
            typeof(string),
            typeof(ExtendedImage),
            string.Empty,
            BindingMode.TwoWay,
            propertyChanged: OnSourceUpdated);

        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
            nameof(TintColor),
            typeof(ColorRef),
            typeof(ExtendedImage),
            // ResourceHelper.GetResource<ColorRef>("IconPrimaryColor"),
            propertyChanged: TintColorUpdated);

        public static readonly BindableProperty ExtensionProperty = BindableProperty.Create(
            nameof(Extension),
            typeof(string),
            typeof(ExtendedImage),
            "svg");

        public ExtendedImage()
        {
            TintColor = ResourceHelper.GetResource<ColorRef>("IconPrimaryColor");
        }

        private const string SourcePrefix = "resource://Bitspace.Resources.Images.";
        public new string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public ColorRef TintColor
        {
            get => (ColorRef)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        public string Extension
        {
            get => (string)GetValue(ExtensionProperty);
            set => SetValue(ExtensionProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TintColorProperty.PropertyName ||
                propertyName == IsEnabledProperty.PropertyName)
            {
                AddTintEffect();
            }
        }

        private static void OnSourceUpdated(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is not ExtendedImage image)
            {
                return;
            }

            var imageSource = newvalue as string;
            if (string.IsNullOrWhiteSpace(imageSource))
            {
                return;
            }

            var source = image.FormatSource(imageSource);
            image.SetBaseSource(source);
        }

        private static void TintColorUpdated(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is not ExtendedImage view)
            {
                return;
            }

            view.AddTintEffect();
        }

        private string FormatSource(string input)
        {
            return $"{SourcePrefix}{input}.{Extension}";
        }

        private void SetBaseSource(string source)
        {
            ((CachedImage)this).Source = source;
        }

        private void AddTintEffect()
        {
            RemoveTintEffect();
            var effect = new ImageTintEffect { TintColor = TintColor };
            Effects.Add(effect);
        }

        private void RemoveTintEffect()
        {
            var effect = Effects.FirstOrDefault(x => x is ImageTintEffect);
            if (effect != null)
            {
                Effects.Remove(effect);
            }
        }
    }
}

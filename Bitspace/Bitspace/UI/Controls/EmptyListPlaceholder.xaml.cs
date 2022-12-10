using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace Bitspace.UI
{
    [ExcludeFromCodeCoverage]
    public partial class EmptyListPlaceholder
    {
        private readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(string),
            typeof(EmptyListPlaceholder),
            string.Empty,
            BindingMode.TwoWay);

        private readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(EmptyListPlaceholder),
            string.Empty,
            BindingMode.TwoWay);

        private readonly BindableProperty SubtitleProperty = BindableProperty.Create(
            nameof(Subtitle),
            typeof(string),
            typeof(EmptyListPlaceholder),
            string.Empty,
            BindingMode.TwoWay);

        public EmptyListPlaceholder()
        {
            InitializeComponent();
        }

        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Subtitle
        {
            get => (string)GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }
    }
}
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace Bitspace.Controls
{
    [ExcludeFromCodeCoverage]
    public partial class PillList
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IList<Pill>),
            typeof(PillList),
            null,
            BindingMode.TwoWay);

        public PillList()
        {
            InitializeComponent();
        }

        public IList<Pill> ItemsSource
        {
            get => (IList<Pill>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
    }
}
﻿using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bitspace.Controls
{
    [ExcludeFromCodeCoverage]
    public partial class PillList
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(ObservableCollection<PillViewModel>),
            typeof(PillList),
            default,
            BindingMode.TwoWay);

        public static readonly BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
            nameof(ItemSelectedCommand),
            typeof(ICommand),
            typeof(PillList));

        public PillList()
        {
            InitializeComponent();
        }

        public ObservableCollection<PillViewModel> ItemsSource
        {
            get => (ObservableCollection<PillViewModel>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public ICommand ItemSelectedCommand
        {
            get => (ICommand)GetValue(ItemSelectedCommandProperty);
            set => SetValue(ItemSelectedCommandProperty, value);
        }
    }
}
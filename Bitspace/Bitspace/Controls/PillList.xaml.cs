﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
            nameof(IsLoading),
            typeof(bool),
            typeof(PillList),
            propertyChanged: OnIsLoadingChanged);

        private List<PillViewModel> _skeletonPills;
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

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        private static void OnIsLoadingChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(bindable is PillList view) || newvalue == null)
            {
                return;
            }

            if ((bool)newvalue)
            {
                view.AddSkeletonPills();
            }
            else
            {
                view.ClearSkeletonPills();
            }
        }

        private void AddSkeletonPills()
        {
            _skeletonPills = new List<PillViewModel>
            {
                new (), new (), new (), new (),
            };
        }

        private void ClearSkeletonPills()
        {
            _skeletonPills.Clear();
        }
    }
}
using System.Collections.Generic;
using System.Windows.Input;
using Bitspace.Core.Models;
using Xamarin.Forms;

namespace Bitspace.UI
{
    public class AccessibilityStackLayout : StackLayout
    {
        public static readonly BindableProperty AccessibilityIncrementCommandProperty = BindableProperty.Create(
            nameof(AccessibilityIncrementCommand),
            typeof(ICommand),
            typeof(AccessibilityStackLayout));

        public static readonly BindableProperty AccessibilityDecrementCommandProperty = BindableProperty.Create(
            nameof(AccessibilityDecrementCommand),
            typeof(ICommand),
            typeof(AccessibilityStackLayout));

        public static readonly BindableProperty AccessibilityActionCommandListProperty = BindableProperty.Create(
            nameof(AccessibilityActionCommandList),
            typeof(IList<AccessibilityActionCommand>),
            typeof(AccessibilityStackLayout));

        public AccessibilityStackLayout()
        {
            AutomationProperties.SetIsInAccessibleTree(this, true);
        }

        public ICommand AccessibilityIncrementCommand
        {
            get => (ICommand)GetValue(AccessibilityIncrementCommandProperty);
            set => SetValue(AccessibilityIncrementCommandProperty, value);
        }

        public ICommand AccessibilityDecrementCommand
        {
            get => (ICommand)GetValue(AccessibilityDecrementCommandProperty);
            set => SetValue(AccessibilityDecrementCommandProperty, value);
        }

        public IList<AccessibilityActionCommand> AccessibilityActionCommandList
        {
            get => (IList<AccessibilityActionCommand>)GetValue(AccessibilityActionCommandListProperty);
            set => SetValue(AccessibilityActionCommandListProperty, value);
        }
    }
}
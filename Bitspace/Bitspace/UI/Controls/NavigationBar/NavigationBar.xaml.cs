using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bitspace.UI
{
    [ExcludeFromCodeCoverage]
    public partial class NavigationBar
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(NavigationBar));

        public static readonly BindableProperty LeftActionTypeProperty = BindableProperty.Create(
            nameof(LeftActionType),
            typeof(ActionTypeEnum),
            typeof(NavigationBar),
            propertyChanged: LeftActionTypeUpdated);

        public static readonly BindableProperty LeftActionCommandProperty = BindableProperty.Create(
            nameof(LeftActionCommand),
            typeof(ICommand),
            typeof(NavigationBar));

        public static readonly BindableProperty RightActionTypeProperty = BindableProperty.Create(
            nameof(RightActionType),
            typeof(ActionTypeEnum),
            typeof(NavigationBar),
            propertyChanged: RightActionTypeUpdated);

        public static readonly BindableProperty RightActionCommandProperty = BindableProperty.Create(
            nameof(RightActionCommand),
            typeof(ICommand),
            typeof(NavigationBar));

        public NavigationBar()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public ActionTypeEnum LeftActionType
        {
            get => (ActionTypeEnum)GetValue(LeftActionTypeProperty);
            set => SetValue(LeftActionTypeProperty, value);
        }

        public ICommand LeftActionCommand
        {
            get => (ICommand)GetValue(LeftActionCommandProperty);
            set => SetValue(LeftActionCommandProperty, value);
        }

        public ActionTypeEnum RightActionType
        {
            get => (ActionTypeEnum)GetValue(RightActionTypeProperty);
            set => SetValue(RightActionTypeProperty, value);
        }

        public ICommand RightActionCommand
        {
            get => (ICommand)GetValue(RightActionCommandProperty);
            set => SetValue(RightActionCommandProperty, value);
        }

        public string LeftActionAccessibilityName { get; set; }
        public string LeftActionIsInAccessibleTree { get; set; }
        public string LeftActionIconSource { get; set; }
        public string LeftActionText { get; set; }

        public string RightActionAccessibilityName { get; set; }
        public string RightActionIsInAccessibleTree { get; set; }
        public string RightActionIconSource { get; set; }
        public string RightActionText { get; set; }

        private static void LeftActionTypeUpdated(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(bindable is NavigationBar view))
            {
                return;
            }

            view.UpdateLeftActionProperties();
        }

        private static void RightActionTypeUpdated(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(bindable is NavigationBar view))
            {
                return;
            }

            view.UpdateRightActionProperties();
        }

        private void UpdateActionProperties(string action)
        {
            switch (LeftActionType)
            {
                case ActionTypeEnum.Close:
                {
                    // var t = this.GetType().GetField($"{left}ActionAccessibilityName");
                    // t.SetValue();
                }
            }
        }

        private void UpdateRightActionProperties()
        {
            
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace Bitspace.UI;

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

    public static readonly BindableProperty LeftActionIsEnabledProperty = BindableProperty.Create(
        nameof(LeftActionIsEnabled),
        typeof(bool),
        typeof(NavigationBar),
        true);

    public static readonly BindableProperty LeftActionCommandProperty = BindableProperty.Create(
        nameof(LeftActionCommand),
        typeof(ICommand),
        typeof(NavigationBar));

    public static readonly BindableProperty RightActionTypeProperty = BindableProperty.Create(
        nameof(RightActionType),
        typeof(ActionTypeEnum),
        typeof(NavigationBar),
        propertyChanged: RightActionTypeUpdated);

    public static readonly BindableProperty RightActionIsEnabledProperty = BindableProperty.Create(
        nameof(RightActionIsEnabled),
        typeof(bool),
        typeof(NavigationBar),
        true);

    public static readonly BindableProperty RightActionCommandProperty = BindableProperty.Create(
        nameof(RightActionCommand),
        typeof(ICommand),
        typeof(NavigationBar));

    public NavigationBar()
    {
        InitializeComponent();
        InitSemanticOrderView();
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

    public bool LeftActionIsEnabled
    {
        get => (bool)GetValue(LeftActionIsEnabledProperty);
        set => SetValue(LeftActionIsEnabledProperty, value);
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

    public bool RightActionIsEnabled
    {
        get => (bool)GetValue(RightActionIsEnabledProperty);
        set => SetValue(RightActionIsEnabledProperty, value);
    }

    public ICommand RightActionCommand
    {
        get => (ICommand)GetValue(RightActionCommandProperty);
        set => SetValue(RightActionCommandProperty, value);
    }

    public string LeftActionAccessibilityName { get; set; }
    public bool LeftActionIsInAccessibleTree { get; set; }
    public string LeftActionIconSource { get; set; }
    public string LeftActionText { get; set; }

    public string RightActionAccessibilityName { get; set; }
    public bool RightActionIsInAccessibleTree { get; set; }
    public string RightActionIconSource { get; set; }
    public string RightActionText { get; set; }

    private static void LeftActionTypeUpdated(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not NavigationBar view)
        {
            return;
        }

        view.UpdateActionProperties(true);
    }

    private static void RightActionTypeUpdated(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not NavigationBar view)
        {
            return;
        }

        view.UpdateActionProperties(false);
    }

    private void UpdateActionProperties(bool isLeftAction)
    {
        var actionType = isLeftAction ? LeftActionType : RightActionType;
        switch (actionType)
        {
            case ActionTypeEnum.Close:
            {
                SetCloseProperties(isLeftAction);
                return;
            }

            case ActionTypeEnum.Back:
            {
                SetBackProperties(isLeftAction);
                return;
            }

            case ActionTypeEnum.Cancel:
            {
                SetCancelProperties(isLeftAction);
                return;
            }

            case ActionTypeEnum.Done:
            {
                SetDoneProperties(isLeftAction);
                return;
            }

            case ActionTypeEnum.Next:
            {
                SetNextProperties(isLeftAction);
                return;
            }

            case ActionTypeEnum.None:
            {
                SetNoneProperties(isLeftAction);
                return;
            }
        }
    }

    private void SetCloseProperties(bool isLeftAction)
    {
        if (isLeftAction)
        {
            LeftActionText = string.Empty;
            LeftActionIconSource = "ic_close";
            LeftActionAccessibilityName = GlobalRegister.Close;
            LeftActionIsInAccessibleTree = true;
            return;
        }

        RightActionText = string.Empty;
        RightActionIconSource = "ic_close";
        RightActionAccessibilityName = GlobalRegister.Close;
        RightActionIsInAccessibleTree = true;
    }

    private void SetBackProperties(bool isLeftAction)
    {
        if (isLeftAction)
        {
            LeftActionText = string.Empty;
            LeftActionIconSource = "ic_arrow_left";
            LeftActionAccessibilityName = GlobalRegister.Back;
            LeftActionIsInAccessibleTree = true;
            return;
        }

        RightActionText = string.Empty;
        RightActionIconSource = "ic_arrow_left";
        RightActionAccessibilityName = GlobalRegister.Back;
        RightActionIsInAccessibleTree = true;
    }

    private void SetCancelProperties(bool isLeftAction)
    {
        if (isLeftAction)
        {
            LeftActionText = GlobalRegister.Cancel;
            LeftActionIconSource = string.Empty;
            LeftActionAccessibilityName = GlobalRegister.Cancel;
            LeftActionIsInAccessibleTree = true;
            return;
        }

        RightActionText = GlobalRegister.Cancel;
        RightActionIconSource = string.Empty;
        RightActionAccessibilityName = GlobalRegister.Cancel;
        RightActionIsInAccessibleTree = true;
    }

    private void SetDoneProperties(bool isLeftAction)
    {
        if (isLeftAction)
        {
            LeftActionText = GlobalRegister.Done;
            LeftActionIconSource = string.Empty;
            LeftActionAccessibilityName = GlobalRegister.Done;
            LeftActionIsInAccessibleTree = true;
            return;
        }

        RightActionText = GlobalRegister.Done;
        RightActionIconSource = string.Empty;
        RightActionAccessibilityName = GlobalRegister.Done;
        RightActionIsInAccessibleTree = true;
    }

    private void SetNextProperties(bool isLeftAction)
    {
        if (isLeftAction)
        {
            LeftActionText = string.Empty;
            LeftActionIconSource = "ic_arrow_right";
            LeftActionAccessibilityName = GlobalRegister.Next;
            LeftActionIsInAccessibleTree = true;
            return;
        }

        RightActionText = string.Empty;
        RightActionIconSource = "ic_arrow_right";
        RightActionAccessibilityName = GlobalRegister.Next;
        RightActionIsInAccessibleTree = true;
    }

    private void SetNoneProperties(bool isLeftAction)
    {
        if (isLeftAction)
        {
            LeftActionText = string.Empty;
            LeftActionIconSource = string.Empty;
            LeftActionAccessibilityName = string.Empty;
            LeftActionIsInAccessibleTree = false;
            return;
        }

        RightActionText = string.Empty;
        RightActionIconSource = string.Empty;
        RightActionAccessibilityName = string.Empty;
        RightActionIsInAccessibleTree = false;
    }

    private void InitSemanticOrderView()
    {
        ViewOrder = new List<View> { TitleView, LeftAction, RightAction };
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bitspace.Features.Controls
{
    [ExcludeFromCodeCoverage]
    public partial class BoardButtons
    {
        public static readonly BindableProperty ColumnsProperty = BindableProperty.Create(
            nameof(Columns),
            typeof(int),
            typeof(BoardButtons),
            propertyChanged: BoardDimensionsUpdated);

        public static readonly BindableProperty RowsProperty = BindableProperty.Create(
            nameof(Rows),
            typeof(int),
            typeof(BoardButtons),
            propertyChanged: BoardDimensionsUpdated);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(BoardButtons));

        public static readonly BindableProperty BoardProperty = BindableProperty.Create(
            nameof(Board),
            typeof(IBoard),
            typeof(BoardButtons));

        public static readonly BindableProperty UpdateButtonStateProperty = BindableProperty.Create(
            nameof(UpdateButtonState),
            typeof(bool),
            typeof(BoardButtons),
            propertyChanged: UpdateButtonColors);

        public BoardButtons()
        {
            InitializeComponent();
        }

        public int Columns
        {
            get => (int)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        public int Rows
        {
            get => (int)GetValue(RowsProperty);
            set => SetValue(RowsProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public IBoard Board
        {
            get => (IBoard)GetValue(BoardProperty);
            set => SetValue(BoardProperty, value);
        }

        public bool UpdateButtonState
        {
            get => (bool)GetValue(UpdateButtonStateProperty);
            set => SetValue(UpdateButtonStateProperty, value);
        }

        private static void BoardDimensionsUpdated(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(bindable is BoardButtons view))
            {
                return;
            }

            view.CreateContent();
        }

        private static void UpdateButtonColors(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(bindable is BoardButtons view))
            {
                return;
            }

            view.UpdateContent();
        }

        private void CreateContent()
        {
            ColumnDefinitions = GetColumnDefinitions();
            RowDefinitions = GetRowDefinitions();
            for (var x = 0; x < Rows; x++)
            {
                for (var y = 0; y < Columns; y++)
                {
                    var btn = new Button
                    {
                        Command = Command,
                        CommandParameter = y,
                        Text = $"C:{y}, R:{x}",
                        BackgroundColor = GetColor(x, y),
                    };
                    SetRow(btn, x);
                    SetColumn(btn, y);
                    Children.Add(btn);
                }
            }
        }

        private void UpdateContent()
        {
            foreach (var btn in Children)
            {
                var row = GetRow(btn);
                var col = GetColumn(btn);
                btn.BackgroundColor = GetColor(row, col);
            }
        }

        private ColumnDefinitionCollection GetColumnDefinitions()
        {
            var columns = new ColumnDefinitionCollection();
            for (var i = 0; i < Columns; i++)
            {
                var definition = new ColumnDefinition { Width = GridLength.Star };
                columns.Add(definition);
            }

            return columns;
        }

        private RowDefinitionCollection GetRowDefinitions()
        {
            var rows = new RowDefinitionCollection();
            for (var i = 0; i < Rows; i++)
            {
                var definition = new RowDefinition { Height = GridLength.Star };
                rows.Add(definition);
            }

            return rows;
        }

        private Color GetColor(int row, int col)
        {
            if (Board == null)
            {
                return Color.Default;
            }

            var piece = Board.GetPiece(row, col);
            if (piece == 0)
            {
                return Color.Default;
            }

            return piece == 1
                ? Color.Blue
                : Color.Red;
        }
    }
}
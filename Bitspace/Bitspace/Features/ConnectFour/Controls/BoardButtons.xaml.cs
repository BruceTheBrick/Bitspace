using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Converters;
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

        public static readonly BindableProperty PlayerOneColorProperty = BindableProperty.Create(
            nameof(PlayerOneColor),
            typeof(Color),
            typeof(BoardButtons));

        public static readonly BindableProperty PlayerTwoColorProperty = BindableProperty.Create(
            nameof(PlayerTwoColor),
            typeof(Color),
            typeof(BoardButtons));

        public static readonly BindableProperty IsGameOverProperty = BindableProperty.Create(
            nameof(IsGameOver),
            typeof(bool),
            typeof(BoardButtons));

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

        public Color PlayerOneColor
        {
            get => (Color)GetValue(PlayerOneColorProperty);
            set => SetValue(PlayerOneColorProperty, value);
        }

        public Color PlayerTwoColor
        {
            get => (Color)GetValue(PlayerTwoColorProperty);
            set => SetValue(PlayerTwoColorProperty, value);
        }

        public bool IsGameOver
        {
            get => (bool)GetValue(IsGameOverProperty);
            set => SetValue(IsGameOverProperty, value);
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
                    CreateNewButton(x, y);
                }
            }
        }

        private void UpdateContent()
        {
            foreach (var btn in Children)
            {
                var row = GetRow(btn);
                var col = GetColumn(btn);
                var color = GetColor(row, col);
                btn.BackgroundColor = color;
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
            switch (piece)
            {
                case Piece.ONE:
                    return PlayerOneColor;
                case Piece.TWO:
                    return PlayerTwoColor;
                default:
                    return Color.Gray;
            }
        }

        private void CreateNewButton(int row, int column)
        {
            var btn = new Button
            {
                Command = Command,
                CommandParameter = column,
                BackgroundColor = GetColor(row, column),
            };
            var binding = new Binding(nameof(IsGameOver))
            {
                Converter = new InvertedBoolConverter(),
            };
            btn.SetBinding(IsEnabledProperty, binding);
            btn.SizeChanged += BtnOnSizeChanged;
            SetRow(btn, row);
            SetColumn(btn, column);
            Children.Add(btn);
        }

        private void BtnOnSizeChanged(object sender, EventArgs e)
        {
            if (!(sender is Button btn))
            {
                return;
            }

            btn.CornerRadius = (int)btn.Height / 2;
        }
    }
}
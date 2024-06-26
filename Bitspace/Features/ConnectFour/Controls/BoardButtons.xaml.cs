﻿using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace Bitspace.Features.Controls;

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

    private readonly int[][] _precomputedIndexes;

    public BoardButtons()
    {
        InitializeComponent();
        _precomputedIndexes = PrecomputedIndexes.GetRevisedPrecomputedIndexes();
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

    private static void BoardDimensionsUpdated(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not BoardButtons view)
        {
            return;
        }

        view.CreateContent();
    }

    private static void UpdateButtonColors(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not BoardButtons view)
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
            ((View)btn).BackgroundColor = color;
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
            return Colors.Chartreuse;
        }

        var piece = Board.GetPiece(row, col);
        return piece switch
        {
            Piece.One => PlayerOneColor,
            Piece.Two => PlayerTwoColor,
            _ => Colors.Chartreuse
        };
    }

    private void CreateNewButton(int row, int column)
    {
        var btn = new BaseCircleButton
        {
            Command = Command,
            CommandParameter = column,
            BackgroundColor = GetColor(row, column),
            Text = _precomputedIndexes[row][column].ToString(),
        };
        btn.SetBinding(IsEnabledProperty, new Binding(IsEnabledProperty.PropertyName));
        SetRow((BindableObject)btn, row);
        SetColumn((BindableObject)btn, column);
        Children.Add(btn);
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using Bitspace.Core;

namespace Bitspace.Features
{
    public class Board : IBoard
    {
        private const int NumWinningPieces = 4;
        private readonly Stack<KeyValuePair<int, int>> _moves;
        private Piece[,] _board;

        public Board()
        {
            Columns = 6;
            Rows = 7;
            _board = new Piece[Rows, Columns];
            _moves = new Stack<KeyValuePair<int, int>>();
        }

        public Board(int numRows = 6, int numCols = 7)
        {
            Columns = numCols;
            Rows = numRows;
            _board = new Piece[numRows, numCols];
            _moves = new Stack<KeyValuePair<int, int>>();
        }

        public int Columns { get; set; }
        public int Rows { get; set; }

        public void PlacePiece(int column, Piece piece)
        {
            if (!ColumnIsInRange(column))
            {
                return;
            }

            var rowNum = GetNextAvailableSpace(column);
            if (rowNum == -1)
            {
                return;
            }

            _board[rowNum, column] = piece;
            UpdateLastPiece(rowNum, column);
        }

        public Piece GetPiece(int row, int column)
        {
            if (!RowIsInRange(row) || !ColumnIsInRange(column))
            {
                return Piece.INVALID;
            }

            return _board[row, column];
        }

        public Piece HasWin()
        {
            for (var x = 0; x < Rows; x++)
            {
                for (var y = 0; y < Columns; y++)
                {
                    var h = Horizontal(x, y);
                    var v = Vertical(x, y);
                    var ur = DiagUpRight(x, y);
                    var dr = DiagDownRight(x, y);
                    if (h || v || ur || dr)
                    {
                        return _board[x, y];
                    }
                }
            }

            return Piece.EMPTY;
        }

        public bool IsColumnFull(int column)
        {
            if (!ColumnIsInRange(column))
            {
                return false;
            }

            return GetNextAvailableSpace(column) == -1;
        }

        public bool IsFull()
        {
            for (var i = 0; i < Columns; i++)
            {
                if (!IsColumnFull(i))
                {
                    return false;
                }
            }

            return true;
        }

        public void Undo()
        {
            if (_moves.Count == 0)
            {
                return;
            }

            var move = _moves.Pop();
            _board[move.Key, move.Value] = Piece.EMPTY;
        }

        public virtual void Reset()
        {
            _board = new Piece[Rows, Columns];
            _moves.Clear();
        }

        private int GetNextAvailableSpace(int column)
        {
            for (var i = Rows - 1; i >= 0; i--)
            {
                if (_board[i, column] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private bool Horizontal(int row, int column)
        {
            if (column + NumWinningPieces > Columns)
            {
                return false;
            }

            return CheckWin(row, column, 0, 1);
        }

        private bool Vertical(int row, int column)
        {
            if (row + NumWinningPieces > Rows)
            {
                return false;
            }

            return CheckWin(row, column, 1, 0);
        }

        private bool DiagUpRight(int row, int column)
        {
            if (row - NumWinningPieces < 0 || column + NumWinningPieces > Columns)
            {
                return false;
            }

            return CheckWin(row, column, -1, 1);
        }

        private bool DiagUpLeft(int row, int column)
        {
            if (row - NumWinningPieces < 0 || column - NumWinningPieces < 0)
            {
                return false;
            }

            return CheckWin(row, column, -1, -1);
        }

        private bool DiagDownRight(int row, int column)
        {
            if (row + NumWinningPieces > Rows || column + NumWinningPieces > Columns)
            {
                return false;
            }

            return CheckWin(row, column, 1, 1);
        }

        private bool DiagDownLeft(int row, int column)
        {
            if (row + NumWinningPieces > Rows || column - NumWinningPieces < 0)
            {
                return false;
            }

            return CheckWin(row, column, 1, -1);
        }

        private bool CheckWin(int row, int column, int rowIncrement, int colIncrement)
        {
            var pieces = new List<Piece>();
            for (var i = 0; i < NumWinningPieces; i++)
            {
                pieces.Add(_board[row + (i * rowIncrement), column + (i * colIncrement)]);
            }

            var uniquePieces = pieces.GetDistinctElements();
            return uniquePieces.Count() == 1 && uniquePieces.First() != Piece.EMPTY;
        }

        private void UpdateLastPiece(int row, int column)
        {
            _moves.Push(new KeyValuePair<int, int>(row, column));
        }

        private bool ColumnIsInRange(int column)
        {
            return column >= 0 && column <= (Columns - 1);
        }

        private bool RowIsInRange(int row)
        {
            return row >= 0 && row <= (Rows - 1);
        }
    }
}
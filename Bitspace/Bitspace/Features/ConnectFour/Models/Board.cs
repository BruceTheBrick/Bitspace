using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitspace.Resources;

namespace Bitspace.Features
{
    public class Board : IBoard
    {
        private int _numCols;
        private int _numRows;
        private int _maxIndex;
        private int _numWinningPieces = 4;
        private Piece[,] _board;

        public void PlacePiece(Piece piece, int column)
        {
            if (!ColumnIsInRange(column))
            {
                ThrowColumnException(column);
            }

            var rowNum = GetNextAvailableSpace(column);
            if (rowNum == -1)
            {
                return;
            }

            _board[rowNum, column] = piece;
        }

        public bool IsColumnFull(int column)
        {
            if (!ColumnIsInRange(column))
            {
                ThrowColumnException(column);
            }

            return GetNextAvailableSpace(column) == -1;
        }

        public Piece GetPiece(int row, int column)
        {
            return _board[row, column];
        }

        public Piece HasWin()
        {
            for (var x = 0; x < _numRows; x++)
            {
                for (var y = 0; y < _numCols; y++)
                {
                    var horizontalWin = HasHorizontalWin(x, y);
                    var verticalWin = HasVerticalWin(x, y);
                    if (horizontalWin || verticalWin)
                    {
                        return _board[x, y];
                    }
                }
            }

            return Piece.Empty;
        }

        public void Setup(int numRows = 6, int numCols = 7)
        {
            _numCols = numCols;
            _numRows = numRows;
            _maxIndex = (_numCols * _numRows) - 1;
            _board = new Piece[numRows, numCols];
            // _board = ArrayExtensions.Init2DArray(numRows, numCols, Piece.Empty);
        }

        public void Reset()
        {
            _board = new Piece[_numRows, _numCols];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var y = 0; y < _numRows; y++)
            {
                sb.Append("|");
                for (var x = 0; x < _numCols; x++)
                {
                    var element = _board[y, x];
                    sb.Append($" {element} |");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private int GetNextAvailableSpace(int column)
        {
            for (var i = _numRows - 1; i >= 0; i--)
            {
                if (_board[i, column] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private int GetNextAvailableIndex(int column)
        {
            var index = column + (_numCols * (_numRows - 1));
            return 0;
        }

        private bool ColumnIsInRange(int column)
        {
            return column >= 0 && column <= (_numCols - 1);
        }

        private bool HasHorizontalWin(int row, int column)
        {
            if (column + _numWinningPieces > _numCols)
            {
                return false;
            }

            var pieces = new List<Piece>();
            for (var i = 0; i < _numWinningPieces; i++)
            {
                pieces.Add(_board[row, column + i]);
            }

            var uniquePieces = pieces.Select(x => x).Distinct();
            return uniquePieces.Count() == 1 && uniquePieces.First() != Piece.Empty;
        }

        private bool HasVerticalWin(int row, int column)
        {
            if (row + _numWinningPieces > _numRows)
            {
                return false;
            }

            var pieces = new List<Piece>();
            for (var i = 0; i < _numWinningPieces; i++)
            {
                pieces.Add(_board[row + i, column]);
            }

            var uniquePieces = pieces.Select(x => x).Distinct();
            return uniquePieces.Count() == 1 && uniquePieces.First() != Piece.Empty;
        }

        // private bool HasDiagonalUpWin(int row, int column)
        // {
        //     
        // }
        //
        // private bool HasDiagonalDownWin(int row, int column)
        // {
        //     
        // }

        private void InitDebugBoard()
        {
            _board = new Piece[_numRows, _numCols];
            _board[0, 0] = Piece.One;
            _board[1, 0] = Piece.One;
            _board[2, 0] = Piece.One;
            _board[3, 0] = Piece.One;
            _board[4, 0] = Piece.One;
            _board[5, 0] = Piece.One;
        }

        private void ThrowColumnException(int column)
        {
            var message = string.Format(ConnectFourPageRegister.CF_COL_EX, column, 0, _numCols);
            throw new ArgumentOutOfRangeException(nameof(column), message);
        }
    }
}
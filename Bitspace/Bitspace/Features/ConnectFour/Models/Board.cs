using System.Collections.Generic;
using System.Linq;
using Bitspace.Core;

namespace Bitspace.Features
{
    public class Board : IBoard
    {
        private const int NumWinningPieces = 4;
        private int _numCols;
        private int _numRows;
        private Piece[,] _board;

        public Piece PlacePiece(Piece piece, int column)
        {
            if (!ColumnIsInRange(column))
            {
                return Piece.Empty;
            }

            var rowNum = GetNextAvailableSpace(column);
            if (rowNum == -1)
            {
                return Piece.Empty;
            }

            _board[rowNum, column] = piece;
            return HasWin();
        }

        public bool IsColumnFull(int column)
        {
            if (!ColumnIsInRange(column))
            {
                return false;
            }

            return GetNextAvailableSpace(column) == -1;
        }

        public Piece GetPiece(int row, int column)
        {
            return _board[row, column];
        }

        public void Setup(int numRows = 6, int numCols = 7)
        {
            _numCols = numCols;
            _numRows = numRows;
            _board = new Piece[numRows, numCols];
        }

        public void Reset()
        {
            _board = new Piece[_numRows, _numCols];
        }

        private Piece HasWin()
        {
            for (var x = 0; x < _numRows; x++)
            {
                for (var y = 0; y < _numCols; y++)
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

            return Piece.Empty;
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

        private bool ColumnIsInRange(int column)
        {
            return column >= 0 && column <= (_numCols - 1);
        }

        private bool Horizontal(int row, int column)
        {
            if (column + NumWinningPieces > _numCols)
            {
                return false;
            }

            return CheckWin(row, column, 0, 1);
        }

        private bool Vertical(int row, int column)
        {
            if (row + NumWinningPieces > _numRows)
            {
                return false;
            }

            return CheckWin(row, column, 1, 0);
        }

        private bool DiagUpRight(int row, int column)
        {
            if (row - NumWinningPieces < 0 || column + NumWinningPieces > _numCols)
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
            if (row + NumWinningPieces > _numRows || column + NumWinningPieces > _numCols)
            {
                return false;
            }

            return CheckWin(row, column, 1, 1);
        }

        private bool DiagDownLeft(int row, int column)
        {
            if (row + NumWinningPieces > _numRows || column - NumWinningPieces < 0)
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
            return uniquePieces.Count() == 1 && uniquePieces.First() != Piece.Empty;
        }
    }
}
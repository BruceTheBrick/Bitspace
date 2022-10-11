using System;
using System.Text;

namespace Bitspace.Features
{
    public class Board : IBoard
    {
        private int _numCols;
        private int _numRows;
        private int _maxIndex;
        private int[,] _board;

        public bool ColumnIsFull(int column)
        {
            if (!ColumnIsInRange(column))
            {
                throw new ArgumentException("Column out of range", nameof(column));
            }

            return GetNextAvailableSpace(column) == -1;
        }

        public void PlacePiece(int player, int column)
        {
            if (!ColumnIsInRange(column))
            {
                throw new ArgumentException("Column out of range", nameof(column));
            }

            var rowNum = GetNextAvailableSpace(column);
            if (rowNum == -1)
            {
                return;
            }

            _board[rowNum, column] = player;
        }

        public int[,] GetBoard()
        {
            return _board;
        }

        public void Setup(int numColumns = 7, int numRows = 6)
        {
            _numCols = numColumns;
            _numRows = numRows;
            _maxIndex = (_numCols * _numRows) - 1;
            _board = new int[_numRows, _numCols];
            InitDebugBoard();
        }

        public void Reset()
        {
            _board = new int[_numRows, _numCols];
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

        private void InitDebugBoard()
        {
            _board = new int[_numRows, _numCols];
            _board[0, 0] = 1;
            _board[1, 0] = 1;
            _board[2, 0] = 1;
            _board[3, 0] = 1;
            _board[4, 0] = 1;
            _board[5, 0] = 1;
        }
    }
}
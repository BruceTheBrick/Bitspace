using System.Text;

namespace Bitspace.Features
{
    public class Board : IBoard
    {
        private int _numCols;
        private int _numRows;
        private int[,] _board;

        public bool ColumnIsFull(int column)
        {
            throw new System.NotImplementedException();
        }

        public bool PlacePiece(int player, int column)
        {
            throw new System.NotImplementedException();
        }

        public int[][] GetBoard()
        {
            throw new System.NotImplementedException();
        }

        public void Setup(int numColumns = 7, int numRows = 6)
        {
            _numCols = numColumns;
            _numRows = numRows;
            _board = new int[_numRows, _numCols];
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
                    sb.Append($"{element}|");
                }

                sb.AppendLine();
            }

            sb.Append('_', (_numCols * 2) + 1);

            return sb.ToString();
        }
    }
}
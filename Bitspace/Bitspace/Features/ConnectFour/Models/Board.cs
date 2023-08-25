using System.Collections.Generic;
using System.Text;

namespace Bitspace.Features
{
    public class Board : IBoard
    {
        private readonly Referee _referee;
        private readonly Stack<KeyValuePair<int, int>> _moves;
        private Piece _winner;
        private Piece[,] _board;

        public Board(int numRows = 6, int numCols = 7)
        {
            Columns = numCols;
            Rows = numRows;
            _board = new Piece[numRows, numCols];
            _moves = new Stack<KeyValuePair<int, int>>();
            _referee = new Referee(this);
        }

        public int Columns { get; }
        public int Rows { get; }

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
            AddMoveToStack(rowNum, column);
        }

        public Piece GetPiece(int row, int column)
        {
            if (!RowIsInRange(row) || !ColumnIsInRange(column))
            {
                return Piece.Invalid;
            }

            return _board[row, column];
        }

        public Piece GetWinner()
        {
            if (_winner != Piece.Empty)
            {
                return _winner;
            }

            return _referee.GetWinner();
        }

        public bool HasWin()
        {
            return _referee.GetWinner() != Piece.Empty;
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
            _board[move.Key, move.Value] = Piece.Empty;
        }

        public virtual void Reset()
        {
            _board = new Piece[Rows, Columns];
            _moves.Clear();
            _winner = Piece.Empty;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var y = 0; y < Rows; y++)
            {
                sb.Append("|");
                for (var x = 0; x < Columns; x++)
                {
                    var element = _board[y, x];
                    sb.Append($" {element.ToDebugString()} |");
                }

                sb.AppendLine();
            }

            return sb.ToString();
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

        private void AddMoveToStack(int row, int column)
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
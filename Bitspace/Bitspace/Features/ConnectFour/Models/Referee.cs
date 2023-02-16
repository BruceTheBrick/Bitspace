using System.Collections.Generic;
using System.Linq;
using Bitspace.Core;

namespace Bitspace.Features
{
    public class Referee
    {
        private const int NumWinningPieces = 4;
        private readonly IBoard _board;
        private readonly int _columns;
        private readonly int _rows;
        public Referee(IBoard board)
        {
            _board = board;
            _columns = board.Columns;
            _rows = board.Rows;
        }

        public Piece GetWinner()
        {
            for (var x = 0; x < _rows; x++)
            {
                for (var y = 0; y < _columns; y++)
                {
                    var h = Horizontal(x, y);
                    var v = Vertical(x, y);
                    var ur = DiagUpRight(x, y);
                    var dr = DiagDownRight(x, y);
                    if (h || v || ur || dr)
                    {
                        return _board.GetPiece(x, y);
                    }
                }
            }

            return Piece.Empty;
        }

        private bool Horizontal(int row, int column)
        {
            if (column + NumWinningPieces > _columns)
            {
                return false;
            }

            return CheckWin(row, column, 0, 1);
        }

        private bool Vertical(int row, int column)
        {
            if (row + NumWinningPieces > _rows)
            {
                return false;
            }

            return CheckWin(row, column, 1, 0);
        }

        private bool DiagUpRight(int row, int column)
        {
            if (row - NumWinningPieces < 0 || column + NumWinningPieces > _columns)
            {
                return false;
            }

            return CheckWin(row, column, -1, 1);
        }

        private bool DiagDownRight(int row, int column)
        {
            if (row + NumWinningPieces > _rows || column + NumWinningPieces > _columns)
            {
                return false;
            }

            return CheckWin(row, column, 1, 1);
        }

        private bool CheckWin(int row, int column, int rowIncrement, int colIncrement)
        {
            var pieces = new List<Piece>();
            for (var i = 0; i < NumWinningPieces; i++)
            {
                pieces.Add(_board.GetPiece(row + (i * rowIncrement), column + (i * colIncrement)));
            }

            var uniquePieces = pieces.GetDistinctElements().ToArray();
            return uniquePieces.Length == 1 && uniquePieces.First() != Piece.Empty;
        }
    }
}
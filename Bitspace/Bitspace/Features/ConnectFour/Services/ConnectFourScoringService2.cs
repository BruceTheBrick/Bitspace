using System.Linq;

namespace Bitspace.Features
{
    public class ConnectFourScoringService2 : IConnectFourScoringService
    {
        private readonly int[][] _precomputedIndexes;
        private Piece _maximisingPlayer;

        public ConnectFourScoringService2()
        {
            PrecomputedIndexes.Init();
            _precomputedIndexes = PrecomputedIndexes.GetRevisedPrecomputedIndexes();
        }

        public void SetMaximisingPlayer(Piece player)
        {
            _maximisingPlayer = player;
        }

        public int GetScore(IBoard board)
        {
            var minimisingPlayerScoreThreats = CountThreats(board, _maximisingPlayer.GetOpponent()) * 1 * -1;
            var minimisingPlayerScoreBase = GetBaseScore(board, _maximisingPlayer.GetOpponent()) * -1;
            var min = minimisingPlayerScoreBase + minimisingPlayerScoreThreats;

            var total = min;
            return total;
        }

        private int GetBaseScore(IBoard board, Piece player)
        {
            var score = 0;
            for (var x = 0; x < board.Rows; x++)
            {
                for (var y = 0; y < board.Columns; y++)
                {
                    if (board.GetPiece(x, y) == player)
                    {
                        score += _precomputedIndexes[x][y];
                    }
                }
            }

            return score;
        }

        private int CountThreats(IBoard board, Piece player)
        {
            var count = 0;

            // Check horizontal threats.
            for (var row = 0; row < board.Rows; row++)
            {
                for (var col = 0; col <= board.Columns - 4; col++)
                {
                    var window = GetWindow(board, row, col, 0, 1);
                    if (window.Select(p => p == player).Count() == 3 && window.Contains(Piece.Empty))
                    {
                        count++;
                    }
                }
            }

            // Check vertical threats.
            for (var row = 0; row <= board.Rows - 4; row++)
            {
                for (var col = 0; col < board.Columns; col++)
                {
                    var window = GetWindow(board, row, col, 1, 0);
                    if (window.Select(p => p == player).Count() == 3 && window.Contains(Piece.Empty))
                    {
                        count++;
                    }
                }
            }

            // Check diagonal (positive slope) threats.
            for (var row = 0; row <= board.Rows - 4; row++)
            {
                for (var col = 0; col <= board.Columns - 4; col++)
                {
                    var window = GetWindow(board, row, col, 1, 1);
                    if (window.Select(p => p == player).Count() == 3 && window.Contains(Piece.Empty))
                    {
                        count++;
                    }
                }
            }

            // Check diagonal (negative slope) threats.
            for (var row = 3; row < board.Rows; row++)
            {
                for (var col = 0; col <= board.Columns - 4; col++)
                {
                    var window = GetWindow(board, row, col, -1, 1);
                    if (window.Select(p => p == player).Count() == 3 && window.Contains(Piece.Empty))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private Piece[] GetWindow(IBoard board, int row, int col, int rowDir, int colDir)
        {
            var window = new Piece[4];
            for (var i = 0; i < 4; i++)
            {
                var r = row + (i * rowDir);
                var c = col + (i * colDir);
                window[i] = board.GetPiece(r, c);
            }

            return window;
        }
    }
}
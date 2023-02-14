using Bitspace.Features.Constants;

namespace Bitspace.Features
{
    public class ConnectFourScoringService : IConnectFourScoringService
    {
        private readonly int[][] _precomputedIndexes;
        private Piece _maximisingPlayer;
        public ConnectFourScoringService()
        {
            PrecomputedIndexes.Init();
            _precomputedIndexes = PrecomputedIndexes.GetStandardPrecomputedIndexes();
        }

        public void SetMaximisingPlayer(Piece player)
        {
            _maximisingPlayer = player;
        }

        public int GetScore(IBoard board, bool isMaximisingPlayer)
        {
            var score = 0;
            var player = isMaximisingPlayer
                ? _maximisingPlayer
                : _maximisingPlayer.GetOpponent();
            score += GetBaseScore(board, player);
            score += NumOfTwos(board, player);
            score += NumOfThrees(board, player);
            score += GetWinnerScore(board, player);

            score -= (int)(GetBaseScore(board, player.GetOpponent()) * ConnectFourScoreConstants.MINIMIZING_PLAYER_MULTIPLIER);
            score -= (int)(NumOfTwos(board, player.GetOpponent()) * ConnectFourScoreConstants.TWO_CONSECUTIVE_VALUE * ConnectFourScoreConstants.MINIMIZING_PLAYER_MULTIPLIER);
            score -= (int)(NumOfThrees(board, player.GetOpponent()) * ConnectFourScoreConstants.THREE_CONSECUTIVE_VALUE * ConnectFourScoreConstants.MINIMIZING_PLAYER_MULTIPLIER);
            score -= GetWinnerScore(board, player.GetOpponent());
            return score;
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

        private int GetWinnerScore(IBoard board, Piece player)
        {
            return board.HasWin() == player ? ConnectFourScoreConstants.WIN_VALUE : 0;
        }

        private int NumOfTwos(IBoard board, Piece player)
        {
            var sum = 0;
            for (var i = 0; i < PrecomputedIndexes.TwoInARow.Length; i++)
            {
                var coords = IndexToCoordinates(board, i);
                if (board.GetPiece(coords.Item1, coords.Item2) != player)
                {
                    continue;
                }

                for (var j = 0; j < PrecomputedIndexes.TwoInARow[i].Count; j++)
                {
                    coords = IndexToCoordinates(board, PrecomputedIndexes.TwoInARow[i][j]);

                    if (board.GetPiece(coords.Item1, coords.Item2) == player)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private int NumOfThrees(IBoard board, Piece player)
        {
            var sum = 0;
            for (var i = 0; i < PrecomputedIndexes.ThreeInARow.Length; i++)
            {
                var coords = IndexToCoordinates(board, i);
                if (board.GetPiece(coords.row, coords.column) != player)
                {
                    continue;
                }

                for (var j = 0; j < PrecomputedIndexes.ThreeInARow[i].Count; j += 2)
                {
                    coords = IndexToCoordinates(board, PrecomputedIndexes.ThreeInARow[i][j]);

                    if (board.GetPiece(coords.Item1, coords.Item2) == player)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private (int row, int column) IndexToCoordinates(IBoard board, int num)
        {
            var col = (num % board.Columns) - 1;
            var row = (num % board.Rows) - 1;
            return (row, col);
        }
    }
}
using Bitspace.Features.Constants;

namespace Bitspace.Features
{
    public class ConnectFourScoringService : IConnectFourScoringService
    {
        private readonly int[][] _precomputedIndexes;
        public ConnectFourScoringService()
        {
            PrecomputedIndexes.Init();
            _precomputedIndexes = PrecomputedIndexes.GetStandardPrecomputedIndexes();
        }

        public int GetScore(IBoard board, bool isMaximisingPlayer)
        {
            var score = 0;
            var player = isMaximisingPlayer
                ? Piece.ONE
                : Piece.TWO;
            score += GetBaseScore(board, player);
            score += GetWinnerScore(board, player);
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

        private int numOfTwos(IBoard board, Piece player)
        {
            var sum = 0;
            for (var i = 0; i < PrecomputedIndexes.twoInARow.Length; i++)
            {
                var coords = IndexToCoordinates(board, i);
                if (board.GetPiece(coords.Item1, coords.Item2) != player)
                {
                    continue;
                }

                for (var j = 0; j < PrecomputedIndexes.twoInARow[i].Count; j++)
                {
                    coords = IndexToCoordinates(board, PrecomputedIndexes.twoInARow[i][j]);

                    if (board.GetPiece(coords.Item1, coords.Item2) == player)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }
        
        private (int, int) IndexToCoordinates(IBoard board, int num)
        {
            var col = (num % board.Columns) - 1;
            var row = (num % board.Rows) - 1;
            return (row, col);
        }
    }
}
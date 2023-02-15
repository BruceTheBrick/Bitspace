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
            var maxScore = GetBaseScore(board, _maximisingPlayer);
            var minScore = GetBaseScore(board, _maximisingPlayer.GetOpponent()) * -1;
            return maxScore + minScore;
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
    }
}
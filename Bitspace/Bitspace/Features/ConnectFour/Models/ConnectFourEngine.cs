namespace Bitspace.Features
{
    public class ConnectFourEngine : IConnectFourEngine
    {
        private int[][] _precomputedIndexes;
        private Piece _player;
        public int GetNextMove(IBoard board, Piece player)
        {
            throw new System.NotImplementedException();
        }

        public int Depth { get; set; }
        public void Initialize(Piece player)
        {
            _player = player;
            _precomputedIndexes = PrecomputedIndexes.GetStandardPrecomputedIndexes();
        }

        public int Evaluate(IBoard board, Piece player)
        {
            if (player == _player)
            {
                return Max(board, Depth);
            }

            return Mini(board, Depth);
        }

        public int Mini(IBoard board, int depth)
        {
            throw new System.NotImplementedException();
        }

        public int Max(IBoard board, int depth)
        {
            throw new System.NotImplementedException();
        }

        private int CurrentPiecesScore(IBoard board, Piece player)
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

            return player == _player
                ? score
                : score * -1;
        }

    }
}
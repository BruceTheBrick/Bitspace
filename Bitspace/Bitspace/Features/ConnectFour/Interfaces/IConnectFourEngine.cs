namespace Bitspace.Features
{
    public interface IConnectFourEngine
    {
        public void Initialize(Piece player);
        public int GetNextMove(IBoard board, Piece player);
        public int Mini(IBoard board, int depth, int alpha, int beta, Piece player);
        public int Max(IBoard board, int depth, int alpha, int beta, Piece player);
        public int Evaluate(IBoard board, int depth);
    }
}
namespace Bitspace.Features
{
    public interface IConnectFourEngine
    {
        public void Initialize(Piece player);
        public int GetNextMove(IBoard board, Piece player);
        public int Depth { get; set; }
        public int Evaluate(IBoard board, Piece player);
        public int Mini(IBoard board, int depth);
        public int Max(IBoard board, int depth);
    }
}
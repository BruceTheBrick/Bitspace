namespace Bitspace.Features
{
    public interface IConnectFourEngine
    {
        public int Depth { get; set; }
        public int ScoreBoard(IBoard board, int player);
        public int Mini(IBoard board);
        public int Max(IBoard board);
    }
}
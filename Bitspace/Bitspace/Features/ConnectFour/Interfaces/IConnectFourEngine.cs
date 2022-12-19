namespace Bitspace.Features
{
    public interface IConnectFourEngine
    {
        public string Name { get; set; }
        public int MovesChecked { get; set; }
        public void SetPlayer(Piece player);
        public int GetNextMove(IBoard board, Piece player);
        public int Minimax(IBoard board, int depth, bool isMaximising);
        public int Evaluate(IBoard board, bool isMaximising);
    }
}
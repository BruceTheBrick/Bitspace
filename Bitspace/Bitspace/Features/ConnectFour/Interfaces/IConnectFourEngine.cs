namespace Bitspace.Features
{
    public interface IConnectFourEngine
    {
        public string Name { get; set; }
        public int MovesChecked { get; set; }
        public void SetEnginePiece(Piece player);
        public int GetNextMove(IBoard board);
        public int Minimax(IBoard board, int depth, bool isMaximising);
    }
}
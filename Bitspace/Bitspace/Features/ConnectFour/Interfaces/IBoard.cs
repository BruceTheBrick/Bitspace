namespace Bitspace.Features
{
    public interface IBoard
    {
        public void PlacePiece(int player, int column);
        public bool IsColumnFull(int column);
        public int GetPiece(int row, int column);
        public void Setup(int numRows = 6, int numCols = 7);
        public void Reset();
        public string ToString();
    }
}
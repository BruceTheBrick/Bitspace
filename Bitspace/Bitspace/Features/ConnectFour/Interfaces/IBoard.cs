namespace Bitspace.Features
{
    public interface IBoard
    {
        public bool ColumnIsFull(int column);
        public void PlacePiece(int player, int column);
        public int[,] GetBoard();
        public int GetPiece(int column, int row);
        public void Setup(int numColumns = 7, int numRows = 6);
        public void Reset();
        public string ToString();
    }
}
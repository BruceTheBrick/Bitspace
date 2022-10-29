namespace Bitspace.Features
{
    public interface IBoard
    {
        public Piece PlacePiece(Piece piece, int column);
        public bool IsColumnFull(int column);
        public Piece GetPiece(int row, int column);
        public void Setup(int numRows = 6, int numCols = 7);
        public void Reset();
    }
}
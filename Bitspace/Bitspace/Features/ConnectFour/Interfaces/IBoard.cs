namespace Bitspace.Features
{
    public interface IBoard
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public Piece PlacePiece(int column, Piece piece);
        public void Undo();
        public bool IsColumnFull(int column);
        public Piece GetPiece(int row, int column);
        public void Setup(int numRows = 6, int numCols = 7);
        public void Reset();
    }
}
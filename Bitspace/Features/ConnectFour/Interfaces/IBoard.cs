namespace Bitspace.Features;

public interface IBoard
{
    public int Columns { get; }
    public int Rows { get; }
    public void PlacePiece(int column, Piece piece);
    public Piece GetPiece(int row, int column);
    public bool HasWin();
    public Piece GetWinner();
    public bool IsColumnFull(int column);
    public bool IsFull();
    public void Undo();
    public void Reset();
    public string ToString();
}
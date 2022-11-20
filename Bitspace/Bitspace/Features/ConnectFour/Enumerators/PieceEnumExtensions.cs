namespace Bitspace.Features
{
    public static class PieceEnumExtensions
    {
        public static Piece GetOtherPiece(this Piece current)
        {
            return current == Piece.ONE ? Piece.TWO : Piece.ONE;
        }
    }
}
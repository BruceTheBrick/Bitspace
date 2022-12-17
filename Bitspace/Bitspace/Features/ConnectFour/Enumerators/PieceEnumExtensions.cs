namespace Bitspace.Features
{
    public static class PieceEnumExtensions
    {
        public static Piece GetOtherPiece(this Piece current)
        {
            return current == Piece.ONE ? Piece.TWO : Piece.ONE;
        }

        public static bool IsNotPlayerPiece(this Piece piece)
        {
            return piece != Piece.ONE && piece != Piece.TWO;
        }

        public static bool IsPlayerPiece(this Piece piece)
        {
            return piece == Piece.ONE || piece == Piece.TWO;
        }
    }
}
namespace Bitspace.Features
{
    public static class PieceEnumExtensions
    {
        public static Piece GetOpponent(this Piece current)
        {
            return current == Piece.One ? Piece.Two : Piece.One;
        }

        public static bool IsNotPlayerPiece(this Piece piece)
        {
            return piece != Piece.One && piece != Piece.Two;
        }

        public static bool IsPlayerPiece(this Piece piece)
        {
            return piece == Piece.One || piece == Piece.Two;
        }

        public static string ToDebugString(this Piece piece)
        {
            switch (piece)
            {
                case Piece.Empty:
                    return " ";
                case Piece.One:
                    return "O";
                case Piece.Two:
                    return "T";
                case Piece.Invalid:
                default:
                    return "I";
            }
        }
    }
}
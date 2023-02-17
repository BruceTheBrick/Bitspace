using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Features.Constants
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Constants can be capitalized with underscores")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "Constants can be capitalized with underscores")]
    public static class ConnectFourScoreConstants
    {
        public const int NUM_WINNING_PIECES = 4;
        public const int OPPONENT_MULTIPLIER = -1;

        public const int TWO_CONSECUTIVE_VALUE = 2;
        public const int THREE_CONSECUTIVE_VALUE = 3;
        public const int WIN_VALUE = int.MaxValue;

        public const double MINIMIZING_PLAYER_MULTIPLIER = 1.25;
    }
}
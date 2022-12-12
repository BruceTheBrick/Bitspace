using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Features.Constants
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Constants can be capitalized with underscores")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "Constants can be capitalized with underscores")]
    public class ConnectFourScoreConstants
    {
        public const int TWO_CONSECUTIVE_VALUE = 20;
        public const int THREE_CONSECUTIVE_VALUE = 60;
        public const int WIN_VALUE = int.MaxValue;

        public const double MINIMIZING_PLAYER_MULTIPLIER = 0.85;
    }
}
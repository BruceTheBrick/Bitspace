using System;

namespace Bitspace.Enums
{
    [Flags]
    public enum TraitsEnum
    {
        None = 0,
        Button = 1,
        Link = 2,
        Image = 4,
        Selected = 8,
        PlaysSound = 16, // 0x0000000000000010
        KeyboardKey = 32, // 0x0000000000000020
        StaticText = 64, // 0x0000000000000040
        SummaryElement = 128, // 0x0000000000000080
        NotEnabled = 256, // 0x0000000000000100
        UpdatesFrequently = 512, // 0x0000000000000200
        SearchField = 1024, // 0x0000000000000400
        StartsMediaSession = 2048, // 0x0000000000000800
        Adjustable = 4096, // 0x0000000000001000
        AllowsDirectInteraction = 8192, // 0x0000000000002000
        CausesPageTurn = 16384, // 0x0000000000004000
        Header = 65536, // 0x0000000000010000
    }
}
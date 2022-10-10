using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace Bitspace.Styles
{
    [ExcludeFromCodeCoverage]
    public struct ColorRef
    {
        public ColorRef(Color color)
        {
            Color = color;
        }

        public Color Color { get; set; }

        public static implicit operator Color(ColorRef x)
        {
            return x.Color;
        }

        public static implicit operator Color?(ColorRef x)
        {
            return x.Color == default ? default : x.Color;
        }
    }
}

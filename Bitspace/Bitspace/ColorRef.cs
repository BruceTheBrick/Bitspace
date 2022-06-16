using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bitspace
{
    public struct ColorRef
    {
        public ColorRef(Color color)
        {
            Color = color;
        }

        public Color Color { get; set; }

        public static implicit operator Color(ColorRef x) => x.Color;
    }
}

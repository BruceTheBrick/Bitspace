using System;
using System.Diagnostics.CodeAnalysis;

namespace Bitspace.UI
{
    [ExcludeFromCodeCoverage]
    public partial class BaseCircleButton
    {
        public BaseCircleButton()
        {
            InitializeComponent();
        }

        private void BaseCircleButton_OnSizeChanged(object sender, EventArgs e)
        {
            CornerRadius = (float)Height / 2;
        }
    }
}
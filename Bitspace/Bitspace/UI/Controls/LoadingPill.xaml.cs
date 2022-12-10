using System;
using System.Diagnostics.CodeAnalysis;

namespace Bitspace.UI
{
    [ExcludeFromCodeCoverage]
    public partial class LoadingPill
    {
        public LoadingPill()
        {
            InitializeComponent();
        }

        private void LoadingPill_OnSizeChanged(object sender, EventArgs e)
        {
            CornerRadius = (float)Height / 2;
        }
    }
}
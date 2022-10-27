﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Controls
{
    [ExcludeFromCodeCoverage]
    public partial class Pill
    {
        public Pill()
        {
            InitializeComponent();
        }

        private void Pill_OnSizeChanged(object sender, EventArgs e)
        {
            CornerRadius = (float)Height / 2;
        }
    }
}
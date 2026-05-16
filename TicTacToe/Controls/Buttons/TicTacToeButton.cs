using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe.Controls.Buttons
{
    public sealed class TicTacToeButton : Button
    {
        private static readonly CornerRadius DEFAULT_BUTTON_CORNER_RADIUS = new CornerRadius(0);

        public static readonly DependencyProperty ButtonRadiusProperty = DependencyProperty.Register(
            nameof(ButtonRadius),
            typeof(CornerRadius),
            typeof(TicTacToeButton),
            new PropertyMetadata(DEFAULT_BUTTON_CORNER_RADIUS));

        public CornerRadius ButtonRadius
        {
            get => (CornerRadius)GetValue(ButtonRadiusProperty);
            set => SetValue(ButtonRadiusProperty, value);
        }

        public static readonly DependencyProperty PathGeometryContentProperty = DependencyProperty.Register(
            nameof(PathGeometryContent),
            typeof(Geometry),
            typeof(TicTacToeButton),
            new PropertyMetadata(default));

        public Geometry PathGeometryContent
        {
            get => (Geometry)GetValue(PathGeometryContentProperty);
            set => SetValue(PathGeometryContentProperty, value);
        }
    }
}

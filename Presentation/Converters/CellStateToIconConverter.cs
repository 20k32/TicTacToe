using Core;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Presentation.Converters
{
    public sealed class CellStateToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value;

            if (value is TicTacToeCellState cellState)
            {
                switch (cellState)
                {
                    case TicTacToeCellState.None: result = default; break;
                    case TicTacToeCellState.Circe: result = Constants.Circle; break;
                    case TicTacToeCellState.Cross: result = Constants.Cross; break;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}

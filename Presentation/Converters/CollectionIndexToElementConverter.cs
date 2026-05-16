using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;

namespace Presentation.Converters
{
    public sealed class CollectionIndexToElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value;

            if (parameter is not null)
            {
                var index = parameter is int
                    ? (int)parameter
                    : int.Parse(parameter as string ?? string.Empty);

                if (value is ICollection<object> collectionGeneric)
                {
                    result = collectionGeneric.ElementAtOrDefault(index);
                }
                else if (value is ICollection collection)
                {
                    result = default;

                    var foundIndex = -1;

                    foreach (var item in collection)
                    {
                        foundIndex++;

                        if (foundIndex == index)
                        {
                            result = item;
                            break;
                        }
                    }
                }
            }


            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}

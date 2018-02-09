using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Launcher.Data
{
    public enum CustomizedGridChildLocateDirection
    {
        Row,
        Column
    }

    public class CustomizedGridChildLocationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int index = (int)values[0];
            int rowCount = (int)values[1];
            int columnCount = (int)values[2];
            CustomizedGridChildLocateDirection direction = (CustomizedGridChildLocateDirection)parameter;

            if (columnCount == 0) return 0;
            else
            {
                int row = Math.DivRem(index, columnCount, out int column);
                switch (direction)
                {
                    case CustomizedGridChildLocateDirection.Row:
                        return row;
                    case CustomizedGridChildLocateDirection.Column:
                        return column;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(parameter));
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

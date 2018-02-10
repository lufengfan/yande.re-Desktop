using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            UIElement element = values[0] as UIElement; // 模版作用的对象。
            int index = (int)values[1];
            int rowCount = (int)values[2];
            int columnCount = (int)values[3];
            CustomizedGridChildLocateDirection direction = (CustomizedGridChildLocateDirection)parameter;

            if (columnCount == 0) return 0;
            else
            {
                int row = Math.DivRem(index, columnCount, out int column);
                switch (direction)
                {
                    case CustomizedGridChildLocateDirection.Row:
                        Grid.SetRow(element, row); // 设置模版作用对象的 Grid.Row 。
                        return row;
                    case CustomizedGridChildLocateDirection.Column:
                        Grid.SetColumn(element, column); // 设置模版作用对象的 Grid.Column 。
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

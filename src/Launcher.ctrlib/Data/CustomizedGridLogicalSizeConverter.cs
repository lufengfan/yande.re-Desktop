using System;
using System.Globalization;
using System.Windows.Data;

namespace Launcher.Data
{
    public sealed class CustomizedGridLogicalSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int total = (int)values[0];
            int factor = (int)values[1];

            if (factor == 0)
                return 0;
            else
            {
                int result = Math.DivRem(total, factor, out int remainder);
                if (remainder == 0)
                    return result;
                else
                    return result + 1;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

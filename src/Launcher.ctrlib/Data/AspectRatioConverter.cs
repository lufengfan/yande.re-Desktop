using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Launcher.Data
{
    public class AspectRatioConverter : IValueConverter, IMultiValueConverter
    {
        protected virtual double Calculate(double width, double height)
        {
            if (width == 0 || height == 0)
                return 1D;
            else
                return width / height;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 1 && values[0] is Size)
            {
                    return this.Convert((Size)values[0], targetType, parameter, culture);
            }
            else if (values.Length == 2)
            {
                double width = System.Convert.ToDouble(values[0], culture);
                double height = System.Convert.ToDouble(values[1], culture);
                return this.Calculate(width, height);
            }
            else
                throw new ArgumentException(nameof(values));
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Size size)
                return this.Calculate(size.Width, size.Height);
            else
            {
                try
                {
                    // 类似 System.Windows.Size 或 System.Data.Size 之类的结构。
                    dynamic obj = value;
                    return this.Calculate(obj.Width, obj.Height);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("参数不是描述对象大小的结构对象。", nameof(value), e);
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

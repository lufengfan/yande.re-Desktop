using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Launcher.Data.BindingCodeDom
{
    public class BindingCodeDomConverter : IValueConverter, IMultiValueConverter
    {
        public virtual object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is BindingCodeDomConverterParameter param)
            {
                object[] result = param?.CodeDom?.Execute(values);
                return this.ProcessCodeDomExecutionResult(result, targetType, parameter, culture);
            }
            else return System.Windows.DependencyProperty.UnsetValue;
        }

        protected virtual object ProcessCodeDomExecutionResult(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0];
        }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Convert(new object[] { value }, targetType, parameter, culture);
        }

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.ConvertBack(value, new Type[] { targetType }, parameter, culture)[0];
        }
    }
}

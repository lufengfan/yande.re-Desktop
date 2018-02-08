using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public class DoubleToGridLengthBindingCodeDomConverter : BindingCodeDomConverter
    {
        private DoubleToGridLengthConverter innerConverter = new DoubleToGridLengthConverter();

        protected override object ProcessCodeDomExecutionResult(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return this.innerConverter.Convert(values[0], targetType, parameter, culture);
        }
    }
}

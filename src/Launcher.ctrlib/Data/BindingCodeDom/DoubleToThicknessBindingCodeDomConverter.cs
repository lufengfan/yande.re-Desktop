using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Launcher.Data.BindingCodeDom
{
    internal class DoubleToThicknessBindingCodeDomConverter : BindingCodeDomConverter
    {
        private DoubleToThicknessConverter innerConverter = new DoubleToThicknessConverter();
        
        protected override object ProcessCodeDomExecutionResult(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return this.innerConverter.Convert(values[0], targetType, parameter, culture);
        }
    }
}

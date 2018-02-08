using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Launcher.Data.BindingCodeDom
{
    public class ColorToSolidColorBrushBindingCodeDomConverter : BindingCodeDomConverter
    {
        public static readonly Dictionary<Color, SolidColorBrush> SolidColorBrushDictionary = new Dictionary<Color, SolidColorBrush>();

        protected override object ProcessCodeDomExecutionResult(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = (Color)values[0];
            if (SolidColorBrushDictionary.ContainsKey(color))
                return SolidColorBrushDictionary[color];
            else
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                SolidColorBrushDictionary.Add(color, brush);
                return brush;
            }
        }
    }
}

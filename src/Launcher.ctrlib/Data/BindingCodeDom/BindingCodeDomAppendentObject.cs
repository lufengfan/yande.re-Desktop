using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Launcher.Data.BindingCodeDom
{
    [ContentProperty(nameof(BindingCodeDomAppendentObject.Value))]
    [TypeConverter(typeof(BindingCodeDomAppendentObject._TypeConverter))]
    public class BindingCodeDomAppendentObject
    {
        public AppendentType AppendentType { get; set; } = AppendentType.BeforeExecute;

        public object Value { get; set; }
        
        public class _TypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => true;
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => true;

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) => new BindingCodeDomAppendentObject() { Value = value };
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) => (value as BindingCodeDomAppendentObject).Value;
        }
    }

    public enum AppendentType
    {
        BeforeExecute,
        AfterExecute
    }
}

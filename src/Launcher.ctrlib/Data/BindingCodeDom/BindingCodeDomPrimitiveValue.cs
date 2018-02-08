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
    [ContentProperty(nameof(BindingCodeDomPrimitiveValue.Value))]
    [TypeConverter(typeof(_TypeConverter))]
    public sealed class BindingCodeDomPrimitiveValue : BindingCodeDomObject
    {
        private bool hasValue = false;
        public bool HasValue => this.hasValue;

        private object value = null;
        public object Value
        {
            get
            {
                if (this.hasValue)
                    return this.value;

                throw new InvalidOperationException("未设置值。");
            }
            set
            {
                this.value = value;
                this.hasValue = true;
            }
        }

        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
        {
            if (this.hasValue)
                calculationStack.Push(this.value);
        }

        public class _TypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => true;
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => true;

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) => new BindingCodeDomPrimitiveValue() { Value = value };
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) => (value as BindingCodeDomPrimitiveValue).Value;
        }
    }
}

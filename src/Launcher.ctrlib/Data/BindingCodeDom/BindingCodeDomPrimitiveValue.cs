using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Yandere;

namespace Launcher.Data.BindingCodeDom
{
    [ContentProperty(nameof(BindingCodeDomPrimitiveValue.Value))]
    [TypeConverter(typeof(_TypeConverter))]
    public class BindingCodeDomPrimitiveValue : BindingCodeDomObject
    {
        protected bool isReadOnly = false;

        private ValueBox<object> valueBox = new ValueBox<object>();

        public bool HasValue => this.valueBox.HasValue;
        
        public object Value
        {
            get => this.valueBox.Value;
            set
            {
                if (this.isReadOnly)
                    throw new NotSupportedException("原始值为只读。");
                else
                    this.valueBox.Value = value;
            }
        }

        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
        {
            if (this.HasValue)
                calculationStack.Push(this.Value);
        }

        public class _TypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => true;
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => true;

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) => new BindingCodeDomPrimitiveValue() { Value = value };
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) => (value as BindingCodeDomPrimitiveValue).Value;
        }
    }

    public abstract class BindingCodeDomConstValue<T> : BindingCodeDomPrimitiveValue
    {
        protected BindingCodeDomConstValue(T constValue)
        {
            this.Value = constValue;
            base.isReadOnly = true;
        }
    }
}

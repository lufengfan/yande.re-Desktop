using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public abstract class BindingCodeDomSpecificBinaryOperation<TLeft, TRight> : BindingCodeDomBinaryOperation
    {
        protected abstract object SpecificCalculationImplementation(TLeft left, TRight right);

        protected abstract TLeft ConvertLeft(object value);
        protected abstract TRight ConvertRight(object value);

        protected sealed override object CalculationImplementation(object left, object right) =>
            this.SpecificCalculationImplementation(
                this.ConvertLeft(left),
                this.ConvertRight(right)
            );
    }
}

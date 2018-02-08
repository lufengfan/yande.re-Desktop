using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public abstract class BindingCodeDomBinaryOperation : BindingCodeDomObject
    {
        public BindingCodeDomObject LeftObject { get; set; }
        public BindingCodeDomObject RightObject { get; set; }
        public BindingCodeDomBinaryOperationCalculationDirection CalculationDirection { get; set; }

        protected abstract object CalculationImplementation(object left, object right);

        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
        {
            object right = BindingCodeDomObject.GetCaculationObject(this.RightObject, calculationStack, localDictionary);
            object left = BindingCodeDomObject.GetCaculationObject(this.LeftObject, calculationStack, localDictionary);

            object result;
            if (this.CalculationDirection == BindingCodeDomBinaryOperationCalculationDirection.LeftToRight)
                result = this.CalculationImplementation(left, right);
            else
                result = this.CalculationImplementation(right, left);
            calculationStack.Push(result);
        }
    }

    public enum BindingCodeDomBinaryOperationCalculationDirection
    {
        LeftToRight,
        RightToLeft
    }
}

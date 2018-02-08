using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public class BindingCodeDomEqualityBinaryOperation : BindingCodeDomBinaryOperation
    {
        protected override object CalculationImplementation(object left, object right) => object.Equals(left, right);
    }
}

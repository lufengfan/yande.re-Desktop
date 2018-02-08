using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public sealed class BindingCodeDomDoNothing : BindingCodeDomObject
    {
        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary) { }
    }
}

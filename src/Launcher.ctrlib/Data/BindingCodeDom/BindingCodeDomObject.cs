using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Launcher.Data.BindingCodeDom
{
    [DefaultProperty(nameof(BindingCodeDomObject.AppendentObjects))]
    public abstract class BindingCodeDomObject
    {
        public BindingCodeDomAppendentObjectCollection AppendentObjects { get; set; }

        protected internal abstract void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary);

        protected internal static object GetCaculationObject(BindingCodeDomObject codeDomObject, Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
        {
            if (codeDomObject != null)
                codeDomObject.Execute(calculationStack, localDictionary);

            return calculationStack.Pop();
        }

        public object[] Execute(object[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));

            Stack<object> calculationStack = new Stack<object>();
            foreach (object parameter in parameters)
                calculationStack.Push(parameter);

            this.Execute(calculationStack, new Dictionary<byte, object>());
            return calculationStack.Reverse().ToArray();
        }
    }
}

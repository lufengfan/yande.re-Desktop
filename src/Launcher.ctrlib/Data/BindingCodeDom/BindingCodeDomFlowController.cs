using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public abstract class BindingCodeDomFlowController : BindingCodeDomObject
    {
        public sealed class ExecuteArgs
        {
            private Stack<object> calculationStack;
            public Stack<object> CalculationStack => this.calculationStack;

            private Dictionary<byte, object> localDictionary;
            public Dictionary<byte, object> LocalDictionary => this.localDictionary;

            public int SkipCount { get; set; } = 0;

            public ExecuteArgs(Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
            {
                this.calculationStack = calculationStack ?? throw new ArgumentNullException(nameof(calculationStack));
                this.localDictionary = localDictionary ?? throw new ArgumentNullException(nameof(localDictionary));
            }
        }

        protected abstract void ExecuteFlowController(ExecuteArgs args);

        public virtual void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary, BindingCodeDomObjectGroup group)
        {
            if (calculationStack == null) throw new ArgumentNullException(nameof(calculationStack));
            if (group == null) throw new ArgumentNullException(nameof(group));

            ExecuteArgs args = new ExecuteArgs(calculationStack, localDictionary);
            this.ExecuteFlowController(args);

            group.Items.SkipItemCount(args.SkipCount);
        }

        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary) =>
            throw new NotSupportedException();
    }
}

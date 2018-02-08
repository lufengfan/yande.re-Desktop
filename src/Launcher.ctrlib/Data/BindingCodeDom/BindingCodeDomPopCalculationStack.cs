using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public class BindingCodeDomPopCalculationStack : BindingCodeDomObject
    {
        public int PopCount { get; set; }

        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
        {
            int popCount = this.PopCount;
            if (popCount < 0) return;
            else if (popCount > calculationStack.Count)
                calculationStack.Clear();
            else
            {
                for (int i = 0; i < popCount; i++)
                    calculationStack.Pop();
            }
        }
    }
}

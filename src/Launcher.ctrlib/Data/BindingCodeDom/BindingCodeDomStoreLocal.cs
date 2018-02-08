using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public class BindingCodeDomStoreLocal : BindingCodeDomObject
    {
        public bool HasValue => this.localIndex.HasValue;

        private byte? localIndex;
        public byte LocalIndex
        {
            get => this.localIndex.Value;
            set => this.localIndex = value;
        }

        public bool StoreWithoutPop { get; set; } = false;

        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
        {
            if (!this.HasValue) return;

            byte localIndex = this.LocalIndex;
            object value;
            if (this.StoreWithoutPop)
                value = calculationStack.Peek();
            else
                value = calculationStack.Pop();

            if (localDictionary.ContainsKey(this.LocalIndex))
                localDictionary[localIndex] = value;
            else
                localDictionary.Add(localIndex, value);
        }
    }
}

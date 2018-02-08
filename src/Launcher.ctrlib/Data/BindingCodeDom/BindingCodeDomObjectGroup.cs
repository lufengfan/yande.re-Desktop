using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Launcher.Data.BindingCodeDom
{
    [DefaultProperty(nameof(BindingCodeDomObjectGroup.Items))]
    [ContentProperty(nameof(BindingCodeDomObjectGroup.Items))]
    public class BindingCodeDomObjectGroup : BindingCodeDomObject, IAddChild
    {
        public BindingCodeDomObjectCollection Items { get; set; }

        public void AddChild(object value)
        {
            if (value == null)
                return;
            else
                this.Items.Add(BindingCodeDomObjectCollection.ConvertToBindingCodeDomObject(value));
        }

        void IAddChild.AddText(string text) => this.AddChild(text);

        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
        {
            for (; this.Items.pointer < this.Items.Count; this.Items.pointer++)
            {
                var item = this.Items[this.Items.pointer];
                if (item is BindingCodeDomFlowController)
                    (item as BindingCodeDomFlowController).Execute(calculationStack, localDictionary, this);
                else
                    item.Execute(calculationStack, localDictionary);
            }

            this.Items.Reset();
        }

    }
}

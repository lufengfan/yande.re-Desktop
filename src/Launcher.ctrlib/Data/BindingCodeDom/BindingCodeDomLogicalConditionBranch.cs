using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Launcher.Data.BindingCodeDom
{
    [ContentProperty(nameof(BindingCodeDomLogicalConditionBranch.Condition))]
    public class BindingCodeDomLogicalConditionBranch : BindingCodeDomObject
    {
        public BindingCodeDomObject Condition { get; set; }
        public BindingCodeDomObject TrueCondition { get; set; }
        public BindingCodeDomObject FalseCondition { get; set; }

        protected internal override void Execute(Stack<object> calculationStack, Dictionary<byte, object> localDictionary)
        {
            object condition = BindingCodeDomObject.GetCaculationObject(this.Condition, calculationStack, localDictionary);

            if (condition is bool)
            {
                if ((bool)condition)
                    this.TrueCondition.Execute(calculationStack, localDictionary);
                else
                    this.FalseCondition.Execute(calculationStack, localDictionary);
            }
            else throw new InvalidOperationException("逻辑条件分支的测试条件结果不为布尔值。");
        }
    }
}

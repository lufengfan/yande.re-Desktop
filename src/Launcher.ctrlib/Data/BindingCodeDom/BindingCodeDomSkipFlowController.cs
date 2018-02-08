using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public class BindingCodeDomSkipFlowController : BindingCodeDomFlowController
    {
        public virtual int SkipCount { get; set; } = 0;

        protected override void ExecuteFlowController(ExecuteArgs args)
        {
            args.SkipCount = this.SkipCount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public sealed class BindingCodeDomReturnFlowController : BindingCodeDomSkipFlowController
    {
        public override int SkipCount
        {
            get => int.MaxValue;
            set => throw new NotSupportedException();
        }
    }
}

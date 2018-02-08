using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Launcher.Data.BindingCodeDom
{
    [ContentProperty(nameof(BindingCodeDomConverterParameter.CodeDom))]
    public class BindingCodeDomConverterParameter
    {
        public BindingCodeDomObject CodeDom { get; set; }
    }
}

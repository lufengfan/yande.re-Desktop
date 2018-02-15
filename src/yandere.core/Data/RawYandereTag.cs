using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    internal class RawYandereTag : YandereTag
    {
        public override YandereTagType TagType => throw new NotSupportedException();

        public RawYandereTag(string value) : base(value, YandereTagType.Any) { }
    }
}

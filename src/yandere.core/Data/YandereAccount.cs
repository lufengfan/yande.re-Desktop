using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereAccount
    {
        public virtual uint ID { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual YandereTagCollection BlackListedTags { get; } = new YandereTagCollection();
    }
}

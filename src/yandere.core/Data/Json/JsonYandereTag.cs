using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    public class JsonYandereTag : YandereTag
    {

        public static YandereTag GetTag(string name)
        {
#warning 未实现
            return new RawYandereTag(name);
        }
    }
}

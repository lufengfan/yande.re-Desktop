using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereChangeStateActionResponse : YandereActionResponse
    {
        protected YandereChangeStateActionResponse(HttpResponseMessage httpResponse) : base(httpResponse) { }

        public override bool TryGetResponseValue(out object value)
        {
            value = null;
            return true;
        }
    }
}

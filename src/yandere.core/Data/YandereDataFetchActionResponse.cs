using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereDataFetchActionResponse<TData> : YandereActionResponse
    {
        protected YandereDataFetchActionResponse(HttpResponseMessage httpResponse) : base(httpResponse) { }

        protected abstract TData GetResponseValue();

        public override bool TryGetResponseValue(out object value)
        {
            try
            {
                value = this.GetResponseValue();
                return true;
            }
            catch (Exception)
            {
                value = null;
                return false;
            }
        }
    }
}

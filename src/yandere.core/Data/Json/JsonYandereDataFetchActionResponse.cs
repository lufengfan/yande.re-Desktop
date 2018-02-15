using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    public class JsonYandereDataFetchActionResponse<TData> : YandereDataFetchActionResponse<TData>
    {
        private Lazy<TData> dataLazy;

        public JsonYandereDataFetchActionResponse(HttpResponseMessage httpResponse) : base(httpResponse) =>
            this.dataLazy = new Lazy<TData>(
                () => JsonConvert.DeserializeObject<TData>(this.RawHttpResponse.Content.ReadAsStringAsync().Result)
            );

        protected override TData GetResponseValue() => this.dataLazy.Value;
    }
}

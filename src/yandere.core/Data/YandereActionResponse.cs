using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereActionResponse
    {
        public StatusCode StatusCode => (StatusCode)this.RawHttpResponse.StatusCode;

        public virtual bool IsSuccess => this.RawHttpResponse.IsSuccessStatusCode;

        public virtual string ReasonPhrase => this.RawHttpResponse.ReasonPhrase;

        public virtual HttpResponseMessage RawHttpResponse { get; protected set; }

        protected YandereActionResponse(HttpResponseMessage httpResponse) =>
            this.RawHttpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));

        public abstract bool TryGetResponseValue(out object value);
    }
}

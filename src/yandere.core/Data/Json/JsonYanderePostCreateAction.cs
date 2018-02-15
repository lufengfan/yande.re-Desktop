using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    public class JsonYanderePostCreateAction : YanderePostCreateAction
    {
        public JsonYanderePostCreateAction(YanderePostCreateActionParameters parameters) : base(parameters) { }

        protected override Uri GetBaseUri() => new Uri("https://yande.re/post/create.json", UriKind.Absolute);

        protected override YandereActionResponse ParseRawResponse(HttpResponseMessage httpResponse) => new JsonYandereChangeStateActionResponse(httpResponse);
    }
}

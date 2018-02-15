using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    public class JsonYanderePostDestroyAction : YanderePostDestroyAction
    {
        public JsonYanderePostDestroyAction(YanderePostDestroyActionParameters parameters) : base(parameters) { }

        protected override Uri GetBaseUri() => new Uri("https://yande.re/post/destroy.json", UriKind.Absolute);

        protected override YandereActionResponse ParseRawResponse(HttpResponseMessage httpResponse) => new JsonYandereChangeStateActionResponse(httpResponse);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    public class JsonYanderePostsListAction : YanderePostsListAction
    {
        public JsonYanderePostsListAction(YanderePostsListActionParameters parameters) : base(parameters) { }
        
        protected sealed override Uri GetBaseUriWithoutQuery() => new Uri("https://yande.re/post.json", UriKind.Absolute);

        protected override YandereActionResponse ParseRawResponse(HttpResponseMessage httpResponse) => new JsonYandereDataFetchActionResponse<post_json[]>(httpResponse);
    }
}

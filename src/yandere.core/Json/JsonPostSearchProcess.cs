using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere.Data;
using Yandere.Data.Json;

namespace Yandere.Json
{
    public class JsonPostSearchProcess : PostSearchProcess
    {
        protected internal override IEnumerable<YanderePostPreview> SearchInternal(YandereTagCollection tags)
        {
            var parameters = new YanderePostsListActionParameters()
            {
                Limit = YanderePostsListActionParameters.MaxLimit,
                Tags = tags
            };
            var action = new JsonYanderePostsListAction(parameters);

            for (int page = 0; true; page++)
            {
                YandereActionResponse response;

                const int maxRetry = 5;
                int retry = 0;
                do
                {
                    response = action.DoAction();
                }
                while (++retry <= maxRetry && !response.IsSuccess);

                if (response.IsSuccess)
                {
                    if (response.TryGetResponseValue(out object value) &&
                        (value is post_json[] jObjs) &&
                        (jObjs.Length > 0)
                    )
                    {
                        foreach (post_json jObj in jObjs)
                            yield return new YanderePostPreview(
                                jObj.id,
                                new Uri(jObj.preview_url, UriKind.Absolute),
                                new Size(jObj.width, jObj.height),
                                YandereTagCollection.Parse(jObj.tags),
                                new Lazy<YanderePost>(() => JsonYanderePost.GetPost(jObj))
                            );
                    }
                    else break;
                }
                else throw new InvalidOperationException("HTTP 通讯时发生无法恢复的错误。");
            }
        }
    }
}

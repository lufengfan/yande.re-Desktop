using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    public class JsonYanderePost : YanderePost
    {
        internal JsonYanderePost(post_json jObj)
        {
            if (jObj == null) throw new ArgumentNullException(nameof(jObj));

            this.ID = jObj.id;

            string[] tagNames = jObj.tags.Split(' ');
            foreach (var tagName in tagNames)
                this.Tags.Add(JsonYandereTag.GetTag(tagName));
            
            if (jObj.parent_id.HasValue)
                this.ParentPost = JsonYanderePost.GetPost(jObj.parent_id.Value);
            else
                this.ParentPost = null;

            this.HasChildren = jObj.has_children;

            this.PostTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddMilliseconds(jObj.created_at);
            this.ImageUri = new Uri(jObj.jpeg_url, UriKind.Absolute);
            this.PngImageUri = new Uri(jObj.file_url, UriKind.Absolute);
            this.SampleImageUri = new Uri(jObj.sample_url, UriKind.Absolute);
            this.PreviewImageUri = new Uri(jObj.preview_url, UriKind.Absolute);
            this.Size = new System.Drawing.Size(jObj.width, jObj.height);
        }

        public static YanderePost GetPost(uint id)
        {
            if (!YanderePost.PostsCache.ContainsKey(id))
            {
                YanderePost post = new Html.HtmlYanderePost(id);
                var parameters = new YanderePostsListActionParameters()
                {
                    Limit = YanderePostsListActionParameters.MaxLimit,
                    Tags = post.Tags
                };
                var action = new JsonYanderePostsListAction(parameters);
                for (int page = 1; true; page++)
                {
                    parameters.Page = page;
                    var response = action.DoAction();
                    if (response.TryGetResponseValue(out object value) &&
                        (value is post_json[] jObjs) &&
                        (jObjs.Length > 0)
                    )
                    {
                        foreach (post_json jObj in jObjs)
                            if (jObj.id == id)
                            {
                                post = new JsonYanderePost(jObj);
                                goto PostConstructed;
                            }
                    }
                    else break;
                }
                PostConstructed:

                YanderePost.PostsCache.Add(id, post);
                return post;
            }
            else
                return YanderePost.PostsCache[id];
        }

        internal static YanderePost GetPost(post_json jObj)
        {
            if (jObj == null) throw new ArgumentNullException(nameof(jObj));

            if (YanderePost.PostsCache.ContainsKey(jObj.id))
                return YanderePost.PostsCache[jObj.id];
            else
            {
                JsonYanderePost post = new JsonYanderePost(jObj);
                YanderePost.PostsCache.Add(jObj.id, post);
                return post;
            }
        }
    }
}

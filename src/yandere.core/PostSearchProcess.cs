using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yandere.Data;

namespace Yandere
{
    public abstract class PostSearchProcess :
        ISearchProcess<PostSearchResult, YandereTag>,
        ISearchProcess<PostSearchResult, YandereTagCollection>
    {
        public PostSearchResult Search()
        {
            return new PostSearchResult(this.SearchInternal());
        }

        public PostSearchResult Search(YandereTag condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));

            return new PostSearchResult(this.SearchInternal(HtmlPostSearchProcess.TagEscape(condition)));
        }

        public PostSearchResult Search(YandereTagCollection condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));

            return new PostSearchResult(
                this.SearchInternal(
                    condition.Select(tag => HtmlPostSearchProcess.TagEscape(tag))
                        .ToArray()
                )
            );
        }

        public static string TagEscape(YandereTag tag)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));

            return Regex.Replace(tag.Value, @"\s", "_");
        }

        protected internal abstract IEnumerable<YanderePostPreview> SearchInternal(params string[] tags);
    }
}

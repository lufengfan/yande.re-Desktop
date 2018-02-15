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
            return new PostSearchResult(this.SearchInternal(new YandereTagCollection()));
        }

        public PostSearchResult Search(YandereTag condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));

            return new PostSearchResult(this.SearchInternal(new YandereTagCollection { condition }));
        }

        public PostSearchResult Search(YandereTagCollection condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));

            return new PostSearchResult(this.SearchInternal(condition));
        }
        
        protected internal abstract IEnumerable<YanderePostPreview> SearchInternal(YandereTagCollection tags);
    }
}

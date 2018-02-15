using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YanderePostRevertTagsAction : YandereAction_Post
    {
        protected YanderePostRevertTagsAction(YanderePostRevertTagsActionParameters parameters) : base() =>
            this.Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
    }
}

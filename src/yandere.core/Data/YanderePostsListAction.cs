using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YanderePostsListAction : YandereAction_Get
    {
        protected YanderePostsListAction(YanderePostsListActionParameters parameters) : base() =>
            this.Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YanderePostDestroyAction : YandereAction_Post
    {
        protected YanderePostDestroyAction(YanderePostDestroyActionParameters parameters) : base() => this.Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereSetAvatarAction : YandereAction_Post
    {
        protected YandereSetAvatarAction(YandereSetAvatarActionParameters parameters) : base() =>
            this.Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
    }
}

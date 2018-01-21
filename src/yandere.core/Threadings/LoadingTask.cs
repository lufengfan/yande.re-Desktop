using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Threadings
{
    public abstract class LoadingTask<TReturn> : ILoadingTask<TReturn>
    {
        public abstract TReturn Run(params object[] args);

        object ILoadingTask.Run(params object[] args)
        {
            return this.Run(args);
        }
    }
}

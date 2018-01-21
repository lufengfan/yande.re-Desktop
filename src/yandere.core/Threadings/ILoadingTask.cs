using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Threadings
{
    public interface ILoadingTask
    {
        object Run(params object[] args);
    }

    public interface ILoadingTask<TReturn> : ILoadingTask
    {
        new TReturn Run(params object[] args);
    }
}

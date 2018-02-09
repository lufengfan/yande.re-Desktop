using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data
{
    public interface ISelector<TSource, TTarget>
    {
        TTarget Select(TSource source, params object[] args);
    }
}

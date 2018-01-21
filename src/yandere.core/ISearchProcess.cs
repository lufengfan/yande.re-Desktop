using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere
{
    public interface ISearchProcess<TSearchResult, TSearchCondition>
    {
        TSearchResult Search(TSearchCondition condition);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Collections.ObjectModel
{
    public interface IItemCounts : IReadOnlyDictionary
    {
        IReadOnlyCollection Items { get; }
        IReadOnlyCollection<int> Counts { get; }
    }

    public interface IItemCounts<T> : IReadOnlyDictionary<T, int>
    {
        IReadOnlyCollection<T> Items { get; }
        IReadOnlyCollection<int> Counts { get; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Collections.ObjectModel
{
    public interface ICountedCollection : ICollection
    {
        IItemCounts ItemCounts { get; }
    }

    public interface ICountedCollection<T> : ICollection<T>
    {
        IItemCounts<T> ItemCounts { get; }
    }
}

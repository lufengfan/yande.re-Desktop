using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public interface IReadOnlyDictionary : IReadOnlyCollection, IEnumerable
    {
        object this[object key] { get; }
        IEnumerable Keys { get; }
        IEnumerable Values { get; }
        bool Contains(object key);
        IDictionaryEnumerator GetEnumerator();
    }
}

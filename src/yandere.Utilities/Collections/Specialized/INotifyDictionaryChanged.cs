using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Collections.Specialized
{
    public interface INotifyDictionaryChanged<TKey, TValue>
    {
        event NotifyDictionaryChangedEventHandler<TKey, TValue> DictionaryChanged;
    }
}

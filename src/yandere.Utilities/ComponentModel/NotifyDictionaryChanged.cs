using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere.Collections.Specialized;

namespace Yandere.ComponentModel
{
    public class NotifyDictionaryChanged<TKey, TValue> : INotifyDictionaryChanged<TKey, TValue>
    {
        private object sender;

        public NotifyDictionaryChanged(object sender) =>
            this.sender = sender;

        public event NotifyDictionaryChangedEventHandler<TKey, TValue> DictionaryChanged;

        public void OnDictionaryChanged(NotifyDictionaryChangedEventArgs<TKey, TValue> e)
        {
            this.DictionaryChanged?.Invoke(this.sender, e);
        }

        public void OnDictionaryChanged(NotifyDictionaryChangedAction action) => this.OnDictionaryChanged(new NotifyDictionaryChangedEventArgs<TKey, TValue>(action));

        public void OnDictionaryChanged(NotifyDictionaryChangedAction action, TKey changedKey, TValue changedValue) => this.OnDictionaryChanged(new NotifyDictionaryChangedEventArgs<TKey, TValue>(action, changedKey, changedValue));

        public void OnDictionaryChanged(NotifyDictionaryChangedAction action, TKey changedKey, TValue oldValue, TValue newValue) => this.OnDictionaryChanged(new NotifyDictionaryChangedEventArgs<TKey, TValue>(action, changedKey, oldValue, newValue));
    }
}

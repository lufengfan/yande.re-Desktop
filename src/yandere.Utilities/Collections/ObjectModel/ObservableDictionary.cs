using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere.Collections.Specialized;
using Yandere.ComponentModel;

namespace Yandere.Collections.ObjectModel
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, INotifyPropertyChanged, INotifyCollectionChanged, INotifyDictionaryChanged<TKey, TValue>
    {
        private Dictionary<TKey, TValue> innerDictionary;
        private IEqualityComparer<TKey> comparer;

        public TValue this[TKey key]
        {
            get => this.innerDictionary[key];
            set
            {
                this.innerDictionary[key] = value;
                this.NotifyItemChanged();
            }
        }

        public ICollection<TKey> Keys => this.innerDictionary.Keys;
        ICollection IDictionary.Keys => this.innerDictionary.Keys;

        public ICollection<TValue> Values => this.innerDictionary.Values;
        ICollection IDictionary.Values => this.innerDictionary.Values;

        public int Count => this.innerDictionary.Count;

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)this.innerDictionary).IsReadOnly;
        bool IDictionary.IsReadOnly => ((IDictionary)this.innerDictionary).IsReadOnly;

        bool IDictionary.IsFixedSize => ((IDictionary)this.innerDictionary).IsFixedSize;

        object ICollection.SyncRoot => ((ICollection)this.innerDictionary).SyncRoot;

        bool ICollection.IsSynchronized => ((ICollection)this.innerDictionary).IsSynchronized;

        object IDictionary.this[object key]
        {
            get => ((IDictionary)this.innerDictionary)[key];
            set
            {
                ((IDictionary)this.innerDictionary)[key] = value;
                this.NotifyItemChanged();
            }
        }

        #region NotifyPropertyChanged Members
        private NotifyPropertyChanged notifyPropertyChanged;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.notifyPropertyChanged.PropertyChanged += value;
            remove => this.notifyPropertyChanged.PropertyChanged -= value;
        }
        #endregion

        #region NotifyCollectionChanged Members
        private NotifyCollectionChanged notifyCollectionChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add => this.notifyCollectionChanged.CollectionChanged += value;
            remove => this.notifyCollectionChanged.CollectionChanged -= value;
        }
        #endregion

        #region NotifyDictionaryChanged Members
        private NotifyDictionaryChanged<TKey, TValue> notifyDictionaryChanged;

        public event NotifyDictionaryChangedEventHandler<TKey, TValue> DictionaryChanged
        {
            add => this.notifyDictionaryChanged.DictionaryChanged += value;
            remove => this.notifyDictionaryChanged.DictionaryChanged -= value;
        }
        #endregion

        //
        // 摘要:
        //     初始化 System.Collections.Generic.Dictionary`2 类的新实例，该实例为空，具有默认的初始容量并为键类型使用默认的相等比较器。
        public ObservableDictionary()
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<TKey, TValue>(this);

            this.innerDictionary = new Dictionary<TKey, TValue>();
            this.comparer = EqualityComparer<TKey>.Default;
        }
        //
        // 摘要:
        //     初始化 System.Collections.Generic.Dictionary`2 类的新实例，该实例为空，具有指定的初始容量并为键类型使用默认的相等比较器。
        //
        // 参数:
        //   capacity:
        //     System.Collections.Generic.Dictionary`2 可包含的初始元素数。
        //
        // 异常:
        //   T:System.ArgumentOutOfRangeException:
        //     capacity 小于 0。
        public ObservableDictionary(int capacity)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<TKey, TValue>(this);

            this.innerDictionary = new Dictionary<TKey, TValue>(capacity);
            this.comparer = EqualityComparer<TKey>.Default;
        }
        //
        // 摘要:
        //     初始化 System.Collections.Generic.Dictionary`2 类的新实例，该实例为空，具有默认的初始容量并使用指定的 System.Collections.Generic.IEqualityComparer`1。
        //
        // 参数:
        //   comparer:
        //     比较键时要使用的 System.Collections.Generic.IEqualityComparer`1 实现，或者为 null，以便为键类型使用默认的
        //     System.Collections.Generic.EqualityComparer`1。
        public ObservableDictionary(IEqualityComparer<TKey> comparer)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<TKey, TValue>(this);

            this.innerDictionary = new Dictionary<TKey, TValue>(comparer);
            this.comparer = comparer;
        }
        //
        // 摘要:
        //     初始化 System.Collections.Generic.Dictionary`2 类的新实例，该实例包含从指定的 System.Collections.Generic.IDictionary`2
        //     复制的元素并为键类型使用默认的相等比较器。
        //
        // 参数:
        //   dictionary:
        //     System.Collections.Generic.IDictionary`2，它的元素被复制到新 System.Collections.Generic.Dictionary`2。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     dictionary 为 null。
        //
        //   T:System.ArgumentException:
        //     dictionary 包含一个或多个重复键。
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<TKey, TValue>(this);

            this.innerDictionary = new Dictionary<TKey, TValue>(dictionary);
            this.comparer = EqualityComparer<TKey>.Default;
        }
        //
        // 摘要:
        //     初始化 System.Collections.Generic.Dictionary`2 类的新实例，该实例为空，具有指定的初始容量并使用指定的 System.Collections.Generic.IEqualityComparer`1。
        //
        // 参数:
        //   capacity:
        //     System.Collections.Generic.Dictionary`2 可包含的初始元素数。
        //
        //   comparer:
        //     比较键时要使用的 System.Collections.Generic.IEqualityComparer`1 实现，或者为 null，以便为键类型使用默认的
        //     System.Collections.Generic.EqualityComparer`1。
        //
        // 异常:
        //   T:System.ArgumentOutOfRangeException:
        //     capacity 小于 0。
        public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<TKey, TValue>(this);

            this.innerDictionary = new Dictionary<TKey, TValue>(capacity, comparer);
            this.comparer = comparer;
        }
        //
        // 摘要:
        //     初始化 System.Collections.Generic.Dictionary`2 类的新实例，该实例包含从指定的 System.Collections.Generic.IDictionary`2
        //     中复制的元素并使用指定的 System.Collections.Generic.IEqualityComparer`1。
        //
        // 参数:
        //   dictionary:
        //     System.Collections.Generic.IDictionary`2，它的元素被复制到新 System.Collections.Generic.Dictionary`2。
        //
        //   comparer:
        //     比较键时要使用的 System.Collections.Generic.IEqualityComparer`1 实现，或者为 null，以便为键类型使用默认的
        //     System.Collections.Generic.EqualityComparer`1。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     dictionary 为 null。
        //
        //   T:System.ArgumentException:
        //     dictionary 包含一个或多个重复键。
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<TKey, TValue>(this);

            this.innerDictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
            this.comparer = comparer;
        }

        private void NotifyItemChanged() => this.notifyPropertyChanged.OnPropertyChanged("Item[]");

        public void Add(TKey key, TValue value)
        {
            this.innerDictionary.Add(key, value);

            this.AddInternal(key, value);
        }
        void IDictionary.Add(object key, object value)
        {
            ((IDictionary)this.innerDictionary).Add(key, value);

            this.AddInternal((TKey)key, (TValue)value);
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)this.innerDictionary).Add(item);

            this.AddInternal(item.Key, item.Value);
        }

        private void AddInternal(TKey key, TValue value)
        {
            this.notifyPropertyChanged.OnPropertyChanged(nameof(this.Count));
            this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value)));
            this.notifyDictionaryChanged.OnDictionaryChanged(NotifyDictionaryChangedAction.Add, key, value);
        }

        public void Clear()
        {
            this.innerDictionary.Clear();
            this.notifyPropertyChanged.OnPropertyChanged(nameof(this.Count));
            this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            this.notifyDictionaryChanged.OnDictionaryChanged(NotifyDictionaryChangedAction.Reset);
        }
        
        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) => ((ICollection<KeyValuePair<TKey, TValue>>)this.innerDictionary).Contains(item);
        bool IDictionary.Contains(object key) => ((IDictionary)this.innerDictionary).Contains(key);

        public bool ContainsKey(TKey key) => this.innerDictionary.ContainsKey(key);

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ((ICollection<KeyValuePair<TKey, TValue>>)this.innerDictionary).CopyTo(array, arrayIndex);
        void ICollection.CopyTo(Array array, int index) => ((IDictionary)this.innerDictionary).CopyTo(array, index);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => this.innerDictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.innerDictionary.GetEnumerator();
        IDictionaryEnumerator IDictionary.GetEnumerator() => this.innerDictionary.GetEnumerator();

        public bool Remove(TKey key) => this.innerDictionary.Remove(key);
        void IDictionary.Remove(object key)
        {
            if (!((IDictionary)this.innerDictionary).Contains(key)) return;

            var enumerator = ((IDictionary)this.innerDictionary).GetEnumerator();
            int index = 0;
            object value = null;
            while (enumerator.MoveNext())
            {
                if (this.comparer.Equals((TKey)enumerator.Key, (TKey)key))
                {
                    value = enumerator.Value;
                    break;
                }
                else index++;
            }
            ((IDictionary)this.innerDictionary).Remove(key);

            this.RemoveInternal((TKey)key, (TValue)value, index);
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if (!this.Keys.Contains(item.Key)) return false;
            else
            {
                int index = 0;
                var enumerator = ((ICollection<KeyValuePair<TKey, TValue>>)this.innerDictionary).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (this.comparer.Equals(current.Key, item.Key) && EqualityComparer<TValue>.Default.Equals(current.Value, item.Value))
                        break;
                    else index++;
                }

                if (((ICollection<KeyValuePair<TKey, TValue>>)this.innerDictionary).Remove(item))
                {
                    this.RemoveInternal(item.Key, item.Value, index);
                    return true;
                }
                else return false;
            }
        }

        private void RemoveInternal(TKey key, TValue value, int index)
        {
            this.notifyPropertyChanged.OnPropertyChanged(nameof(this.Count));
            this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, value, index));
            this.notifyDictionaryChanged.OnDictionaryChanged(NotifyDictionaryChangedAction.Remove, key, value);
        }

        public bool TryGetValue(TKey key, out TValue value) => this.innerDictionary.TryGetValue(key, out value);
    }
}

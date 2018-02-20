using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere.ComponentModel;

namespace Yandere.Collections.ObjectModel
{
    [DebuggerDisplay("Count = {Count}")]
    public class ObservableSortedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>, IDictionary, ICollection, INotifyPropertyChanged, INotifyCollectionChanged
    {
        private SortedDictionary<TKey, ObservableCollectionItem<TValue>> innerDictionary;
        

        public TValue this[TKey key]
        {
            get => this.innerDictionary[key].Value;
            set
            {
                lock (((ICollection)this).SyncRoot)
                {
                    var oldItem = this.innerDictionary[key];
                    int index = oldItem.Index;
                    var newItem = new ObservableCollectionItem<TValue>(value);
                    this.innerDictionary[key] = newItem;

                    this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                        NotifyCollectionChangedAction.Replace,
                        new KeyValuePair<TKey, TValue>(key, value),
                        new KeyValuePair<TKey, TValue>(key, oldItem.Value),
                        index
                    ));
                }
            }
        }

        public ICollection<TKey> Keys => this.innerDictionary.Keys;
        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => this.Keys;
        ICollection IDictionary.Keys => (ICollection)this.Keys;
        
        private ValueCollection values;
        public ICollection<TValue> Values => this.values;
        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => this.Values;
        ICollection IDictionary.Values => (ICollection)this.Values;

        public int Count => this.innerDictionary.Count;

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)this.innerDictionary).IsReadOnly;
        bool IDictionary.IsReadOnly => ((IDictionary)this.innerDictionary).IsReadOnly;

        bool IDictionary.IsFixedSize => ((IDictionary)this.innerDictionary).IsFixedSize;

        object ICollection.SyncRoot => ((ICollection)this.innerDictionary).SyncRoot;

        bool ICollection.IsSynchronized => ((ICollection)this.innerDictionary).IsSynchronized;

        object IDictionary.this[object key]
        {
            get => this[(TKey)key];
            set=>this[(TKey)key]=(TValue) value;
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

        //
        // 摘要:
        //     初始化 System.Collections.Generic.SortedDictionary`2 类的一个新实例，该实例为空并对键类型使用默认 System.Collections.Generic.IComparer`1
        //     实现。
        public ObservableSortedDictionary()
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);
            
            this.innerDictionary = new SortedDictionary<TKey, ObservableCollectionItem<TValue>>();
            this.values = new ValueCollection(this);
            this.CollectionChanged += this.ObservableSortedDictionary_CollectionChanged;
        }

        //
        // 摘要:
        //     初始化 System.Collections.Generic.SortedDictionary`2 类的一个新实例，该实例为空并对比较键使用指定 System.Collections.Generic.IComparer`1
        //     实现。
        //
        // 参数:
        //   comparer:
        //     比较键时要使用的 System.Collections.Generic.IComparer`1 实现，或者为 null，以便为键类型使用默认的 System.Collections.Generic.Comparer`1。
        public ObservableSortedDictionary(IComparer<TKey> comparer)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);

            this.innerDictionary = new SortedDictionary<TKey, ObservableCollectionItem<TValue>>(comparer);
            this.values = new ValueCollection(this);
            this.CollectionChanged += this.ObservableSortedDictionary_CollectionChanged;
        }
        //
        // 摘要:
        //     初始化 System.Collections.Generic.SortedDictionary`2 类的新实例，该实例包含从指定的 System.Collections.Generic.IDictionary`2
        //     中复制的元素，并使用键类型的默认 System.Collections.Generic.IComparer`1 实现。
        //
        // 参数:
        //   dictionary:
        //     System.Collections.Generic.IDictionary`2，它的元素被复制到新 System.Collections.Generic.SortedDictionary`2。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     dictionary 为 null。
        //
        //   T:System.ArgumentException:
        //     dictionary 包含一个或多个重复的键。
        public ObservableSortedDictionary(IDictionary<TKey, ObservableCollectionItem<TValue>> dictionary)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);

            this.innerDictionary = new SortedDictionary<TKey, ObservableCollectionItem<TValue>>(dictionary);
            this.values = new ValueCollection(this);
            this.CollectionChanged += this.ObservableSortedDictionary_CollectionChanged;
        }
        //
        // 摘要:
        //     初始化 System.Collections.Generic.SortedDictionary`2 类的新实例，该实例包含从指定的 System.Collections.Generic.IDictionary`2
        //     中复制的元素，并使用指定的 System.Collections.Generic.IComparer`1 实现来比较键。
        //
        // 参数:
        //   dictionary:
        //     System.Collections.Generic.IDictionary`2，它的元素被复制到新 System.Collections.Generic.SortedDictionary`2。
        //
        //   comparer:
        //     比较键时要使用的 System.Collections.Generic.IComparer`1 实现，或者为 null，以便为键类型使用默认的 System.Collections.Generic.Comparer`1。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     dictionary 为 null。
        //
        //   T:System.ArgumentException:
        //     dictionary 包含一个或多个重复的键。
        public ObservableSortedDictionary(IDictionary<TKey, ObservableCollectionItem<TValue>> dictionary, IComparer<TKey> comparer)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.notifyCollectionChanged = new NotifyCollectionChanged(this);

            this.innerDictionary = new SortedDictionary<TKey, ObservableCollectionItem<TValue>>(dictionary, comparer);
            this.values = new ValueCollection(this);
            this.CollectionChanged += this.ObservableSortedDictionary_CollectionChanged;
        }

        private void ObservableSortedDictionary_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            void UpdateIndexes(int start, int count = int.MaxValue)
            {
                lock (((ICollection)this).SyncRoot)
                {
                    int end = Math.Min(start + count, this.Count);
                    int i = 0;
                    foreach (var pair in this.innerDictionary)
                    {
                        if (i >= end) break;

                        if (i >= start)
                            pair.Value.Index = i;

                        i++;
                    }
                }
            }
            void NotifyItemPropertyChanged() => this.notifyPropertyChanged.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            void NotifyCountPropertyChanged()
            {
                this.notifyPropertyChanged.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.Count)));
                NotifyItemPropertyChanged();
            }

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    UpdateIndexes(e.NewStartingIndex);
                    NotifyCountPropertyChanged();
                    break;
                case NotifyCollectionChangedAction.Remove:
                    UpdateIndexes(e.OldStartingIndex);
                    NotifyCountPropertyChanged();
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldItems.Count == e.NewItems.Count)
                    {
                        UpdateIndexes(e.NewStartingIndex, e.NewItems.Count);
                        NotifyItemPropertyChanged();
                    }
                    else
                    {
                        UpdateIndexes(e.NewStartingIndex);
                        NotifyCountPropertyChanged();
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                case NotifyCollectionChangedAction.Reset:
                    NotifyItemPropertyChanged();
                    break;
            }
        }

        public void Add(TKey key, TValue value) => this.AddInternal(key, value);

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item) => this.AddInternal(item.Key, item.Value);
        void IDictionary.Add(object key, object value) => this.Add((TKey)key, (TValue)value);
        
        private void AddInternal(TKey key, TValue value)
        {
            var item = new ObservableCollectionItem<TValue>(value);
            this.innerDictionary.Add(key, item);

            int index = 0;
            foreach (var pair in this.innerDictionary)
            {
                if (pair.Value == item)
                    this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                        NotifyCollectionChangedAction.Add,
                        new KeyValuePair<TKey, TValue>(key, value),
                        index
                    ));
                else
                    index++;
            }
        }

        public void Clear()
        {
            if (this.innerDictionary.Count == 0) return;

            this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) =>
            this.ContainsKey(item.Key) &&
            this.innerDictionary.Any(pair => EqualityComparer<TValue>.Default.Equals(item.Value, pair.Value.Value));
        bool IDictionary.Contains(object key) => this.ContainsKey((TKey)key);
        
        public bool ContainsKey(TKey key) => this.innerDictionary.Any(pair => this.innerDictionary.Comparer.Compare(key, pair.Key) == 0);

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            KeyValuePair<TKey, ObservableCollectionItem<TValue>>[] itemArray = new KeyValuePair<TKey, ObservableCollectionItem<TValue>>[array.Length];
            this.innerDictionary.CopyTo(itemArray, arrayIndex);
            for (int i = arrayIndex; i < this.innerDictionary.Count; i++)
            {
                var item = itemArray[i];
                array[i] = new KeyValuePair<TKey, TValue>(item.Key, item.Value.Value);
            }
        }
        void ICollection.CopyTo(Array array, int index)
        {
            KeyValuePair<TKey, ObservableCollectionItem<TValue>>[] itemArray = new KeyValuePair<TKey, ObservableCollectionItem<TValue>>[this.Count];
            this.innerDictionary.CopyTo(itemArray, 0);
            KeyValuePair<TKey, TValue>[] pairArray = new KeyValuePair<TKey, TValue>[this.Count];
            for (int i = 0; i < this.innerDictionary.Count; i++)
            {
                var item = itemArray[i];
                pairArray[i] = new KeyValuePair<TKey, TValue>(item.Key, item.Value.Value);
            }
            Array.Copy(pairArray, array, this.Count - index);
        }

        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => this.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        IDictionaryEnumerator IDictionary.GetEnumerator() => this.GetEnumerator();
        
        public bool Remove(TKey key) => this.RemoveInternal(key);

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if (((ICollection<KeyValuePair<TKey, TValue>>)this).Contains(item))
                return this.RemoveInternal(item.Key);
            else return false;
        }
        void IDictionary.Remove(object key) => this.Remove((TKey)key);
        
        private bool RemoveInternal(TKey key)
        {
            if (!this.innerDictionary.TryGetValue(key, out ObservableCollectionItem<TValue> item)) return false;
            if (!this.innerDictionary.Remove(key)) return false;
            
            int index = item.Index;
            this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Remove,
                new KeyValuePair<TKey, TValue>(key, item.Value),
                index
            ));

            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            bool result = this.innerDictionary.TryGetValue(key, out ObservableCollectionItem<TValue> item);
            value = item.Value;
            return result;
        }

        public class Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator
        {
            private ObservableSortedDictionary<TKey, TValue> dictionary;
            private SortedDictionary<TKey, ObservableCollectionItem<TValue>>.Enumerator enumerator;

            public KeyValuePair<TKey, TValue> Current
            {
                get
                {
                    var pair = this.enumerator.Current;
                    return new KeyValuePair<TKey, TValue>(pair.Key, pair.Value.Value);
                }
            }

            object IEnumerator.Current => this.Current;

            object IDictionaryEnumerator.Key => this.enumerator.Current.Key;

            object IDictionaryEnumerator.Value => this.enumerator.Current.Value.Value;

            DictionaryEntry IDictionaryEnumerator.Entry
            {
                get
                {
                    var pair = this.enumerator.Current;
                    return new DictionaryEntry(pair.Key, pair.Value.Value);
                }
            }

            public Enumerator(ObservableSortedDictionary<TKey, TValue> dictionary)
            {
                this.dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

                this.Reset();
            }

            public bool MoveNext() => this.enumerator.MoveNext();

            public void Reset() => this.enumerator = this.dictionary.innerDictionary.GetEnumerator();

            #region IDisposable Support
            private bool disposedValue = false; // 要检测冗余调用

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: 释放托管状态(托管对象)。
                    }

                    // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                    // TODO: 将大型字段设置为 null。

                    disposedValue = true;
                }
            }

            // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
            // ~Enumerator() {
            //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            //   Dispose(false);
            // }

            // 添加此代码以正确实现可处置模式。
            void IDisposable.Dispose()
            {
                // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
                Dispose(true);
                // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
                // GC.SuppressFinalize(this);
            }
            #endregion
        }

        private class ValueCollection : ICollection<TValue>, IReadOnlyCollection<TValue>, ICollection
        {
            private ObservableSortedDictionary<TKey, TValue> dictionary;
            
            public ValueCollection(ObservableSortedDictionary<TKey, TValue> dictionary) =>
                this.dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

            public int Count => this.dictionary.innerDictionary.Values.Count;

            public bool IsReadOnly => true;

            object ICollection.SyncRoot => ((ICollection)this.dictionary.innerDictionary.Values).SyncRoot;

            bool ICollection.IsSynchronized => ((ICollection)this.dictionary.innerDictionary.Values).IsSynchronized;

            public void Add(TValue item) => throw new NotSupportedException();

            public void Clear() => throw new NotSupportedException();

            public bool Contains(TValue item) => this.dictionary.innerDictionary.Values.Any(_item => EqualityComparer<TValue>.Default.Equals(item, _item.Value));

            public void CopyTo(TValue[] array, int arrayIndex)
            {
                ObservableCollectionItem<TValue>[] itemArray = new ObservableCollectionItem<TValue>[array.Length];
                this.dictionary.innerDictionary.Values.CopyTo(itemArray, arrayIndex);
                for (int i = arrayIndex; i < this.dictionary.innerDictionary.Count; i++)
                    array[i] = itemArray[i].Value;
            }

            public IEnumerator<TValue> GetEnumerator()
            {
                foreach (var item in this.dictionary.innerDictionary.Values)
                    yield return item.Value;
            }

            public bool Remove(TValue item) => throw new NotSupportedException();

            void ICollection.CopyTo(Array array, int index)
            {
                TValue[] valueArray = new TValue[this.Count];
                this.CopyTo(valueArray, 0);
                Array.Copy(valueArray, array, this.Count - index);
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}

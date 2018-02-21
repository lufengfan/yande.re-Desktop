using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere.Collections.Specialized;
using Yandere.ComponentModel;

namespace Yandere.Collections.ObjectModel
{
    public class ObservableCountedList<T> : ObservableCollection<T>, ICountedCollection<T>, ICountedCollection
    {
        private Dictionary<T, int> countDictionary;
        private int nullCount = 0;

        private ItemCountsCollection itemCounts;
        public ItemCountsCollection ItemCounts => this.itemCounts;
        IItemCounts<T> ICountedCollection<T>.ItemCounts => this.itemCounts;
        IItemCounts ICountedCollection.ItemCounts => this.itemCounts;

        protected NotifyPropertyChanged notifyPropertyChanged;
        protected NotifyCollectionChanged notifyCollectionChanged;
        protected NotifyDictionaryChanged<T, int> notifyDictionaryChanged;

        public ObservableCountedList()
        {
            this.itemCounts = new ItemCountsCollection(this);

            this.notifyPropertyChanged = new NotifyPropertyChanged(this.itemCounts);
            this.notifyCollectionChanged = new ItemCountsCollection._NotifyCollectionChanged(this.itemCounts);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<T, int>(this.itemCounts);

            this.countDictionary = new Dictionary<T, int>();
        }

        public ObservableCountedList(int capacity)
        {
            this.itemCounts = new ItemCountsCollection(this);

            this.notifyPropertyChanged = new NotifyPropertyChanged(this.itemCounts);
            this.notifyCollectionChanged = new ItemCountsCollection._NotifyCollectionChanged(this.itemCounts);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<T, int>(this.itemCounts);

            this.countDictionary = new Dictionary<T, int>(capacity);
        }

        public ObservableCountedList(IEqualityComparer<T> comparer)
        {
            this.itemCounts = new ItemCountsCollection(this);

            this.notifyPropertyChanged = new NotifyPropertyChanged(this.itemCounts);
            this.notifyCollectionChanged = new ItemCountsCollection._NotifyCollectionChanged(this.itemCounts);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<T, int>(this.itemCounts);

            this.countDictionary = new Dictionary<T, int>(comparer);
        }

        public ObservableCountedList(IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default) { }

        public ObservableCountedList(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));
            
            if (!typeof(T).IsValueType)
            {
                this.nullCount = collection.Where(item => (object)item is null).Count();
                collection = collection.Where(item => !((object)item is null));
            }

            this.itemCounts = new ItemCountsCollection(this);

            this.notifyPropertyChanged = new NotifyPropertyChanged(this.itemCounts);
            this.notifyCollectionChanged = new ItemCountsCollection._NotifyCollectionChanged(this.itemCounts);
            this.notifyDictionaryChanged = new NotifyDictionaryChanged<T, int>(this.itemCounts);

            this.countDictionary = new Dictionary<T, int>(
                collection.GroupBy(
                    keySelector: item => item,
                    comparer: comparer
                )
                    .ToDictionary(
                        keySelector: group => group.Key,
                        elementSelector: group => group.Count()
                    )
            );
        }

        protected override void ClearItems()
        {
            this.CheckReentrancy();
            this.countDictionary.Clear();
            this.nullCount = 0; 

            base.ClearItems();
            
            this.notifyPropertyChanged.OnPropertyChanged(nameof(ItemCountsCollection.Count));
            this.notifyPropertyChanged.OnPropertyChanged("Item[]");
            this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            this.notifyDictionaryChanged.OnDictionaryChanged(NotifyDictionaryChangedAction.Reset);
        }

        protected override void InsertItem(int index, T item) => this.InsertItem(index, item, 1);
        
        protected virtual void InsertItem(int index, T item, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), count, "参数值必须大于或等于零。");

            int newCount;
            if (this.Contains(item))
                newCount = this.countDictionary[item] += count;
            else
            {
                this.countDictionary.Add(item, count);
                newCount = count;

                base.InsertItem(index, item);
                
                this.notifyPropertyChanged.OnPropertyChanged(nameof(ItemCountsCollection.Count));
                this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
            }

            this.notifyPropertyChanged.OnPropertyChanged("Item[]");
            this.notifyDictionaryChanged.OnDictionaryChanged(NotifyDictionaryChangedAction.Add, item, newCount);
        }

        protected override void RemoveItem(int index)
        {
            this.CheckReentrancy();
            T item = this[index];
            int oldCount = this.countDictionary[item];
            this.countDictionary.Remove(item);

            base.RemoveItem(index);

            this.notifyPropertyChanged.OnPropertyChanged(nameof(ItemCountsCollection.Count));
            this.notifyPropertyChanged.OnPropertyChanged("Item[]");
            this.notifyCollectionChanged.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
            this.notifyDictionaryChanged.OnDictionaryChanged(NotifyDictionaryChangedAction.Remove, item, oldCount);
        }

        protected override void SetItem(int index, T item)
        {
            int oldItemCount, newItemCount;
            if (this.Contains(item))
            {
                T oldItem = this[index];
                if (this.countDictionary.Comparer.Equals(oldItem, item))
                    return;
                else
                {
                    int accumulate = this.countDictionary[oldItem];
                    this.Remove(oldItem);
                    oldItemCount = this.countDictionary[item];
                    newItemCount = this.countDictionary[item] = oldItemCount + accumulate;
                }
            }
            else
            {
                T oldItem = this[index];
                oldItemCount = newItemCount = this.countDictionary[oldItem];
                this.Remove(oldItem);
                this.InsertItem(this.Count, item, newItemCount);

                this.SetItem(index, item);
            }

            this.notifyPropertyChanged.OnPropertyChanged("Item[]");
            this.notifyDictionaryChanged.OnDictionaryChanged(NotifyDictionaryChangedAction.Replace, item, oldItemCount, newItemCount);
        }
        
        public class ItemCountsCollection : IItemCounts<T>, IItemCounts, INotifyPropertyChanged, INotifyCollectionChanged, INotifyDictionaryChanged<T, int>
        {
            private ObservableCountedList<T> innerList;

            internal ItemCountsCollection(ObservableCountedList<T> list)
            {
                this.items = new ItemsCollection(this);

                this.innerList = list ?? throw new ArgumentNullException(nameof(list));
            }
            
            event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
            {
                add => this.innerList.notifyPropertyChanged.PropertyChanged += value;
                remove => this.innerList.notifyPropertyChanged.PropertyChanged -= value;
            }

            event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
            {
                add => this.innerList.notifyCollectionChanged.CollectionChanged += value;
                remove => this.innerList.notifyCollectionChanged.CollectionChanged -= value;
            }

            event NotifyDictionaryChangedEventHandler<T, int> INotifyDictionaryChanged<T, int>.DictionaryChanged
            {
                add => this.innerList.notifyDictionaryChanged.DictionaryChanged += value;
                remove => this.innerList.notifyDictionaryChanged.DictionaryChanged -= value;
            }

            public int this[T item]
            {
                get
                {
                    if (!typeof(T).IsValueType && (object)item is null)
                        return this.innerList.nullCount;
                    else
                        return this.innerList.countDictionary[item];
                }
            }
            object IReadOnlyDictionary.this[object key]=>this[(T)key];

            private ItemsCollection items;
            public ItemsCollection Items => this.items;
            IReadOnlyCollection<T> IItemCounts<T>.Items => this.items;
            IReadOnlyCollection IItemCounts.Items => this.items;
            IEnumerable IReadOnlyDictionary.Keys => this.items;
            IEnumerable<T> IReadOnlyDictionary<T, int>.Keys => this.items;

            public IReadOnlyCollection<int> Counts => this.innerList.countDictionary.Values;
            IEnumerable IReadOnlyDictionary.Values => this.innerList.countDictionary.Values;
            IEnumerable<int> IReadOnlyDictionary<T, int>.Values => this.innerList.countDictionary.Values;
            
            public int Count => this.innerList.countDictionary.Count;

            public bool ContainsItem(T item) => this.innerList.countDictionary.ContainsKey(item);
            bool IReadOnlyDictionary.Contains(object key) => this.ContainsItem((T)key);
            bool IReadOnlyDictionary<T, int>.ContainsKey(T key) => this.ContainsItem(key);

            IDictionaryEnumerator IReadOnlyDictionary.GetEnumerator() => new Enumerator(this.innerList, true);
            IEnumerator<KeyValuePair<T, int>> IEnumerable<KeyValuePair<T, int>>.GetEnumerator() => new Enumerator(this.innerList);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this.innerList);

            public bool TryGetCount(T item, out int count) => this.innerList.countDictionary.TryGetValue(item, out count);
            bool IReadOnlyDictionary<T, int>.TryGetValue(T key, out int value) => this.TryGetCount(key, out value);

            protected internal class _NotifyCollectionChanged : NotifyCollectionChanged
            {
                public _NotifyCollectionChanged(ItemCountsCollection itemCounts) : base(itemCounts ?? throw new ArgumentNullException(nameof(itemCounts))) { }

                public NotifyCollectionChangedEventArgs EventArgsSelector(NotifyCollectionChangedEventArgs e)
                {
                    IList ItemsSelector(IList items)
                    {
                        return items.Cast<object>().Select(item =>
                        {
                            if (item is T t)
                                return new CountedListItem<T>(t, ((ItemCountsCollection)this.Sender).innerList.countDictionary[t]);
                            else
                                return item;
                        })
                            .ToList();
                    }

                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, ItemsSelector(e.NewItems), e.NewStartingIndex);
                        case NotifyCollectionChangedAction.Move:
                            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, ItemsSelector(e.OldItems), e.NewStartingIndex, e.OldStartingIndex);
                        case NotifyCollectionChangedAction.Remove:
                            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, ItemsSelector(e.OldItems), e.OldStartingIndex);
                        case NotifyCollectionChangedAction.Replace:
                            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, ItemsSelector(e.NewItems), ItemsSelector(e.OldItems), e.OldStartingIndex);
                        case NotifyCollectionChangedAction.Reset:
                            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                        default:
                            throw new NotSupportedException();
                    }
                }

                public override void OnCollectionChanged(NotifyCollectionChangedEventArgs e) =>
                    base.OnCollectionChanged(this.EventArgsSelector(e));

                public override void OnCollectionChangedOverrideSender(object sender, NotifyCollectionChangedEventArgs e) =>
                    base.OnCollectionChangedOverrideSender(sender, this.EventArgsSelector(e));
            }

            public class ItemsCollection : IReadOnlyCollection<T>, IReadOnlyCollection
            {
                private ItemCountsCollection itemCounts;

                public ItemsCollection(ItemCountsCollection items) =>
                    this.itemCounts = items ?? throw new ArgumentNullException(nameof(items));

                public int Count => this.itemCounts.innerList.countDictionary.Count;

                public IEnumerator<T> GetEnumerator() => this.itemCounts.innerList.countDictionary.Keys.GetEnumerator();
                IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
            }

            public struct Enumerator : IEnumerator<KeyValuePair<T, int>>, IDictionaryEnumerator
            {
                private ObservableCountedList<T> innerList;
                private IEnumerator<T> enumerator;
                private bool getEnumeratorReturnDictionaryEntry;

                public KeyValuePair<T, int> Current
                {
                    get
                    {
                        T item = this.enumerator.Current;
                        int count = this.innerList.ItemCounts[item];
                        return new KeyValuePair<T, int>(item, count);
                    }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        var currentPair = this.Current;
                        if (this.getEnumeratorReturnDictionaryEntry)
                            return new DictionaryEntry(currentPair.Key, currentPair.Value);
                        else
                            return currentPair;
                    }
                }

                object IDictionaryEnumerator.Key => this.enumerator.Current;

                object IDictionaryEnumerator.Value => this.innerList.ItemCounts[this.enumerator.Current];

                DictionaryEntry IDictionaryEnumerator.Entry
                {
                    get
                    {
                        T item = this.enumerator.Current;
                        int count = this.innerList.ItemCounts[item];
                        return new DictionaryEntry(item, count);
                    }
                }

                internal Enumerator(ObservableCountedList<T> list, bool getEnumeratorReturnDictionaryEntry = false)
                {
                    this.innerList = list ?? throw new ArgumentNullException(nameof(list));
                    this.enumerator = null;
                    this.getEnumeratorReturnDictionaryEntry = getEnumeratorReturnDictionaryEntry;

                    this.disposedValue = false;

                    this.Reset();
                }
                
                public bool MoveNext() => this.enumerator.MoveNext();

                public void Reset() => this.enumerator = this.innerList.GetEnumerator();

                #region IDisposable Support
                private bool disposedValue; // 要检测冗余调用

                private void Dispose(bool disposing)
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
        }
    }

    public struct CountedListItem<T>
    {
        private T value;
        private int count;

        public T Value => this.value;
        public int Count => this.count;

        public CountedListItem(T value, int count)
        {
            this.value = value;
            this.count = count;
        }
    }
}

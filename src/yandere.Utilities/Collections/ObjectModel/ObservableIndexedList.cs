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
using Yandere;
using Yandere.ComponentModel;

namespace Yandere.Collections.ObjectModel
{
    [DebuggerDisplay("Count = {Count}")]
    public class ObservableIndexedList<T> : IList<ObservableIndexedListItem<T>>, IList<T>, IList, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private ObservableCollection<ObservableIndexedListItem<T>> collection;
        
        object IList.this[int index]
        {
            get => ((IList<ObservableIndexedListItem<T>>)this)[index];
            set => ((IList<ObservableIndexedListItem<T>>)this)[index] = value as ObservableIndexedListItem<T>;
        }
        ObservableIndexedListItem<T> IList<ObservableIndexedListItem<T>>.this[int index]
        {
            get => this.FindItemAt(index);
            set => this.ReplaceItemAt(index, value ?? throw new ArgumentNullException(nameof(value)));
        }

        public T this[int index]
        {
            get => ((IList<ObservableIndexedListItem<T>>)this)[index].Value;
            set => ((IList<ObservableIndexedListItem<T>>)this)[index] = new ObservableIndexedListItem<T>(value);
        }

        public int Count => this.collection.Count;

        bool IList.IsFixedSize => ((IList)this.collection).IsFixedSize;

        bool ICollection<T>.IsReadOnly => ((ICollection<ObservableIndexedListItem<T>>)this).IsReadOnly;
        bool ICollection<ObservableIndexedListItem<T>>.IsReadOnly => ((ICollection<ObservableIndexedListItem<T>>)this.collection).IsReadOnly;
        bool IList.IsReadOnly => ((IList)this.collection).IsReadOnly;

        object ICollection.SyncRoot => ((ICollection)this.collection).SyncRoot;

        bool ICollection.IsSynchronized => ((ICollection)this.collection).IsSynchronized;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected internal event PropertyChangedEventHandler PropertyChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.PropertyChanged += value;
            remove => this.PropertyChanged -= value;
        }

        public ObservableIndexedList()
        {
            this.collection = new ObservableCollection<ObservableIndexedListItem<T>>();
            
            this.collection.CollectionChanged += this.Collection_CollectionChanged;
            ((INotifyPropertyChanged)this.collection).PropertyChanged += (sender, e) => this.PropertyChanged?.Invoke(this, e);
        }

        public ObservableIndexedList(IEnumerable<T> collection) :
            this(
                (collection ?? throw new ArgumentNullException(nameof(collection)))
                    .Select(value => new ObservableIndexedListItem<T>(value))
            )
        { }

        internal ObservableIndexedList(IEnumerable<ObservableIndexedListItem<T>> collection) : this()
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection.Where(item => item != null))
                this.collection.Add(item);
        }

        private void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Reset:
                    if (e.OldItems != null)
                    {
                        foreach (ObservableIndexedListItem<T> item in e.OldItems)
                            item.list = null;
                    }

                    if (e.NewItems != null)
                    {
                        foreach (ObservableIndexedListItem<T> item in e.NewItems)
                        {
                            if (item.list == null)
                                item.list = this;
                            else if (item.list != this)
                                throw new InvalidOperationException("项已经包含在另一个列表中。");
                        }
                    }
                    break;
            }

            int i = 0;
            foreach (ObservableIndexedListItem<T> item in (IEnumerable<ObservableIndexedListItem<T>>)this)
                item.Index = i++;

            this.CollectionChanged?.Invoke(this, e);
        }

        private ObservableIndexedListItem<T> CheckValue(object value, Exception toThrow)
        {
            if (value is ObservableIndexedListItem<T>)
                return (ObservableIndexedListItem<T>)value;
            else
            {
                if (typeof(T).IsValueType && value == null)
                    throw toThrow;
                else
                    return new ObservableIndexedListItem<T>((T)value);
            }
        }
        
        int IList.Add(object value)
        {
            ObservableIndexedListItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            ((ICollection<ObservableIndexedListItem<T>>)this).Add(item);
            return this.Count;
        }

        void ICollection<ObservableIndexedListItem<T>>.Add(ObservableIndexedListItem<T> item) => this.collection.Add(item ?? throw new ArgumentNullException(nameof(item)));

        public void Add(T value) => this.collection.Add(new ObservableIndexedListItem<T>(value));

        public void Clear() => this.collection.Clear();

        bool IList.Contains(object value)
        {
            ObservableIndexedListItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            return ((ICollection<ObservableIndexedListItem<T>>)this).Contains(item);
        }

        bool ICollection<ObservableIndexedListItem<T>>.Contains(ObservableIndexedListItem<T> item) => this.collection.Contains(item ?? throw new ArgumentNullException(nameof(item)));

        public bool Contains(T value) => this.IndexOf(value) != -1;

        void ICollection.CopyTo(Array array, int index) => ((ICollection)this.collection).CopyTo(array, index);

        void ICollection<ObservableIndexedListItem<T>>.CopyTo(ObservableIndexedListItem<T>[] array, int arrayIndex) => this.collection.CopyTo(array, arrayIndex);

        public void CopyTo(T[] array, int arrayIndex)
        {
            ObservableIndexedListItem<T>[] itemArray;
            if (array != null)
                itemArray = new ObservableIndexedListItem<T>[array.Length];
            else
                itemArray = null;

            this.collection.CopyTo(itemArray, arrayIndex);
            for (int i = arrayIndex; i < array.Length && i < (arrayIndex + this.Count); i++)
                array[i] = itemArray[i].Value;
        }

        public T FindAt(int index) => this.FindItemAt(index).Value;

        internal ObservableIndexedListItem<T> FindItemAt(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentOutOfRangeException(nameof(index), index, "索引小于 0 或大于列表元素数。");

            foreach (var item in this.collection)
                if (item.Index == index)
                    return item;

            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.collection).GetEnumerator();

        IEnumerator<ObservableIndexedListItem<T>> IEnumerable<ObservableIndexedListItem<T>>.GetEnumerator() => ((IEnumerable<ObservableIndexedListItem<T>>)this.collection).GetEnumerator();

        public IEnumerator<T> GetEnumerator() => this.collection.Select(item => item.Value).GetEnumerator();

        int IList.IndexOf(object value)
        {
            ObservableIndexedListItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            return ((IList<ObservableIndexedListItem<T>>)this).IndexOf(item);
        }

        int IList<ObservableIndexedListItem<T>>.IndexOf(ObservableIndexedListItem<T> item) => this.collection.IndexOf(item ?? throw new ArgumentNullException(nameof(item)));

        public int IndexOf(T item)
        {
            int index = 0;
            IEqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
            foreach (T _item in this)
            {
                if (equalityComparer.Equals(item, _item))
                    return index;
            }

            return -1;
        }

        void IList.Insert(int index, object value)
        {
            ObservableIndexedListItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            ((IList<ObservableIndexedListItem<T>>)this).Insert(index, item);
        }

        void IList<ObservableIndexedListItem<T>>.Insert(int index, ObservableIndexedListItem<T> item) => this.collection.Insert(index, item ?? throw new ArgumentNullException(nameof(item)));

        public void Insert(int index, T item) => this.collection.Insert(index, new ObservableIndexedListItem<T>(item));

        void IList.Remove(object value)
        {
            ObservableIndexedListItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            ((ICollection<ObservableIndexedListItem<T>>)this).Remove(item);
        }

        bool ICollection<ObservableIndexedListItem<T>>.Remove(ObservableIndexedListItem<T> item) => this.collection.Remove(item);

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index == -1)
                return false;
            else
            {
                this.RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index) => this.collection.Remove(this.FindItemAt(index));

        public void ReplaceItemAt(int index, ObservableIndexedListItem<T> item)
        {
            if (index == this.Count)
                ((ICollection<ObservableIndexedListItem<T>>)this).Add(item);
            else
            {
                if (index > this.Count) throw new ArgumentOutOfRangeException(nameof(index), index, "索引大于列表元素数。");
                if (item == null) throw new ArgumentNullException(nameof(item));

                this.collection.Insert(index, item);
                this.collection.RemoveAt(index + 1);
            }
        }
    }

    public class ObservableIndexedListItem<T> : INotifyPropertyChanged
    {
        internal ObservableIndexedList<T> list;

        private ValueBox<int> indexBox = ValueBox<int>.NonValue;
        public int Index
        {
            get => this.indexBox.HasValue ? this.indexBox.Value : 0;
            internal set
            {
                if (!this.indexBox.HasValue || this.indexBox.Value != value)
                {
                    this.indexBox.Value = value;
                    this.notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        private ValueBox<T> valueBox;
        public T Value
        {
            get => this.valueBox.HasValue ? this.valueBox.Value : default(T);
            set {
                if (!this.valueBox.HasValue || !EqualityComparer<T>.Default.Equals(this.valueBox.Value, value))
                {
                    this.valueBox.Value = value;
                    this.notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        private NotifyPropertyChanged notifyPropertyChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.notifyPropertyChanged.PropertyChanged += value;
            remove => this.notifyPropertyChanged.PropertyChanged -= value;
        }

        public ObservableIndexedListItem()
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.valueBox = ValueBox<T>.NonValue;
        }

        public ObservableIndexedListItem(T value) : this() => this.valueBox.Value = value;
    }
}

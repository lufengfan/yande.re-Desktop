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

namespace Yandere.Collections.ObjectModel
{
    [DebuggerDisplay("Count = {Count}")]
    public class ObservableIndexedList<T> : IList<ObservableCollectionItem<T>>, IList<T>, IList, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private ObservableCollection<ObservableCollectionItem<T>> collection;
        
        object IList.this[int index]
        {
            get => ((IList<ObservableCollectionItem<T>>)this)[index];
            set => ((IList<ObservableCollectionItem<T>>)this)[index] = value as ObservableCollectionItem<T>;
        }
        ObservableCollectionItem<T> IList<ObservableCollectionItem<T>>.this[int index]
        {
            get => this.FindItemAt(index);
            set => this.ReplaceItemAt(index, value ?? throw new ArgumentNullException(nameof(value)));
        }

        public T this[int index]
        {
            get => ((IList<ObservableCollectionItem<T>>)this)[index].Value;
            set => ((IList<ObservableCollectionItem<T>>)this)[index] = new ObservableCollectionItem<T>(value);
        }

        public int Count => this.collection.Count;

        bool IList.IsFixedSize => ((IList)this.collection).IsFixedSize;

        bool ICollection<T>.IsReadOnly => ((ICollection<ObservableCollectionItem<T>>)this).IsReadOnly;
        bool ICollection<ObservableCollectionItem<T>>.IsReadOnly => ((ICollection<ObservableCollectionItem<T>>)this.collection).IsReadOnly;
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
            this.collection = new ObservableCollection<ObservableCollectionItem<T>>();
            
            this.collection.CollectionChanged += this.Collection_CollectionChanged;
            ((INotifyPropertyChanged)this.collection).PropertyChanged += (sender, e) => this.PropertyChanged?.Invoke(this, e);
        }

        public ObservableIndexedList(IEnumerable<T> collection) :
            this(
                (collection ?? throw new ArgumentNullException(nameof(collection)))
                    .Select(value => new ObservableCollectionItem<T>(value))
            )
        { }

        internal ObservableIndexedList(IEnumerable<ObservableCollectionItem<T>> collection) : this()
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
                        foreach (ObservableCollectionItem<T> item in e.OldItems)
                            item.owner = null;
                    }

                    if (e.NewItems != null)
                    {
                        foreach (ObservableCollectionItem<T> item in e.NewItems)
                        {
                            if (item.owner == null)
                                item.owner = this;
                            else if (item.owner != this)
                                throw new InvalidOperationException("项已经包含在另一个列表中。");
                        }
                    }
                    break;
            }

            int i = 0;
            foreach (ObservableCollectionItem<T> item in (IEnumerable<ObservableCollectionItem<T>>)this)
                item.Index = i++;

            this.CollectionChanged?.Invoke(this, e);
        }

        private ObservableCollectionItem<T> CheckValue(object value, Exception toThrow)
        {
            if (value is ObservableCollectionItem<T>)
                return (ObservableCollectionItem<T>)value;
            else
            {
                if (typeof(T).IsValueType && value == null)
                    throw toThrow;
                else
                    return new ObservableCollectionItem<T>((T)value);
            }
        }
        
        int IList.Add(object value)
        {
            ObservableCollectionItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            ((ICollection<ObservableCollectionItem<T>>)this).Add(item);
            return this.Count;
        }

        void ICollection<ObservableCollectionItem<T>>.Add(ObservableCollectionItem<T> item) => this.collection.Add(item ?? throw new ArgumentNullException(nameof(item)));

        public void Add(T value) => this.collection.Add(new ObservableCollectionItem<T>(value));

        public void Clear() => this.collection.Clear();

        bool IList.Contains(object value)
        {
            ObservableCollectionItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            return ((ICollection<ObservableCollectionItem<T>>)this).Contains(item);
        }

        bool ICollection<ObservableCollectionItem<T>>.Contains(ObservableCollectionItem<T> item) => this.collection.Contains(item ?? throw new ArgumentNullException(nameof(item)));

        public bool Contains(T value) => this.IndexOf(value) != -1;

        void ICollection.CopyTo(Array array, int index) => ((ICollection)this.collection).CopyTo(array, index);

        void ICollection<ObservableCollectionItem<T>>.CopyTo(ObservableCollectionItem<T>[] array, int arrayIndex) => this.collection.CopyTo(array, arrayIndex);

        public void CopyTo(T[] array, int arrayIndex)
        {
            ObservableCollectionItem<T>[] itemArray;
            if (array != null)
                itemArray = new ObservableCollectionItem<T>[array.Length];
            else
                itemArray = null;

            this.collection.CopyTo(itemArray, arrayIndex);
            for (int i = arrayIndex; i < array.Length && i < (arrayIndex + this.Count); i++)
                array[i] = itemArray[i].Value;
        }

        public T FindAt(int index) => this.FindItemAt(index).Value;

        internal ObservableCollectionItem<T> FindItemAt(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentOutOfRangeException(nameof(index), index, "索引小于 0 或大于列表元素数。");

            foreach (var item in this.collection)
                if (item.Index == index)
                    return item;

            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.collection).GetEnumerator();

        IEnumerator<ObservableCollectionItem<T>> IEnumerable<ObservableCollectionItem<T>>.GetEnumerator() => ((IEnumerable<ObservableCollectionItem<T>>)this.collection).GetEnumerator();

        public IEnumerator<T> GetEnumerator() => this.collection.Select(item => item.Value).GetEnumerator();

        int IList.IndexOf(object value)
        {
            ObservableCollectionItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            return ((IList<ObservableCollectionItem<T>>)this).IndexOf(item);
        }

        int IList<ObservableCollectionItem<T>>.IndexOf(ObservableCollectionItem<T> item) => this.collection.IndexOf(item ?? throw new ArgumentNullException(nameof(item)));

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
            ObservableCollectionItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            ((IList<ObservableCollectionItem<T>>)this).Insert(index, item);
        }

        void IList<ObservableCollectionItem<T>>.Insert(int index, ObservableCollectionItem<T> item) => this.collection.Insert(index, item ?? throw new ArgumentNullException(nameof(item)));

        public void Insert(int index, T item) => this.collection.Insert(index, new ObservableCollectionItem<T>(item));

        void IList.Remove(object value)
        {
            ObservableCollectionItem<T> item = this.CheckValue(value, new ArgumentNullException(nameof(value)));
            ((ICollection<ObservableCollectionItem<T>>)this).Remove(item);
        }

        bool ICollection<ObservableCollectionItem<T>>.Remove(ObservableCollectionItem<T> item) => this.collection.Remove(item);

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

        public void ReplaceItemAt(int index, ObservableCollectionItem<T> item)
        {
            if (index == this.Count)
                ((ICollection<ObservableCollectionItem<T>>)this).Add(item);
            else
            {
                if (index > this.Count) throw new ArgumentOutOfRangeException(nameof(index), index, "索引大于列表元素数。");
                if (item == null) throw new ArgumentNullException(nameof(item));

                this.collection.Insert(index, item);
                this.collection.RemoveAt(index + 1);
            }
        }
    }
}

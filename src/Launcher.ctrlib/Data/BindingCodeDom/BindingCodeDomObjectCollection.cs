using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Launcher.Data.BindingCodeDom
{
    [DebuggerDisplay("Count = {Count}")]
    public class BindingCodeDomObjectCollection : IList<BindingCodeDomObject>, IList
    {
        private List<BindingCodeDomObject> innerList;
        internal int pointer = 0;
        
        public int Count => this.innerList.Count;

        public bool IsReadOnly => ((IList)this.innerList).IsReadOnly;

        public BindingCodeDomObject this[int index]
        {
            get => this.innerList[index];
            set => this.innerList[index] = value ?? throw new ArgumentNullException(nameof(value));
        }

        public BindingCodeDomObjectCollection() => this.innerList = new List<BindingCodeDomObject>();
        public BindingCodeDomObjectCollection(int capacity) => this.innerList = new List<BindingCodeDomObject>(capacity);
        public BindingCodeDomObjectCollection(IEnumerable<BindingCodeDomObject> collection) =>
            this.innerList = new List<BindingCodeDomObject>(collection?.Where(item => item != null));

        public virtual void Reset()
        {
            this.pointer = 0;
        }

        public void SkipItemCount(int count)
        {
            if (count == 0) return;
            else if (count > 0)
            {
                if (this.innerList.Count - this.pointer <= count)
                    this.pointer = this.innerList.Count;
                else
                    this.pointer += count;
            }
            else
            {
                if (this.pointer >= count)
                    this.pointer -= count;
                else
                    this.pointer = 0;
            }
        }

        public void Add(BindingCodeDomObject item) => this.innerList.Add(item ?? throw new ArgumentNullException(nameof(item)));

        public void Clear() => this.innerList.Clear();

        public bool Contains(BindingCodeDomObject item) => this.innerList.Contains(item ?? throw new ArgumentNullException(nameof(item)));

        public void CopyTo(BindingCodeDomObject[] array, int arrayIndex) => this.innerList.CopyTo(array, arrayIndex);

        public int IndexOf(BindingCodeDomObject item) => this.innerList.IndexOf(item ?? throw new ArgumentNullException(nameof(item)));

        public void Insert(int index, BindingCodeDomObject item) => this.innerList.Insert(index, item ?? throw new ArgumentNullException(nameof(item)));

        public void RemoveAt(int index) => this.innerList.RemoveAt(index);

        public bool Remove(BindingCodeDomObject item) => this.innerList.Remove(item ?? throw new ArgumentNullException(nameof(item)));

        public IEnumerator<BindingCodeDomObject> GetEnumerator() => this.innerList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        bool IList.IsFixedSize => ((IList)this.innerList).IsFixedSize;

        object ICollection.SyncRoot => ((ICollection)this.innerList).SyncRoot;

        bool ICollection.IsSynchronized => ((ICollection)this.innerList).IsSynchronized;

        object IList.this[int index]
        {
            get => this[index];
            set => this[index] = value as BindingCodeDomObject;
        }

        internal static BindingCodeDomObject ConvertToBindingCodeDomObject(object value)
        {
            if (value is BindingCodeDomObject)
                return value as BindingCodeDomObject;
            else
                return new BindingCodeDomPrimitiveValue() { Value = value };
        }

        int IList.Add(object value)
        {
            this.Add(BindingCodeDomObjectCollection.ConvertToBindingCodeDomObject(value));
            return this.Count;
        }

        bool IList.Contains(object value) => this.Contains(BindingCodeDomObjectCollection.ConvertToBindingCodeDomObject(value));

        int IList.IndexOf(object value) => this.IndexOf(BindingCodeDomObjectCollection.ConvertToBindingCodeDomObject(value));

        void IList.Insert(int index, object value) => this.Insert(index, BindingCodeDomObjectCollection.ConvertToBindingCodeDomObject(value));

        void IList.Remove(object value) => this.Remove(BindingCodeDomObjectCollection.ConvertToBindingCodeDomObject(value));

        void ICollection.CopyTo(Array array, int index) => ((ICollection)this.innerList).CopyTo(array, index);
    }
}

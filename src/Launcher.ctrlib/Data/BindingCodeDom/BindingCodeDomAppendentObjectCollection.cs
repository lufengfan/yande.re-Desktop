using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Data.BindingCodeDom
{
    public class BindingCodeDomAppendentObjectCollection : IList<BindingCodeDomAppendentObject>
    {
        private List<BindingCodeDomAppendentObject> innerList;

        public BindingCodeDomAppendentObjectCollection() => this.innerList = new List<BindingCodeDomAppendentObject>();
        public BindingCodeDomAppendentObjectCollection(int capacity) => this.innerList = new List<BindingCodeDomAppendentObject>(capacity);
        public BindingCodeDomAppendentObjectCollection(IEnumerable<BindingCodeDomAppendentObject> collection) => this.innerList = new List<BindingCodeDomAppendentObject>(collection ?? throw new ArgumentNullException(nameof(collection)));

        public BindingCodeDomAppendentObject this[int index]
        {
            get => this.innerList[index];
            set => this.innerList[index] = value;
        }

        public int Count => this.innerList.Count;

        public bool IsReadOnly => ((ICollection<BindingCodeDomAppendentObject>)this.innerList).IsReadOnly;

        public void Add(BindingCodeDomAppendentObject item) => this.innerList.Add(item);

        public void Clear() => this.innerList.Clear();

        public bool Contains(BindingCodeDomAppendentObject item) => this.innerList.Contains(item);

        public void CopyTo(BindingCodeDomAppendentObject[] array, int arrayIndex) => this.innerList.CopyTo(array, arrayIndex);

        public IEnumerator<BindingCodeDomAppendentObject> GetEnumerator() => this.innerList.GetEnumerator();

        public int IndexOf(BindingCodeDomAppendentObject item) => this.innerList.IndexOf(item);

        public void Insert(int index, BindingCodeDomAppendentObject item) => this.innerList.Insert(index, item);

        public bool Remove(BindingCodeDomAppendentObject item) => this.innerList.Remove(item);

        public void RemoveAt(int index) => this.innerList.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => this.innerList.GetEnumerator();
    }
}

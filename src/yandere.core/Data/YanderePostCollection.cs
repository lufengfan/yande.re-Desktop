using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YanderePostCollection : ICollection<YanderePost>
    {
        private ISet<YanderePost> set;

        public YanderePostCollection() => this.set = new HashSet<YanderePost>();

        public YanderePostCollection(IEnumerable<YanderePost> collection) =>
            this.set = new HashSet<YanderePost>(
                (collection ?? throw new ArgumentNullException(nameof(collection)))
                    .Where(Post => Post != null)
            );

        public int Count => this.set.Count;

        public bool IsReadOnly => this.set.IsReadOnly;

        public void Add(YanderePost item) =>
            this.set.Add(item ?? throw new ArgumentNullException(nameof(item)));

        public void Clear() => this.set.Clear();

        public bool Contains(YanderePost item) =>
            this.set.Contains(item ?? throw new ArgumentNullException(nameof(item)));

        public void CopyTo(YanderePost[] array, int arrayIndex) => this.set.CopyTo(array, arrayIndex);

        public IEnumerator<YanderePost> GetEnumerator() => this.set.GetEnumerator();

        public bool Remove(YanderePost item) =>
            this.set.Remove(item ?? throw new ArgumentNullException(nameof(item)));

        IEnumerator IEnumerable.GetEnumerator() => this.set.GetEnumerator();
    }
}

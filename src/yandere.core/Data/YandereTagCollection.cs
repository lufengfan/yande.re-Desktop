﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YandereTagCollection : ICollection<YandereTag>, IReadOnlyCollection<YandereTag>
    {
        private ISet<YandereTag> set;

        public YandereTagCollection() => this.set = new HashSet<YandereTag>();

        public YandereTagCollection(IEnumerable<YandereTag> collection) =>
            this.set = new HashSet<YandereTag>(
                (collection ?? throw new ArgumentNullException(nameof(collection)))
                    .Where(tag => tag != null)
            );

        public int Count => this.set.Count;

        public bool IsReadOnly => this.set.IsReadOnly;

        public void Add(YandereTag item) => 
            this.set.Add(item ?? throw new ArgumentNullException(nameof(item)));

        public void AddRange(IEnumerable<YandereTag> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
                if (item != null)
                    this.set.Add(item);
        }
        
        public void Clear() => this.set.Clear();

        public bool Contains(YandereTag item) =>
            this.set.Contains(item ?? throw new ArgumentNullException(nameof(item)));

        public void CopyTo(YandereTag[] array, int arrayIndex) => this.set.CopyTo(array, arrayIndex);

        public IEnumerator<YandereTag> GetEnumerator() => this.set.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.set.GetEnumerator();

        public bool Remove(YandereTag item) =>
            this.set.Remove(item ?? throw new ArgumentNullException(nameof(item)));

        public override string ToString() =>
            string.Join(" ", (IEnumerable<YandereTag>)this);

        public static YandereTagCollection Parse(string value)
        {
            YandereTagCollection collection = new YandereTagCollection();
            foreach (var tag in value.Split().Where(v => !string.IsNullOrWhiteSpace(v)).Select(v => YandereTag.Parse(v)))
                collection.Add(tag);

            return collection;
        }

        public static bool TryParse(string value, out YandereTagCollection collection)
        {
            try
            {
                collection = YandereTagCollection.Parse(value);
            }
            catch (Exception)
            {
                collection = null;
                return false;
            }

            return true;
        }
    }
}

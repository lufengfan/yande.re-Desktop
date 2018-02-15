using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereActionParameters : IReadOnlyDictionary<string, object>
    {
        private Dictionary<string, object> innerDictionary;

        public object this[string name]
        {
            get
            {
                if (name == null) throw new ArgumentNullException(nameof(name));

                if (this.innerDictionary.ContainsKey(name))
                    return this.innerDictionary[name];
                else if (this.DefaultParameters.ContainsKey(name))
                    return this.DefaultParameters[name];
                else
                    throw new KeyNotFoundException();
            }
            protected set
            {
                if (name == null) throw new ArgumentNullException(nameof(name));

                if (this.innerDictionary.ContainsKey(name))
                    this.innerDictionary[name] = value;
                else
                    this.AddParameter(name, value);
            }
        }

        public int Count => this.innerDictionary.Count;

        /// <summary>
        /// 获取默认的参数字典。
        /// </summary>
        protected IDictionary<string, object> DefaultParameters { get; } = new Dictionary<string, object>();
        
        public IReadOnlyCollection<string> Names => this.innerDictionary.Keys;
        IEnumerable<string> IReadOnlyDictionary<string, object>.Keys => this.Names;

        public IReadOnlyCollection<object> Values => this.innerDictionary.Values;
        IEnumerable<object> IReadOnlyDictionary<string, object>.Values => this.Values;

        public ICollection<YandereActionParameters> MergedParameters { get; } = new Collection<YandereActionParameters>();

        protected YandereActionParameters() => this.innerDictionary = new Dictionary<string, object>();

        protected YandereActionParameters(int capacity) => this.innerDictionary = new Dictionary<string, object>(capacity);

        protected YandereActionParameters(IDictionary<string, object> dictionary) :
            this((IEnumerable<KeyValuePair<string, object>>)(dictionary ?? throw new ArgumentNullException(nameof(dictionary))))
        { }

        protected YandereActionParameters(IEnumerable<KeyValuePair<string, object>> collection) =>
            this.innerDictionary = new Dictionary<string, object>(
                (collection ?? throw new ArgumentNullException(nameof(collection)))
                    .Where(pair => pair.Key != null)
                    .ToDictionary(
                        pair => pair.Key,
                        pair => pair.Value
                    )
            );

        protected void AddParameter(string name, object value) => this.innerDictionary.Add(name ?? throw new ArgumentNullException(nameof(name)), value);

        protected void Clear() => this.innerDictionary.Clear();

        public bool ContainsName(string name) => this.innerDictionary.ContainsKey(name) || this.DefaultParameters.ContainsKey(name);
        bool IReadOnlyDictionary<string, object>.ContainsKey(string key) => this.ContainsName(key);

        public IEnumerator<KeyValuePair<string, object>> GetAllParameters()
        {
            foreach (var pair in this.innerDictionary)
                yield return pair;

            foreach (var pair in this.DefaultParameters)
                if (!this.innerDictionary.ContainsKey(pair.Key))
                    yield return pair;

            foreach (var dictionary in this.MergedParameters)
                foreach (var pair in dictionary)
                    if (!this.ContainsName(pair.Key))
                        yield return pair;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            foreach (var pair in this.innerDictionary)
                yield return pair;
            
            foreach (var dictionary in this.MergedParameters)
                foreach (var pair in dictionary)
                    if (!this.ContainsName(pair.Key))
                        yield return pair;
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool IsParameterDefault(string name)
        {
            if (this.innerDictionary.ContainsKey(name))
                return false;
            else if (this.DefaultParameters.ContainsKey(name))
                return true;
            else
                throw new KeyNotFoundException();
        }

        protected bool RemoveParameter(string name) => this.innerDictionary.Remove(name);

        public bool TryGetValue(string name, out object value) => this.innerDictionary.TryGetValue(name, out value) || this.DefaultParameters.TryGetValue(name, out value);
    }
}

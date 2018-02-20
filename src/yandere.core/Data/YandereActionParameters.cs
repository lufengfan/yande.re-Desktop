using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    /// <summary>
    /// 为 <see cref="YandereAction"/> 提供参数。
    /// </summary>
    public abstract class YandereActionParameters : IReadOnlyDictionary<string, object>
    {
        private Dictionary<string, object> innerDictionary;

        public object this[string name]
        {
            get
            {
                if (name == null) throw new ArgumentNullException(nameof(name));

                return GetValue(name);
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

        /// <summary>
        /// 获取合并入该 <see cref="YandereActionParameters"/> 的 <see cref="YandereActionParameters"/> 集合。
        /// </summary>
        public ICollection<YandereActionParameters> MergedParameters { get; } = new Collection<YandereActionParameters>();

        /// <summary>
        /// 初始化 <see cref="YandereActionParameters"/> 的新实例，该实例为空。
        /// </summary>
        protected YandereActionParameters() => this.innerDictionary = new Dictionary<string, object>();

        /// <summary>
        /// 初始化 <see cref="YandereActionParameters"/> 的新实例，该实例为空，具有指定的初始容量。
        /// </summary>
        /// <param name="capacity"><see cref="YandereActionParameters"/> 包含的初始容量。</param>
        protected YandereActionParameters(int capacity) => this.innerDictionary = new Dictionary<string, object>(capacity);

        /// <summary>
        /// 初始化 <see cref="YandereActionParameters"/> 的新实例，该实例包含从指定的 <see cref="IDictionary{TKey, TValue}"/> 复制的值键对。
        /// </summary>
        /// <param name="dictionary">要复制到该 <see cref="YandereActionParameters"/> 实例的 <see cref="IDictionary{TKey, TValue}"/> ，其中为 <see langword="null"/> 的键将被忽略。</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> 的值为 <see langword="null"/> 。</exception>
        protected YandereActionParameters(IDictionary<string, object> dictionary) :
            this((IEnumerable<KeyValuePair<string, object>>)(dictionary ?? throw new ArgumentNullException(nameof(dictionary))))
        { }

        /// <summary>
        /// 初始化 <see cref="YandereActionParameters"/> 的新实例，该实例包含从指定的值键对集合。
        /// </summary>
        /// <param name="collection">要复制到该 <see cref="YandereActionParameters"/> 实例的值键对集合，其中为 <see langword="null"/> 的键将被忽略。</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> 的值为 <see langword="null"/> 。</exception>
        protected YandereActionParameters(IEnumerable<KeyValuePair<string, object>> collection) =>
            this.innerDictionary = new Dictionary<string, object>(
                (collection ?? throw new ArgumentNullException(nameof(collection)))
                    .Where(pair => pair.Key != null)
                    .ToDictionary(
                        pair => pair.Key,
                        pair => pair.Value
                    )
            );

        /// <summary>
        /// 将指定的参数添加到 <see cref="YandereActionParameters"/> 中。
        /// </summary>
        /// <param name="name">参数名。</param>
        /// <param name="value">参数值。</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> 的值为 <see langword="null"/> 。</exception>
        protected void AddParameter(string name, object value) => this.innerDictionary.Add(name ?? throw new ArgumentNullException(nameof(name)), value);

        /// <summary>
        /// 将所有参数从 <see cref="YandereActionParameters"/> 中移除。
        /// </summary>
        protected void Clear() => this.innerDictionary.Clear();

        /// <summary>
        /// 确定 <see cref="YandereActionParameters"/> 是否包含指定参数名。
        /// </summary>
        /// <param name="name">要确认的参数名。</param>
        /// <returns>如果 <see cref="YandereActionParameters"/> 包含指定名称的参数，则为 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        public bool ContainsName(string name) => this.innerDictionary.ContainsKey(name) || this.DefaultParameters.ContainsKey(name);
        bool IReadOnlyDictionary<string, object>.ContainsKey(string key) => this.ContainsName(key);

        /// <summary>
        /// 获取一个枚举器，枚举该 <see cref="YandereActionParameters"/> 的所有参数，包括默认参数以及合并的 <see cref="YandereActionParameters"/> 的所有参数。
        /// </summary>
        /// <returns>一个枚举器，枚举该 <see cref="YandereActionParameters"/> 的所有参数，包括默认参数以及合并的 <see cref="YandereActionParameters"/> 的所有参数。</returns>
        public IEnumerator<KeyValuePair<string, object>> GetAllParameters()
        {
            foreach (var pair in this.innerDictionary)
                yield return pair;

            foreach (var pair in this.DefaultParameters)
                if (!this.innerDictionary.ContainsKey(pair.Key))
                    yield return pair;

            foreach (var dictionary in this.MergedParameters)
            {
                var enumerator = dictionary.GetAllParameters();
                while (enumerator.MoveNext())
                {
                    var pair = enumerator.Current;
                    if (!this.ContainsName(pair.Key))
                        yield return pair;
                }
            }
        }

        /// <summary>
        /// 获取 <see cref="YandereActionParameters"/> 的枚举器。
        /// </summary>
        /// <returns><see cref="YandereActionParameters"/> 的枚举器。</returns>
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

        /// <summary>
        /// 确定一个参数名在该 <see cref="YandereActionParameters"/> 中是否为默认参数的名称。
        /// </summary>
        /// <param name="name">要确认的参数名。</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">参数 <paramref name="name"/> 表示的参数名已被显式添加或未被设为具有默认值的参数的名称。</exception>
        public bool IsParameterDefault(string name)
        {
            if (this.innerDictionary.ContainsKey(name))
                return false;
            else if (this.DefaultParameters.ContainsKey(name))
                return true;
            else if (this.MergedParameters.Any(parameters => parameters.IsParameterDefault(name)))
                return true;
            else
                throw new KeyNotFoundException("指定参数名已被显式添加或未被设为具有默认值的参数的名称。");
        }

        /// <summary>
        /// 将带有指定的名称的参数从 <see cref="YandereActionParameters"/> 中移除。
        /// </summary>
        /// <param name="name">要移除的参数的名称。</param>
        /// <returns>
        /// <para>如果成功找到并移除该元素，则为 <see langword="true"/> ；否则为 <see langword="false"/> 。</para>
        /// <para>如果在 <see cref="YandereActionParameters"/> 中没有找到 <paramref name="name"/> ，则此方法返回 <see langword="false"/> 。</para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> 的值为 <see langword="null"/> 。</exception>
        protected bool RemoveParameter(string name) => this.innerDictionary.Remove(name ?? throw new ArgumentNullException(nameof(name)));

        /// <summary>
        /// 获取具有指定名称的参数的值。
        /// </summary>
        /// <param name="name">要获取的参数的键。</param>
        /// <returns>具有指定名称的参数的值。</returns>
        /// <exception cref="KeyNotFoundException">参数 <paramref name="name"/> 表示的参数名未被显式添加且未被设为具有默认值的参数的名称，也不在合并的动作参数集合中。</exception>
        /// <exception cref="KeyUnuniqueException">参数 <paramref name="name"/> 表示的参数名在逻辑合并的动作参数集合中非唯一。</exception>
        protected object GetValue(string name)
        {
            if (this.innerDictionary.ContainsKey(name))
                return this.innerDictionary[name];
            else if (this.DefaultParameters.ContainsKey(name))
                return this.DefaultParameters[name];
            else
            {
                ArrayList arrayList = new ArrayList(this.MergedParameters.Count);
                foreach (var parameters in this.MergedParameters)
                    if (parameters.TryGetValue(name, out object value))
                        arrayList.Add(value);
                
                switch (arrayList.Count)
                {
                    case 0:
                        throw new KeyNotFoundException("指定参数名未被显式添加且未被设为具有默认值的参数的名称，也不在合并的动作参数集合中。");
                    case 1:
                        return arrayList[0];
                    default:
                        throw new KeyUnuniqueException("指定参数名在逻辑合并的动作参数集合中非唯一。");
                }
            }
        }

        /// <summary>
        /// 获取具有指定名称的参数的值。
        /// </summary>
        /// <param name="name">要获取的参数的键。</param>
        /// <param name="value">如果找到指定键，则此参数返回具有指定名称的参数的值；否则此参数值无意义。</param>
        /// <returns>如果 <see cref="YandereActionParameters"/> 包含具有指定名称的参数的值，则为 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        public bool TryGetValue(string name, out object value)
        {
            try
            {
                value = this.GetValue(name);
            }
            catch (Exception)
            {
                value = null;
                return false;
            }

            return true;
        }
    }
}

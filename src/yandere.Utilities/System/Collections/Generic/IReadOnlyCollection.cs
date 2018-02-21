using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    /// <summary>
    /// 表示元素的只读集合。
    /// </summary>
    public interface IReadOnlyCollection : IEnumerable
    {
        /// <summary>
        /// 获取集合中的元素数。
        /// </summary>
        /// <value>集合中的元素数。</value>
        int Count { get; }
    }
}

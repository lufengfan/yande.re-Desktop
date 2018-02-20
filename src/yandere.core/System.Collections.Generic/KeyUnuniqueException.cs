using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    /// <summary>
    /// 当指定用于访问集合中元素的键与逻辑合并多个集合的集合中的任意键均不匹配时所引发的异常。
    /// </summary>
    public class KeyUnuniqueException : SystemException
    {
        public KeyUnuniqueException() : this("键非唯一。") { }
        public KeyUnuniqueException(string message) : base(message) { }
        public KeyUnuniqueException(string message, Exception inner) : base(message, inner) { }
        protected KeyUnuniqueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

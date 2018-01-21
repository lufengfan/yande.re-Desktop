using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    /// <summary>
    /// 表示 Yandere 标签。
    /// </summary>
    [DebuggerDisplay("{Value}, TagType = {TagType}")]
    public class YandereTag : IEquatable<YandereTag>
    {
        private string value;
        /// <summary>
        /// 获取此标签的值。
        /// </summary>
        public virtual string Value => this.value;

        private YandereTagType tagType;
        /// <summary>
        /// 获取此标签的类型。
        /// </summary>
        public virtual YandereTagType TagType => this.tagType;

        /// <summary>
        /// 初始化 <see cref="YandereTag"/> 类的新实例，此实例包含指定的标签的内容和类型。
        /// </summary>
        /// <param name="value">标签的内容。</param>
        /// <param name="tagType">标签的类型。</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> 的值为 <see langword="null"/> 。</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> 的值为空或空白。</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagType"/> 的值未在 <see cref="YandereTagType"/> 中定义。</exception>
        public YandereTag(string value, YandereTagType tagType)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentOutOfRangeException(nameof(value), "标签的值不应为空或空白。");

            if (!Enum.IsDefined(typeof(YandereTagType), tagType)) throw new ArgumentOutOfRangeException(nameof(tagType), "未定义的标签类型。");

            this.value = value.Trim();
            this.tagType = tagType;
        }

        /// <summary>
        /// 确定指定的对象是否等于当前对象。
        /// </summary>
        /// <param name="obj">要与当前对象进行比较的对象。</param>
        /// <returns>如果指定的对象等于当前对象，则为 <see langword="true"/> ，否则为 <see langword="false"/> 。</returns>
        public sealed override bool Equals(object obj) => obj is YandereTag tag && this.Equals(tag);

        /// <summary>
        /// 确定指定的标签是否等于当前标签。
        /// </summary>
        /// <param name="tag">要与当前标签进行比较的标签。</param>
        /// <returns>如果指定的标签等于当前标签，则为 <see langword="true"/> ，否则为 <see langword="false"/> 。</returns>
        public bool Equals(YandereTag tag) => tag != null && this.Value == tag.Value;

        /// <summary>
        /// 返回该对象的哈希码。
        /// </summary>
        /// <returns>该对象的哈希码。</returns>
        public override int GetHashCode() =>
            this.Value.GetHashCode() ^ this.TagType.GetHashCode();

#pragma warning disable 1591
        public static bool operator ==(YandereTag left, YandereTag right) =>
            object.ReferenceEquals(left, right) || (left != null && left.Equals(right));
        public static bool operator !=(YandereTag left, YandereTag right) => !(left == right);
#pragma warning restore 1591
    }
}

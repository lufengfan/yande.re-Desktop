using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher
{
    /// <summary>
    /// 表示矩形的角的尺寸。
    /// </summary>
    [TypeConverter(typeof(CornerSizeConverter))]
    public struct CornerSize : IEquatable<CornerSize>
    {
        /// <summary>
        /// 获取或设置左上的角的尺寸值。
        /// </summary>
        public Size TopLeft { get; set; }

        /// <summary>
        /// 获取或设置右上的角的尺寸值。
        /// </summary>
        public Size TopRight { get; set; }

        /// <summary>
        /// 获取或设置右下的角的尺寸值。
        /// </summary>
        public Size BottomRight { get; set; }

        /// <summary>
        /// 获取或设置左下的角的尺寸值。
        /// </summary>
        public Size BottomLeft { get; set; }

        /// <summary>
        /// 初始化 <see cref="CornerSize"/> 类的新实例，此实例具有指定的统一的角尺寸值。
        /// </summary>
        /// <param name="uniformSize">应用于每个角的尺寸值。</param>
        public CornerSize(Size uniformSize) : this(uniformSize, uniformSize, uniformSize, uniformSize) { }

        /// <summary>
        /// 初始化 <see cref="CornerSize"/> 类的新实例，此实例为每个角指定尺寸值。
        /// </summary>
        /// <param name="topLeft">左上角的尺寸值。</param>
        /// <param name="topRight">右上角的尺寸值。</param>
        /// <param name="bottomRight">右下角的尺寸值。</param>
        /// <param name="bottomLeft">左下角的尺寸值。</param>
        public CornerSize(Size topLeft, Size topRight, Size bottomRight, Size bottomLeft)
        {
            this.TopLeft = topLeft;
            this.TopRight = topRight;
            this.BottomRight = bottomRight;
            this.BottomLeft = bottomLeft;
        }

        /// <summary>
        /// 确定是否指定 <see cref="object"/> 是 <see cref="CornerSize"/> 以及它是否包含与此 <see cref="CornerSize"/> 相同的角尺寸值。
        /// </summary>
        /// <param name="obj">要比较的 <see cref="object"/> 。</param>
        /// <returns>
        /// 如果 <paramref name="obj"/> 是 <see cref="CornerSize"/> 以及它是否包含与此 <see cref="CornerSize"/> 相同的角尺寸值，则为 <see langword="true"/> ；否则为 <see langword="false"/> 。
        /// </returns>
        public override bool Equals(object obj) => (obj is CornerSize cornerSize) && this.Equals(cornerSize);

        /// <summary>
        /// 比较两个 <see cref="CornerSize"/> 结构是否相等。
        /// </summary>
        /// <param name="cornerSize">要与此 <see cref="CornerSize"/> 比较的 <see cref="CornerSize"/> 。</param>
        /// <returns>如果 <paramref name="cornerSize"/> 包含与此 <see cref="CornerSize"/> 相同的角尺寸值，则为 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        public bool Equals(CornerSize cornerSize) =>
            (this.TopLeft == cornerSize.TopLeft) && (this.TopRight == cornerSize.TopRight) &&
                (this.BottomRight == cornerSize.BottomRight) && (this.BottomLeft == cornerSize.BottomLeft);

        /// <summary>
        /// 返回此 <see cref="CornerSize"/> 的哈希码。
        /// </summary>
        /// <returns>此 <see cref="CornerSize"/> 的哈希码。</returns>
        public override int GetHashCode() =>
            this.TopLeft.GetHashCode() ^ this.TopRight.GetHashCode() ^
                this.BottomRight.GetHashCode() ^ this.BottomLeft.GetHashCode();

        /// <summary>
        /// 返回 <see cref="CornerSize"/> 的字符串表示形式。
        /// </summary>
        /// <returns><see cref="CornerSize"/> 的字符串表示形式。</returns>
        public override string ToString() =>
            CornerSizeConverter.ToString(this, CultureInfo.InvariantCulture);

        /// <summary>
        /// 比较两个 <see cref="CornerSize"/> 结构是否相等。
        /// </summary>
        /// <param name="cs1">要比较的第一个 <see cref="CornerSize"/> 。</param>
        /// <param name="cs2">要比较的第二个 <see cref="CornerSize"/> 。</param>
        /// <returns>
        /// 如果 <paramref name="cs1"/> 和 <paramref name="cs2"/> 的所有角均具有相等的值（ <see cref="TopLeft"/> ， <see cref="TopRight"/> ， <see cref="BottomRight"/> ， <see cref="BottomLeft"/> ），则为 <see langword="true"/> ；否则为 <see langword="false"/> 。
        /// </returns>
        public static bool operator ==(CornerSize cs1, CornerSize cs2) => cs1.Equals(cs2);

        /// <summary>
        /// 比较两个 <see cref="CornerSize"/> 结构是否不等。
        /// </summary>
        /// <param name="cs1">要比较的第一个 <see cref="CornerSize"/> 。</param>
        /// <param name="cs2">要比较的第二个 <see cref="CornerSize"/> 。</param>
        /// <returns>
        /// 如果 <paramref name="cs1"/> 和 <paramref name="cs2"/> 的所有角中具有不等的值（ <see cref="TopLeft"/> ， <see cref="TopRight"/> ， <see cref="BottomRight"/> ， <see cref="BottomLeft"/> ），则为 <see langword="true"/> ；否则为 <see langword="false"/> 。
        /// </returns>
        public static bool operator !=(CornerSize cs1, CornerSize cs2) => !(cs1.Equals(cs2));
    }
}

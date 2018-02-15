using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    /// <summary>
    /// 表示 Yandere 图贴。
    /// </summary>
    [DebuggerDisplay("{ID}, ({Size}")]
    public abstract class YanderePost
    {
        /// <summary>
        /// 缓存 <see cref="YandereTag"/> 的字典。
        /// </summary>
        protected static readonly IDictionary<uint, YanderePost> PostsCache = new Dictionary<uint, YanderePost>();

        /// <summary>
        /// 获取或设置此图贴的 ID 。
        /// </summary>
        public uint ID { get; protected set; }

        /// <summary>
        /// 获取此图贴的标签集合。
        /// </summary>
        public YandereTagCollection Tags { get; } = new YandereTagCollection();

        /// <summary>
        /// 获取或设置此图贴的上级图贴。如果没有上级图贴，则为 <see langword="null"/> 。
        /// </summary>
        public YanderePost ParentPost { get; protected set; }

        public bool HasChildren { get; protected set; }

        /// <summary>
        /// 获取此图贴的下级图贴集合。
        /// </summary>
        public YanderePostCollection ChildPosts { get; }

        /// <summary>
        /// 获取或设置此图贴的发布时间。
        /// </summary>
        public DateTime PostTime { get; protected set; }

        /// <summary>
        /// 获取或设置此图贴的源图片地址。
        /// </summary>
        public Uri ImageUri { get; protected set; }

        /// <summary>
        /// 获取或设置此图贴的源图片的 png 格式地址。
        /// </summary>
        public Uri PngImageUri { get; protected set; }

        /// <summary>
        /// 获取或设置此图贴的大样图片地址。
        /// </summary>
        public Uri SampleImageUri { get; protected set; }

        /// <summary>
        /// 获取或设置此图贴的预览图片地址。
        /// </summary>
        public Uri PreviewImageUri { get; protected set; }

        /// <summary>
        /// 获取或设置此图贴的图片大小。
        /// </summary>
        public Size Size { get; protected set; }
    }
}

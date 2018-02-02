using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Controls
{
    /// <summary>
    /// 表示 <see cref="StretchHelper.StretchModeProperty"/> 的拉伸模式。
    /// </summary>
    public enum StretchMode
    {
        /// <summary>
        /// 忽略宽高比。
        /// </summary>
        IgnoreAspectRatio,
        /// <summary>
        /// 以宽度为基准。
        /// </summary>
        WidthOriented,
        /// <summary>
        /// 以高度为基准。
        /// </summary>
        HeightOriented
    }
}

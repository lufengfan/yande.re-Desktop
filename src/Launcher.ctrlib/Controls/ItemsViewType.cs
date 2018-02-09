using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Controls
{
    public enum ItemsViewType
    {
        /// <summary>
        /// 网格对齐显示。
        /// </summary>
        Grid,
        /// <summary>
        /// 水平排布，在一行结尾初折断到下一行。
        /// </summary>
        HorizontalWrap,
        /// <summary>
        /// 在数列垂直排布，每一项紧跟在所有列中结尾最靠近起点的列中。
        /// </summary>
        VerticalHang
    }
}

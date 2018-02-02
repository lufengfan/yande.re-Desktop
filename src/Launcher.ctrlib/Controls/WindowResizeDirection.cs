using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Controls
{
    public enum WindowResizeDirection
    {
        /// <summary>左</summary>
        West = 1,
        /// <summary>右</summary>
        East = 2,
        /// <summary>上</summary>
        North = 3,
        /// <summary>下</summary>
        South = 6,
        /// <summary>左上</summary>
        NorthWest = WindowResizeDirection.North + WindowResizeDirection.West,
        /// <summary>右上</summary>
        NorthEast = WindowResizeDirection.North + WindowResizeDirection.East,
        /// <summary>左下</summary>
        SouthWest = WindowResizeDirection.South + WindowResizeDirection.West,
        /// <summary>右下</summary>
        SouthEast = WindowResizeDirection.South + WindowResizeDirection.East
    }
}

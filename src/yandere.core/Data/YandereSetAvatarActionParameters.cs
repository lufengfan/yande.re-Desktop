using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YandereSetAvatarActionParameters : YandereActionParameters
    {
        public const string ParamName_PostID = "post_id";
        public const string ParamName_LeftBound = "left";
        public const string ParamName_RightBound = "right";
        public const string ParamName_TopBound = "top";
        public const string ParamName_BottomBound = "bottom";

        /// <summary>
        /// 获取或设置截取头像的矩形框左边界距离原图像左边界的距离与原图像宽度的比值。
        /// </summary>
        /// <value>
        /// 截取头像的矩形框左边界距离原图像左边界的距离与原图像宽度的比值。值介于 0 与 1 之间。
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">设置的值不能为非数字。</exception>
        /// <exception cref="ArgumentOutOfRangeException">设置的值不能为正无穷大或负无穷大。</exception>
        /// <exception cref="ArgumentOutOfRangeException">设置的值必须介于 0 与 1 之间。</exception>
        public double LeftBound
        {
            get => (double)this[ParamName_LeftBound];
            set
            {
                this.ValidateBoundValue(value);

                this[ParamName_LeftBound] = value;
            }
        }

        /// <summary>
        /// 获取或设置截取头像的矩形框右边界距离原图像左边界的距离与原图像宽度的比值。
        /// </summary>
        /// <value>
        /// 截取头像的矩形框右边界距离原图像左边界的距离与原图像宽度的比值。值介于 0 与 1 之间。
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">设置的值不能为非数字。</exception>
        /// <exception cref="ArgumentOutOfRangeException">设置的值不能为正无穷大或负无穷大。</exception>
        /// <exception cref="ArgumentOutOfRangeException">设置的值必须介于 0 与 1 之间。</exception>
        public double RightBound
        {
            get => (double)this[ParamName_RightBound];
            set
            {
                this.ValidateBoundValue(value);

                this[ParamName_RightBound] = value;
            }
        }

        /// <summary>
        /// 获取或设置截取头像的矩形框上边界距离原图像上边界的距离与原图像高度的比值。
        /// </summary>
        /// <value>
        /// 截取头像的矩形框上边界距离原图像上边界的距离与原图像高度的比值。值介于 0 与 1 之间。
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">设置的值不能为非数字。</exception>
        /// <exception cref="ArgumentOutOfRangeException">设置的值不能为正无穷大或负无穷大。</exception>
        /// <exception cref="ArgumentOutOfRangeException">设置的值必须介于 0 与 1 之间。</exception>
        public double TopBound
        {
            get => (double)this[ParamName_TopBound];
            set
            {
                this.ValidateBoundValue(value);

                this[ParamName_TopBound] = value;
            }
        }

        /// <summary>
        /// 获取或设置截取头像的矩形框下边界距离原图像上边界的距离与原图像高度的比值。
        /// </summary>
        /// <value>
        /// 截取头像的矩形框下边界距离原图像上边界的距离与原图像高度的比值。值介于 0 与 1 之间。
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">设置的值不能为非数字。</exception>
        /// <exception cref="ArgumentOutOfRangeException">设置的值不能为正无穷大或负无穷大。</exception>
        /// <exception cref="ArgumentOutOfRangeException">设置的值必须介于 0 与 1 之间。</exception>
        public double BottomBound
        {
            get => (double)this[ParamName_BottomBound];
            set
            {
                this.ValidateBoundValue(value);

                this[ParamName_BottomBound] = value;
            }
        }

        public YandereSetAvatarActionParameters() : base(4)
        {
            this.AddParameter(ParamName_LeftBound, 0D);
            this.AddParameter(ParamName_RightBound, 1D);
            this.AddParameter(ParamName_TopBound, 0D);
            this.AddParameter(ParamName_BottomBound, 1D);
        }

        public YandereSetAvatarActionParameters(double left, double right, double top, double bottom) : this()
        {
            this.LeftBound = left;
            this.RightBound = right;
            this.TopBound = top;
            this.BottomBound = bottom;
        }

        private void ValidateBoundValue(double value, Func<double, Exception> throwHelper = null)
        {
            string message = null;
            throwHelper = throwHelper ?? (_value => new ArgumentOutOfRangeException(nameof(value), _value, message));
            if (double.IsNaN(value))
            {
                message = $"值不能为非数字。";
                throw throwHelper(value);
            }
            else if (double.IsInfinity(value))
            {
                message = $"值不能为正无穷大或负无穷大。";
                throw throwHelper(value);
            }
            else if (value < 0 || value > 1)
            {
                message = $"值必须介于 0 与 1 之间。";
                throw throwHelper(value);
            }
        }
    }
}

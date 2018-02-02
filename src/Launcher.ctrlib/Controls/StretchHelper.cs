using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher.Controls
{
    public static class StretchHelper
    {

        #region AspectRatio
        /// <summary>
        /// 标识 <see cref="StretchHelper"/> 的 AspectRatio 附加属性。
        /// </summary>
        public static readonly DependencyProperty AspectRatioProperty =
            DependencyProperty.RegisterAttached("AspectRatio", typeof(double), typeof(StretchHelper), new PropertyMetadata(double.NaN));

        /// <summary>
        /// 获取对象的  <see cref="StretchHelper"/> 的 AspectRatio 附加属性值。
        /// </summary>
        /// <param name="obj">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="StretchHelper"/> 的 AspectRatio 附加属性值。</returns>
        public static double GetAspectRatio(DependencyObject obj) =>
            (double)obj.GetValue(StretchHelper.AspectRatioProperty);

        /// <summary>
        /// 设置对象的  <see cref="StretchHelper"/> 的 AspectRatio 附加属性值。
        /// </summary>
        /// <param name="obj">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetAspectRatio(DependencyObject obj, double value) =>
            obj.SetValue(StretchHelper.AspectRatioProperty, value);
        #endregion

        #region StretchMode
        /// <summary>
        /// 标识 <see cref="StretchHelper"/> 的 StretchMode 附加属性。
        /// </summary>
        public static readonly DependencyProperty StretchModeProperty =
            DependencyProperty.RegisterAttached("StretchMode", typeof(StretchMode), typeof(StretchHelper), new PropertyMetadata(StretchMode.IgnoreAspectRatio));

        /// <summary>
        /// 获取对象的  <see cref="StretchHelper"/> 的 StretchMode 附加属性值。
        /// </summary>
        /// <param name="obj">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="StretchHelper"/> 的 StretchMode 附加属性值。</returns>
        public static StretchMode GetStretchMode(DependencyObject obj) =>
            (StretchMode)obj.GetValue(StretchHelper.StretchModeProperty);

        /// <summary>
        /// 设置对象的  <see cref="StretchHelper"/> 的 StretchMode 附加属性值。
        /// </summary>
        /// <param name="obj">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetStretchMode(DependencyObject obj, StretchMode value) =>
            obj.SetValue(StretchHelper.StretchModeProperty, value);
        #endregion

        #region IgnoreOriginalSize
        public static readonly DependencyProperty IgnoreOriginalSizeProperty =
            DependencyProperty.RegisterAttached("IgnoreOriginalSize", typeof(bool), typeof(StretchHelper), new PropertyMetadata(false));

        public static bool GetIgnoreOriginalSize(DependencyObject obj) =>
            (bool)obj.GetValue(StretchHelper.IgnoreOriginalSizeProperty);

        public static void SetIgnoreOriginalSize(DependencyObject obj, bool value) =>
            obj.SetValue(StretchHelper.IgnoreOriginalSizeProperty, value);
        #endregion

        #region Width
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.RegisterAttached("Width", typeof(double), typeof(StretchHelper), new PropertyMetadata(double.NaN));

        public static double GetWidth(DependencyObject obj) =>
            (double)obj.GetValue(StretchHelper.WidthProperty);

        public static void SetWidth(DependencyObject obj, double value) =>
            obj.SetValue(StretchHelper.WidthProperty, value);
        #endregion

        #region Height
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached("Height", typeof(double), typeof(StretchHelper), new PropertyMetadata(double.NaN));

        public static double GetHeight(DependencyObject obj) =>
            (double)obj.GetValue(StretchHelper.HeightProperty);

        public static void SetHeight(DependencyObject obj, double value) =>
            obj.SetValue(StretchHelper.HeightProperty, value);
        #endregion

        #region MinWidth
        public static readonly DependencyProperty MinWidthProperty =
            DependencyProperty.RegisterAttached(
                "MinWidth", typeof(double), typeof(StretchHelper),
                new PropertyMetadata(double.NaN,
                    null,
                    StretchHelper.OnMinWidthCoerceValue
                ),
                StretchHelper.OnMinWidthValidateValue
            );

        private static object OnMinWidthCoerceValue(DependencyObject d, object baseValue)
        {
            double value = (double)baseValue;
            if (double.IsNegativeInfinity(value) || value < 0D)
                return 0D;
            else
            {
                double max = StretchHelper.GetMaxWidth(d);
                if (double.IsPositiveInfinity(max) || value <= max)
                    return value;
                else
                    return max;
            }
        }

        private static bool OnMinWidthValidateValue(object value) =>
            (value is double d) &&
                (!double.IsNaN(d) && !double.IsPositiveInfinity(d));

        public static double GetMinWidth(DependencyObject obj) =>
            (double)obj.GetValue(StretchHelper.MinWidthProperty);

        public static void SetMinWidth(DependencyObject obj, double value) =>
            obj.SetValue(StretchHelper.MinWidthProperty, value);
        #endregion

        #region MaxWidth
        public static readonly DependencyProperty MaxWidthProperty =
            DependencyProperty.RegisterAttached(
                "MaxWidth", typeof(double), typeof(StretchHelper),
                new PropertyMetadata(double.NaN,
                    null,
                    StretchHelper.OnMaxWidthCoerceValue
                ),
                StretchHelper.OnMaxWidthValidateValue
            );

        private static object OnMaxWidthCoerceValue(DependencyObject d, object baseValue)
        {
            double value = (double)baseValue;
            double min = StretchHelper.GetMinWidth(d);
            if (double.IsPositiveInfinity(value) || value >= min)
                return value;
            else
                return min;
        }

        private static bool OnMaxWidthValidateValue(object value) =>
            (value is double d) && !double.IsNaN(d);

        public static double GetMaxWidth(DependencyObject obj) =>
            (double)obj.GetValue(StretchHelper.MaxWidthProperty);

        public static void SetMaxWidth(DependencyObject obj, double value) =>
            obj.SetValue(StretchHelper.MaxWidthProperty, value);
        #endregion

        #region MinHeight
        public static readonly DependencyProperty MinHeightProperty =
            DependencyProperty.RegisterAttached(
                "MinHeight", typeof(double), typeof(StretchHelper),
                new PropertyMetadata(double.NaN,
                    null,
                    StretchHelper.OnMinHeightCoerceValue
                ),
                StretchHelper.OnMinHeightValidateValue
            );
        
        private static object OnMinHeightCoerceValue(DependencyObject d, object baseValue)
        {
            double value = (double)baseValue;
            if (double.IsNegativeInfinity(value) || value < 0D)
                return 0D;
            else
            {
                double max = StretchHelper.GetMaxHeight(d);
                if (double.IsPositiveInfinity(max) || value <= max)
                    return value;
                else
                    return max;
            }
        }

        private static bool OnMinHeightValidateValue(object value) =>
            (value is double d) &&
                (!double.IsNaN(d) && !double.IsPositiveInfinity(d));

        public static double GetMinHeight(DependencyObject obj) =>
            (double)obj.GetValue(StretchHelper.MinHeightProperty);

        public static void SetMinHeight(DependencyObject obj, double value) =>
            obj.SetValue(StretchHelper.MinHeightProperty, value);
        #endregion

        #region MaxHeight
        public static readonly DependencyProperty MaxHeightProperty =
            DependencyProperty.RegisterAttached(
                "MaxHeight", typeof(double), typeof(StretchHelper),
                new PropertyMetadata(double.NaN,
                    null,
                    StretchHelper.OnMaxHeightCoerceValue
                ),
                StretchHelper.OnMaxHeightValidateValue
            );

        private static object OnMaxHeightCoerceValue(DependencyObject d, object baseValue)
        {
            double value = (double)baseValue;
            double min = StretchHelper.GetMinHeight(d);
            if (double.IsPositiveInfinity(value) || value >= min)
                return value;
            else
                return min;
        }

        private static bool OnMaxHeightValidateValue(object value) =>
            (value is double d) && !double.IsNaN(d);
        
        public static double GetMaxHeight(DependencyObject obj) =>
            (double)obj.GetValue(StretchHelper.MaxHeightProperty);

        public static void SetMaxHeight(DependencyObject obj, double value) =>
            obj.SetValue(StretchHelper.MaxHeightProperty, value);
        #endregion

    }
}

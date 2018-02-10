using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher.Controls
{
    public class StatusInfo : ContentControl
    {
        #region Icon Properties
        #region Icon
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(StatusInfo.Icon), typeof(ImageSource), typeof(StatusInfo), new PropertyMetadata(null));

        public ImageSource Icon
        {
            get => (ImageSource)this.GetValue(StatusInfo.IconProperty);
            set => this.SetValue(StatusInfo.IconProperty, value);
        }
        #endregion

        #region IconHeight
        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register(
                nameof(StatusInfo.IconHeight), typeof(double), typeof(StatusInfo),
                new PropertyMetadata(double.NaN),
                StatusInfo.WidthOrHeightValidateValue
            );

        public double IconHeight
        {
            get => (double)GetValue(StatusInfo.IconHeightProperty);
            set => SetValue(StatusInfo.IconHeightProperty, value);
        }
        #endregion

        #region IconWidth
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register(
                nameof(StatusInfo.IconWidth), typeof(double), typeof(StatusInfo),
                new PropertyMetadata(double.NaN),
                StatusInfo.WidthOrHeightValidateValue
            );

        public double IconWidth
        {
            get => (double)GetValue(StatusInfo.IconWidthProperty);
            set => SetValue(StatusInfo.IconWidthProperty, value);
        }
        #endregion

        private static bool WidthOrHeightValidateValue(object value)
        {
            if (value is double d)
            {
                if (double.IsNaN(d))
                    return true;
                else if (double.IsInfinity(d))
                    return false;
                else
                    return d >= 0;
            }
            else return false;
        }
        
        #region IconMinWidth
        public static readonly DependencyProperty IconMinWidthProperty =
            DependencyProperty.RegisterAttached(
                nameof(StatusInfo.IconMinWidth), typeof(double), typeof(StatusInfo),
                new PropertyMetadata(0D,
                    null,
                    StatusInfo.OnIconMinWidthCoerceValue
                ),
                StatusInfo.OnIconMinWidthValidateValue
            );

        public double IconMinWidth
        {
            get => (double)this.GetValue(StatusInfo.IconMinWidthProperty);
            set => this.SetValue(StatusInfo.IconMinWidthProperty, value);
        }

        private static object OnIconMinWidthCoerceValue(DependencyObject d, object baseValue)
        {
            StatusInfo statusInfo = (StatusInfo)d;
            double value = (double)baseValue;
            if (double.IsNegativeInfinity(value) || value < 0D)
                return 0D;
            else
            {
                double max = statusInfo.MaxWidth;
                if (double.IsPositiveInfinity(max) || value <= max)
                    return value;
                else
                    return max;
            }
        }

        private static bool OnIconMinWidthValidateValue(object value) =>
            (value is double d) &&
                (!double.IsNaN(d) && !double.IsPositiveInfinity(d));
        #endregion

        #region IconMaxWidth
        public static readonly DependencyProperty IconMaxWidthProperty =
            DependencyProperty.RegisterAttached(
                nameof(StatusInfo.IconMaxWidth), typeof(double), typeof(StatusInfo),
                new PropertyMetadata(double.PositiveInfinity,
                    null,
                    StatusInfo.OnIconMaxWidthCoerceValue
                ),
                StatusInfo.OnIconMaxWidthValidateValue
            );

        public double IconMaxWidth
        {
            get => (double)this.GetValue(StatusInfo.IconMaxWidthProperty);
            set => this.SetValue(StatusInfo.IconMaxWidthProperty, value);
        }

        private static object OnIconMaxWidthCoerceValue(DependencyObject d, object baseValue)
        {
            StatusInfo statusInfo = (StatusInfo)d;
            double value = (double)baseValue;
            double min = statusInfo.MinWidth;
            if (double.IsPositiveInfinity(value) || value >= min)
                return value;
            else
                return min;
        }

        private static bool OnIconMaxWidthValidateValue(object value) =>
            (value is double d) && !double.IsNaN(d);
        #endregion

        #region IconMinHeigth
        public static readonly DependencyProperty IconMinHeigthProperty =
            DependencyProperty.RegisterAttached(
                nameof(StatusInfo.IconMinHeigth), typeof(double), typeof(StatusInfo),
                new PropertyMetadata(0D,
                    null,
                    StatusInfo.OnIconMinHeigthCoerceValue
                ),
                StatusInfo.OnIconMinHeigthValidateValue
            );

        public double IconMinHeigth
        {
            get => (double)this.GetValue(StatusInfo.IconMinHeigthProperty);
            set => this.SetValue(StatusInfo.IconMinHeigthProperty, value);
        }

        private static object OnIconMinHeigthCoerceValue(DependencyObject d, object baseValue)
        {
            StatusInfo statusInfo = (StatusInfo)d;
            double value = (double)baseValue;
            if (double.IsNegativeInfinity(value) || value < 0D)
                return 0D;
            else
            {
                double max = statusInfo.MaxHeight;
                if (double.IsPositiveInfinity(max) || value <= max)
                    return value;
                else
                    return max;
            }
        }

        private static bool OnIconMinHeigthValidateValue(object value) =>
            (value is double d) &&
                (!double.IsNaN(d) && !double.IsPositiveInfinity(d));
        #endregion

        #region IconMaxHeight
        public static readonly DependencyProperty IconMaxHeightProperty =
            DependencyProperty.RegisterAttached(
                nameof(StatusInfo.IconMaxHeight), typeof(double), typeof(StatusInfo),
                new PropertyMetadata(double.PositiveInfinity,
                    null,
                    StatusInfo.OnIconMaxHeightCoerceValue
                ),
                StatusInfo.OnIconMaxHeightValidateValue
            );

        public double IconMaxHeight
        {
            get => (double)this.GetValue(StatusInfo.IconMaxHeightProperty);
            set => this.SetValue(StatusInfo.IconMaxHeightProperty, value);
        }

        private static object OnIconMaxHeightCoerceValue(DependencyObject d, object baseValue)
        {
            StatusInfo statusInfo = (StatusInfo)d;
            double value = (double)baseValue;
            double min = statusInfo.MinHeight;
            if (double.IsPositiveInfinity(value) || value >= min)
                return value;
            else
                return min;
        }

        private static bool OnIconMaxHeightValidateValue(object value) =>
            (value is double d) && !double.IsNaN(d);
        #endregion
        #endregion

        static StatusInfo()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StatusInfo), new FrameworkPropertyMetadata(typeof(StatusInfo)));
        }
    }
}

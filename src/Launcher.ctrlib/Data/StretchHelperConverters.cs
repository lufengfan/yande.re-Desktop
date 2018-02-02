using Launcher.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Launcher.Data
{
    public enum StretchHelperDirection
    {
        Width,
        Height
    }

    public class StretchHelperConverter : IValueConverter, IMultiValueConverter
    {
        private object ConvertInternal(
            DependencyObject obj, StretchHelperDirection direction,
            double width, double height, double actualWidth, double actualHeight
        )
        {
            StretchMode mode = StretchHelper.GetStretchMode(obj);
            double aspectRatio = StretchHelper.GetAspectRatio(obj);
            Exception exception = new InvalidOperationException($"不支持的参数 {direction} 。");
            if (mode == StretchMode.IgnoreAspectRatio || double.IsNaN(aspectRatio))
            // 忽略宽高比或宽高比为非数值。
            {
                switch (direction)
                {
                    case StretchHelperDirection.Width: // 要计算宽度。
                        return width;
                    case StretchHelperDirection.Height: // 要计算高度。
                        return height;
                    default:
                        throw exception;
                }
            }
            else
            {
                switch (mode)
                {
                    case StretchMode.WidthOriented: // 以宽度为基准。
                        switch (direction)
                        {
                            case StretchHelperDirection.Width: // 要计算宽度。
                                return width;
                            case StretchHelperDirection.Height: // 要计算高度。
                                return actualWidth / aspectRatio;
                            default:
                                throw exception;
                        }
                    case StretchMode.HeightOriented: // 以高度为基准。
                        switch (direction)
                        {
                            case StretchHelperDirection.Width: // 要计算宽度。
                                return actualHeight * aspectRatio;
                            case StretchHelperDirection.Height: // 要计算高度。
                                return height;
                            default:
                                throw exception;
                        }
                    default:
                        throw new InvalidOperationException($"不支持的拉伸模式 {mode} 。");
                }
            }
        }

        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Exception exception = new NotSupportedException($"无法从 {{{(value == null ? "空引用" : value.GetType().FullName)}}} 中转换。");

            if (parameter is StretchHelperDirection direction)
            {
                if (value is DependencyObject obj)
                {
                    double width, height;
                    double actualWidth, actualHeight;
                    double minWidth, maxWidth;
                    double minHeight, maxHeight;
                    bool ignoreOriginalSize = StretchHelper.GetIgnoreOriginalSize(obj);
                    if (ignoreOriginalSize)
                    {
                        width = StretchHelper.GetWidth(obj);
                        height = StretchHelper.GetHeight(obj);

                        actualWidth = width;
                        actualHeight = height;

                        minWidth = StretchHelper.GetMinWidth(obj);
                        maxWidth = StretchHelper.GetMaxWidth(obj);
                        if (actualWidth < minWidth) actualWidth = minWidth;
                        else if (actualWidth > maxWidth) actualWidth = maxWidth;

                        minHeight = StretchHelper.GetMinHeight(obj);
                        maxHeight = StretchHelper.GetMaxHeight(obj);
                        if (actualHeight < minHeight) actualHeight = minHeight;
                        else if (actualHeight > maxHeight) actualHeight = maxHeight;
                    }
                    else
                    {
                        if (obj is FrameworkElement element)
                        {
                            width = element.Width;
                            height = element.Height;

                            actualWidth = element.ActualWidth;
                            actualHeight = element.ActualHeight;

                            minWidth = element.MinWidth;
                            maxWidth = element.MaxWidth;

                            minHeight = element.MinHeight;
                            maxHeight = element.MaxHeight;
                        }
                        else throw exception;
                    }

                    return this.ConvertInternal(obj, direction, width, height, actualWidth, actualHeight);
                }
                else throw exception;
            }
            else throw new ArgumentException("缺少转换参数。", nameof(parameter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
        #endregion

        #region IMultiValueConverter Members
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Exception exception = new NotSupportedException($"缺少一个或多个必要的值。");

            if (parameter is StretchHelperDirection direction)
            {
                if (values.FirstOrDefault() is DependencyObject obj)
                {
                    values = values.Skip(1).ToArray();
                    double width, height;
                    double actualWidth, actualHeight;
                    double minWidth, maxWidth;
                    double minHeight, maxHeight;
                    bool ignoreOriginalSize = StretchHelper.GetIgnoreOriginalSize(obj);
                    if (ignoreOriginalSize)
                    {
                        width = StretchHelper.GetWidth(obj);
                        height = StretchHelper.GetHeight(obj);

                        actualWidth = width;
                        actualHeight = height;

                        minWidth = StretchHelper.GetMinWidth(obj);
                        maxWidth = StretchHelper.GetMaxWidth(obj);
                        if (actualWidth < minWidth) actualWidth = minWidth;
                        else if (actualWidth > maxWidth) actualWidth = maxWidth;

                        minHeight = StretchHelper.GetMinHeight(obj);
                        maxHeight = StretchHelper.GetMaxHeight(obj);
                        if (actualHeight < minHeight) actualHeight = minHeight;
                        else if (actualHeight > maxHeight) actualHeight = maxHeight;
                    }
                    else if (values.Length == 8)
                    {
                        width = (double)values[0];
                        height = (double)values[1];

                        actualWidth = (double)values[2];
                        actualHeight = (double)values[3];

                        minWidth = (double)values[4];
                        maxWidth = (double)values[5];

                        minHeight = (double)values[6];
                        maxHeight = (double)values[7];
                    }
                    else throw exception;

                    return this.ConvertInternal(obj, direction, width, height, actualWidth, actualHeight);
                }
                else throw exception;
            }
            else throw new ArgumentException("缺少转换参数。", nameof(parameter));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
        #endregion
    }
}

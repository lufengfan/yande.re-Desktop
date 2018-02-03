using Launcher.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Launcher.Controls
{
    public class CustomizedWindow : Window
    {

        #region Properties
        #region CustomizedWindowAncestor
        /// <summary>
        /// 标识 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性。
        /// </summary>
        public static readonly DependencyProperty CustomizedWindowAncestorProperty =
            DependencyProperty.RegisterAttached(
                "CustomizedWindowAncestor", typeof(CustomizedWindow), typeof(CustomizedWindow),
                new PropertyMetadata(
                    null,
                    CustomizedWindow.CustomizedWindowAncestorPropertyChanged
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 更新 <see cref="WindowTitleAreaSpecificParts"/> 、 <see cref="WindowNorthResizeAreaSpecificParts"/> 、 <see cref="WindowSouthResizeAreaSpecificParts"/> 、 <see cref="WindowWestResizeAreaSpecificParts"/> 、 <see cref="WindowEastResizeAreaSpecificParts"/> 、 <see cref="WindowNorthWestResizeAreaSpecificParts"/> 、 <see cref="WindowNorthEastResizeAreaSpecificParts"/> 、 <see cref="WindowSouthEastResizeAreaSpecificParts"/> 、 <see cref="WindowSouthWestResizeAreaSpecificParts"/> 。
        /// </remarks>
        /// <seealso cref="GetIsWindowTitleAreaPart(UIElement)"/>
        /// <seealso cref="WindowTitleAreaSpecificParts"/>
        /// <seealso cref="GetIsWindowNorthResizeAreaPart(UIElement)"/>
        /// <seealso cref="WindowNorthResizeAreaSpecificParts"/>
        /// <seealso cref="GetIsWindowSouthResizeAreaPart(UIElement)"/>
        /// <seealso cref="WindowSouthResizeAreaSpecificParts"/>
        /// <seealso cref="GetIsWindowWestResizeAreaPart(UIElement)"/>
        /// <seealso cref="WindowWestResizeAreaSpecificParts"/>
        /// <seealso cref="GetIsWindowEastResizeAreaPart(UIElement)"/>
        /// <seealso cref="WindowEastResizeAreaSpecificParts"/>
        /// <seealso cref="GetIsWindowNorthWestResizeAreaPart(UIElement)"/>
        /// <seealso cref="WindowNorthWestResizeAreaSpecificParts"/>
        /// <seealso cref="GetIsWindowNorthEastResizeAreaPart(UIElement)"/>
        /// <seealso cref="WindowNorthEastResizeAreaSpecificParts"/>
        /// <seealso cref="GetIsWindowSouthEastResizeAreaPart(UIElement)"/>
        /// <seealso cref="WindowSouthEastResizeAreaSpecificParts"/>
        /// <seealso cref="GetIsWindowSouthWestResizeAreaPart(UIElement)"/>
        /// <seealso cref="WindowSouthWestResizeAreaSpecificParts"/>
        private static void CustomizedWindowAncestorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            CustomizedWindow oldValue = e.OldValue as CustomizedWindow;
            CustomizedWindow newValue = e.NewValue as CustomizedWindow;

            if (CustomizedWindow.GetIsWindowTitleAreaPart(element))
            {
                oldValue?.WindowTitleAreaSpecificParts.Remove(element);
                newValue?.WindowTitleAreaSpecificParts.Add(element);
            }

            if (CustomizedWindow.GetIsWindowNorthResizeAreaPart(element))
            {
                oldValue?.WindowNorthResizeAreaSpecificParts.Remove(element);
                oldValue?.WindowNorthResizeAreaSpecificParts.Add(element);
            }
            if (CustomizedWindow.GetIsWindowSouthResizeAreaPart(element))
            {
                oldValue?.WindowSouthResizeAreaSpecificParts.Remove(element);
                oldValue?.WindowSouthResizeAreaSpecificParts.Add(element);
            }
            if (CustomizedWindow.GetIsWindowWestResizeAreaPart(element))
            {
                oldValue?.WindowWestResizeAreaSpecificParts.Remove(element);
                oldValue?.WindowWestResizeAreaSpecificParts.Add(element);
            }
            if (CustomizedWindow.GetIsWindowEastResizeAreaPart(element))
            {
                oldValue?.WindowEastResizeAreaSpecificParts.Remove(element);
                oldValue?.WindowEastResizeAreaSpecificParts.Add(element);
            }
            if (CustomizedWindow.GetIsWindowNorthWestResizeAreaPart(element))
            {
                oldValue?.WindowNorthWestResizeAreaSpecificParts.Remove(element);
                oldValue?.WindowNorthWestResizeAreaSpecificParts.Add(element);
            }
            if (CustomizedWindow.GetIsWindowNorthEastResizeAreaPart(element))
            {
                oldValue?.WindowNorthEastResizeAreaSpecificParts.Remove(element);
                oldValue?.WindowNorthEastResizeAreaSpecificParts.Add(element);
            }
            if (CustomizedWindow.GetIsWindowSouthEastResizeAreaPart(element))
            {
                oldValue?.WindowSouthEastResizeAreaSpecificParts.Remove(element);
                oldValue?.WindowSouthEastResizeAreaSpecificParts.Add(element);
            }
            if (CustomizedWindow.GetIsWindowSouthWestResizeAreaPart(element))
            {
                oldValue?.WindowSouthWestResizeAreaSpecificParts.Remove(element);
                oldValue?.WindowSouthWestResizeAreaSpecificParts.Add(element);
            }
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性值。</returns>
        public static CustomizedWindow GetCustomizedWindowAncestor(UIElement element) =>
            (CustomizedWindow)element.GetValue(CustomizedWindowAncestorProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetCustomizedWindowAncestor(UIElement element, CustomizedWindow value) =>
            element.SetValue(CustomizedWindowAncestorProperty, value);
        #endregion



        #region WindowTitleArea Properties
        #region WindowTitleArea
        /// <summary>
        /// 标志 <see cref="WindowTitleAreaProperty"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowTitleAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowTitleArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置表示窗体标题区域的 <see cref="Geometry"/> 。
        /// </summary>
        public Geometry WindowTitleArea
        {
            get => (Geometry)this.GetValue(CustomizedWindow.WindowTitleAreaProperty);
            set => this.SetValue(CustomizedWindow.WindowTitleAreaProperty, value);
        }
        #endregion

        #region WindowTitleAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowTitleAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowTitleAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowTitleAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowTitleAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowTitleAreaSpecificPartsProperty = CustomizedWindow.WindowTitleAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体标题区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowTitleAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowTitleAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowTitleAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowTitleAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowTitleAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowTitleAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowTitleAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowTitleAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowTitleAreaMouseWithinProperty =
            CustomizedWindow.IsWindowTitleAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体标题区域之内。
        /// </summary>
        public bool IsWindowTitleAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowTitleAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowTitleAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowTitleAreaMouseEnter"/> 和 <see cref="WindowTitleAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowTitleAreaMouseEnter"/>
        /// <seealso cref="WindowTitleAreaMouseLeave"/>
        private static void IsWindowTitleAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowTitleAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowTitleAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowTitleAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowTitleAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false, 
                    CustomizedWindow.IsWindowTitleAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowTitleAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowTitleAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowTitleAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowTitleAreaSpecificParts.Add(element);
                else
                    window.WindowTitleAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowTitleAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowTitleAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowTitleAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowTitleAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowTitleAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowTitleAreaPart 附加属性值。</returns>
        public static bool GetIsWindowTitleAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowTitleAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowTitleAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowTitleAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowTitleAreaPartProperty, value);
        #endregion
        #endregion
        
        #region WindowResizeArea Properties
        #region WindowResizeBorderThickness
        /// <summary>
        /// 标识 <see cref="WindowResizeBorderThickness"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowResizeBorderThicknessProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowResizeBorderThickness), typeof(Thickness), typeof(CustomizedWindow), new PropertyMetadata(new Thickness(0.0)));

        /// <summary>
        /// 获取或设置窗体缩放边界的宽度。
        /// </summary>
        public Thickness WindowResizeBorderThickness
        {
            get => (Thickness)this.GetValue(CustomizedWindow.WindowResizeBorderThicknessProperty);
            set => this.SetValue(CustomizedWindow.WindowResizeBorderThicknessProperty, value);
        }
        #endregion
        
        #region IsWindowResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体缩放区域之内。
        /// </summary>
        public bool IsWindowResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowResizeAreaMouseEnter"/> 和 <see cref="WindowResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowResizeAreaMouseEnter"/>
        /// <seealso cref="WindowResizeAreaMouseLeave"/>
        private static void IsWindowResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion



        #region WindowNorthResizeArea Properties
        #region WindowNorthResizeArea
        public static readonly DependencyProperty WindowNorthResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowNorthResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowNorthResizeArea
        {
            get => (Geometry)this.GetValue(WindowNorthResizeAreaProperty);
            set => this.SetValue(WindowNorthResizeAreaProperty, value);
        }
        #endregion

        #region WindowNorthResizeAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowNorthResizeAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowNorthResizeAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowNorthResizeAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowNorthResizeAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowNorthResizeAreaSpecificPartsProperty = CustomizedWindow.WindowNorthResizeAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体向上缩放区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowNorthResizeAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowNorthResizeAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowNorthResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowNorthResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowNorthResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowNorthResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowNorthResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowNorthResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体向上缩放区域之内。
        /// </summary>
        public bool IsWindowNorthResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowNorthResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowNorthResizeAreaMouseEnter"/> 和 <see cref="WindowNorthResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowNorthResizeAreaMouseEnter"/>
        /// <seealso cref="WindowNorthResizeAreaMouseLeave"/>
        private static void IsWindowNorthResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowNorthResizeAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowNorthResizeAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowNorthResizeAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowNorthResizeAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowNorthResizeAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowNorthResizeAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowNorthResizeAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowNorthResizeAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowNorthResizeAreaSpecificParts.Add(element);
                else
                    window.WindowNorthResizeAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowNorthResizeAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowNorthResizeAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowNorthResizeAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowNorthResizeAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthResizeAreaPart 附加属性值。</returns>
        public static bool GetIsWindowNorthResizeAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowNorthResizeAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowNorthResizeAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowNorthResizeAreaPartProperty, value);
        #endregion
        #endregion

        #region WindowSouthResizeArea Properties
        #region WindowSouthResizeArea
        public static readonly DependencyProperty WindowSouthResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowSouthResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowSouthResizeArea
        {
            get => (Geometry)this.GetValue(WindowSouthResizeAreaProperty);
            set => this.SetValue(WindowSouthResizeAreaProperty, value);
        }
        #endregion

        #region WindowSouthResizeAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowSouthResizeAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowSouthResizeAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowSouthResizeAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowSouthResizeAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowSouthResizeAreaSpecificPartsProperty = CustomizedWindow.WindowSouthResizeAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体向下缩放区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowSouthResizeAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowSouthResizeAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowSouthResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowSouthResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowSouthResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowSouthResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowSouthResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowSouthResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体向下缩放区域之内。
        /// </summary>
        public bool IsWindowSouthResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowSouthResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowSouthResizeAreaMouseEnter"/> 和 <see cref="WindowSouthResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowSouthResizeAreaMouseEnter"/>
        /// <seealso cref="WindowSouthResizeAreaMouseLeave"/>
        private static void IsWindowSouthResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowSouthResizeAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowSouthResizeAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowSouthResizeAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowSouthResizeAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowSouthResizeAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowSouthResizeAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowSouthResizeAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowSouthResizeAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowSouthResizeAreaSpecificParts.Add(element);
                else
                    window.WindowSouthResizeAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowSouthResizeAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowSouthResizeAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowSouthResizeAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowSouthResizeAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthResizeAreaPart 附加属性值。</returns>
        public static bool GetIsWindowSouthResizeAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowSouthResizeAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowSouthResizeAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowSouthResizeAreaPartProperty, value);
        #endregion
        #endregion

        #region WindowWestResizeArea Properties
        #region WindowWestResizeArea
        public static readonly DependencyProperty WindowWestResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowWestResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowWestResizeArea
        {
            get => (Geometry)this.GetValue(WindowWestResizeAreaProperty);
            set => this.SetValue(WindowWestResizeAreaProperty, value);
        }
        #endregion

        #region WindowWestResizeAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowWestResizeAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowWestResizeAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowWestResizeAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowWestResizeAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowWestResizeAreaSpecificPartsProperty = CustomizedWindow.WindowWestResizeAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体向左缩放区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowWestResizeAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowWestResizeAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowWestResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowWestResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowWestResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowWestResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowWestResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowWestResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体向左缩放区域之内。
        /// </summary>
        public bool IsWindowWestResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowWestResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowWestResizeAreaMouseEnter"/> 和 <see cref="WindowWestResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowWestResizeAreaMouseEnter"/>
        /// <seealso cref="WindowWestResizeAreaMouseLeave"/>
        private static void IsWindowWestResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowWestResizeAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowWestResizeAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowWestResizeAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowWestResizeAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowWestResizeAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowWestResizeAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowWestResizeAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowWestResizeAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowWestResizeAreaSpecificParts.Add(element);
                else
                    window.WindowWestResizeAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowWestResizeAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowWestResizeAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowWestResizeAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowWestResizeAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowWestResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowWestResizeAreaPart 附加属性值。</returns>
        public static bool GetIsWindowWestResizeAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowWestResizeAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowWestResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowWestResizeAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowWestResizeAreaPartProperty, value);
        #endregion
        #endregion

        #region WindowEastResizeArea Properties
        #region WindowEastResizeArea
        public static readonly DependencyProperty WindowEastResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowEastResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowEastResizeArea
        {
            get => (Geometry)this.GetValue(WindowEastResizeAreaProperty);
            set => this.SetValue(WindowEastResizeAreaProperty, value);
        }
        #endregion

        #region WindowEastResizeAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowEastResizeAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowEastResizeAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowEastResizeAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowEastResizeAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowEastResizeAreaSpecificPartsProperty = CustomizedWindow.WindowEastResizeAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体向由缩放区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowEastResizeAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowEastResizeAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowEastResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowEastResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowEastResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowEastResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowEastResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowEastResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体向由缩放区域之内。
        /// </summary>
        public bool IsWindowEastResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowEastResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowEastResizeAreaMouseEnter"/> 和 <see cref="WindowEastResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowEastResizeAreaMouseEnter"/>
        /// <seealso cref="WindowEastResizeAreaMouseLeave"/>
        private static void IsWindowEastResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowEastResizeAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowEastResizeAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowEastResizeAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowEastResizeAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowEastResizeAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowEastResizeAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowEastResizeAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowEastResizeAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowEastResizeAreaSpecificParts.Add(element);
                else
                    window.WindowEastResizeAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowEastResizeAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowEastResizeAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowEastResizeAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowEastResizeAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowEastResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowEastResizeAreaPart 附加属性值。</returns>
        public static bool GetIsWindowEastResizeAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowEastResizeAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowEastResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowEastResizeAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowEastResizeAreaPartProperty, value);
        #endregion
        #endregion

        #region WindowNorthWestResizeArea Properties
        #region WindowNorthWestResizeArea
        public static readonly DependencyProperty WindowNorthWestResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowNorthWestResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowNorthWestResizeArea
        {
            get => (Geometry)this.GetValue(WindowNorthWestResizeAreaProperty);
            set => this.SetValue(WindowNorthWestResizeAreaProperty, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowNorthWestResizeAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowNorthWestResizeAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowNorthWestResizeAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowNorthWestResizeAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowNorthWestResizeAreaSpecificPartsProperty = CustomizedWindow.WindowNorthWestResizeAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体向左上缩放区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowNorthWestResizeAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowNorthWestResizeAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowNorthWestResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowNorthWestResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowNorthWestResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowNorthWestResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowNorthWestResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体向左上缩放区域之内。
        /// </summary>
        public bool IsWindowNorthWestResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowNorthWestResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowNorthWestResizeAreaMouseEnter"/> 和 <see cref="WindowNorthWestResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowNorthWestResizeAreaMouseEnter"/>
        /// <seealso cref="WindowNorthWestResizeAreaMouseLeave"/>
        private static void IsWindowNorthWestResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowNorthWestResizeAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowNorthWestResizeAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowNorthWestResizeAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowNorthWestResizeAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowNorthWestResizeAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowNorthWestResizeAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowNorthWestResizeAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowNorthWestResizeAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowNorthWestResizeAreaSpecificParts.Add(element);
                else
                    window.WindowNorthWestResizeAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowNorthWestResizeAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowNorthWestResizeAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowNorthWestResizeAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowNorthWestResizeAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthWestResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthWestResizeAreaPart 附加属性值。</returns>
        public static bool GetIsWindowNorthWestResizeAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowNorthWestResizeAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthWestResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowNorthWestResizeAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowNorthWestResizeAreaPartProperty, value);
        #endregion
        #endregion

        #region WindowNorthEastResizeArea Properties
        #region WindowNorthEastResizeArea
        public static readonly DependencyProperty WindowNorthEastResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowNorthEastResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowNorthEastResizeArea
        {
            get => (Geometry)this.GetValue(WindowNorthEastResizeAreaProperty);
            set => this.SetValue(WindowNorthEastResizeAreaProperty, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowNorthEastResizeAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowNorthEastResizeAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowNorthEastResizeAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowNorthEastResizeAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowNorthEastResizeAreaSpecificPartsProperty = CustomizedWindow.WindowNorthEastResizeAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体向右上缩放区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowNorthEastResizeAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowNorthEastResizeAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowNorthEastResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowNorthEastResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowNorthEastResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowNorthEastResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowNorthEastResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体向右上缩放区域之内。
        /// </summary>
        public bool IsWindowNorthEastResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowNorthEastResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowNorthEastResizeAreaMouseEnter"/> 和 <see cref="WindowNorthEastResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowNorthEastResizeAreaMouseEnter"/>
        /// <seealso cref="WindowNorthEastResizeAreaMouseLeave"/>
        private static void IsWindowNorthEastResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowNorthEastResizeAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowNorthEastResizeAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowNorthEastResizeAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowNorthEastResizeAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowNorthEastResizeAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowNorthEastResizeAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowNorthEastResizeAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowNorthEastResizeAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowNorthEastResizeAreaSpecificParts.Add(element);
                else
                    window.WindowNorthEastResizeAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowNorthEastResizeAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowNorthEastResizeAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowNorthEastResizeAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowNorthEastResizeAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthEastResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthEastResizeAreaPart 附加属性值。</returns>
        public static bool GetIsWindowNorthEastResizeAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowNorthEastResizeAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowNorthEastResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowNorthEastResizeAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowNorthEastResizeAreaPartProperty, value);
        #endregion
        #endregion

        #region WindowSouthEastResizeArea Properties
        #region WindowSouthEastResizeArea
        public static readonly DependencyProperty WindowSouthEastResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowSouthEastResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowSouthEastResizeArea
        {
            get => (Geometry)this.GetValue(WindowSouthEastResizeAreaProperty);
            set => this.SetValue(WindowSouthEastResizeAreaProperty, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowSouthEastResizeAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowSouthEastResizeAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowSouthEastResizeAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowSouthEastResizeAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowSouthEastResizeAreaSpecificPartsProperty = CustomizedWindow.WindowSouthEastResizeAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体向右下缩放区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowSouthEastResizeAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowSouthEastResizeAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowSouthEastResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowSouthEastResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowSouthEastResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowSouthEastResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowSouthEastResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体向右下缩放区域之内。
        /// </summary>
        public bool IsWindowSouthEastResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowSouthEastResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowSouthEastResizeAreaMouseEnter"/> 和 <see cref="WindowSouthEastResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowSouthEastResizeAreaMouseEnter"/>
        /// <seealso cref="WindowSouthEastResizeAreaMouseLeave"/>
        private static void IsWindowSouthEastResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowSouthEastResizeAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowSouthEastResizeAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowSouthEastResizeAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowSouthEastResizeAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowSouthEastResizeAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowSouthEastResizeAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowSouthEastResizeAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowSouthEastResizeAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowSouthEastResizeAreaSpecificParts.Add(element);
                else
                    window.WindowSouthEastResizeAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowSouthEastResizeAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowSouthEastResizeAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowSouthEastResizeAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowSouthEastResizeAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthEastResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthEastResizeAreaPart 附加属性值。</returns>
        public static bool GetIsWindowSouthEastResizeAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowSouthEastResizeAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthEastResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowSouthEastResizeAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowSouthEastResizeAreaPartProperty, value);
        #endregion
        #endregion

        #region WindowSouthWestResizeArea Properties
        #region WindowSouthWestResizeArea
        public static readonly DependencyProperty WindowSouthWestResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowSouthWestResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowSouthWestResizeArea
        {
            get => (Geometry)this.GetValue(WindowSouthWestResizeAreaProperty);
            set => this.SetValue(WindowSouthWestResizeAreaProperty, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaParts
        /// <summary>
        /// 标志只读的 <see cref="WindowSouthWestResizeAreaSpecificParts"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey WindowSouthWestResizeAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowSouthWestResizeAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        /// <summary>
        /// 标志 <see cref="WindowSouthWestResizeAreaSpecificParts"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WindowSouthWestResizeAreaSpecificPartsProperty = CustomizedWindow.WindowSouthWestResizeAreaSpecificPartsPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取表示窗体向左下缩放区域的 <see cref="UIElement"/> 集合。
        /// </summary>
        public SpecificPartCollection<UIElement> WindowSouthWestResizeAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowSouthWestResizeAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowSouthWestResizeAreaMouseWithin
        /// <summary>
        /// 标志只读的 <see cref="IsWindowSouthWestResizeAreaMouseWithin"/> 依赖属性键。
        /// </summary>
        public static readonly DependencyPropertyKey IsWindowSouthWestResizeAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyChanged
                )
            );
        /// <summary>
        /// 标志 <see cref="IsWindowSouthWestResizeAreaMouseWithin"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowSouthWestResizeAreaMouseWithinProperty =
            CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey.DependencyProperty;

        /// <summary>
        /// 获取一个值，指示鼠标指针是否在窗体向左下缩放区域之内。
        /// </summary>
        public bool IsWindowSouthWestResizeAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinProperty);
        }

        /// <summary>
        /// 当 <see cref="IsWindowSouthWestResizeAreaMouseWithin"/> 依赖属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此依赖属性的对象。</param>
        /// <param name="e">依赖属性的值改变的事件的参数。</param>
        /// <remarks>
        /// 引发 <see cref="WindowSouthWestResizeAreaMouseEnter"/> 和 <see cref="WindowSouthWestResizeAreaMouseLeave"/> 路由事件。
        /// </remarks>
        /// <seealso cref="WindowSouthWestResizeAreaMouseEnter"/>
        /// <seealso cref="WindowSouthWestResizeAreaMouseLeave"/>
        private static void IsWindowSouthWestResizeAreaMouseWithinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedWindow window = d as CustomizedWindow;
            bool mouseEnter = (bool)e.NewValue;
            if (mouseEnter)
                // 鼠标进入。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseEnterEvent
                    }
                );
            else
                // 鼠标离开。
                window.RaiseEvent(
                    new MouseEventArgs(Mouse.PrimaryDevice, Environment.TickCount)
                    {
                        RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseLeaveEvent
                    }
                );
        }
        #endregion

        #region IsWindowSouthWestResizeAreaPart
        /// <summary>
        /// 标志 <see cref="CustomizedWindow"/> 的 IsWindowSouthWestResizeAreaPart 附加属性。
        /// </summary>
        public static readonly DependencyProperty IsWindowSouthWestResizeAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowSouthWestResizeAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowSouthWestResizeAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowSouthWestResizeAreaPartCoerceValue
                )
            );

        /// <summary>
        /// 当 <see cref="CustomizedWindow"/> 的 IsWindowSouthWestResizeAreaPart 附加属性的值发生变化的处理程序。
        /// </summary>
        /// <param name="d">拥有此附加属性的对象。</param>
        /// <param name="e">附加属性的值改变的事件的参数。</param>
        private static void IsWindowSouthWestResizeAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowSouthWestResizeAreaSpecificParts.Add(element);
                else
                    window.WindowSouthWestResizeAreaSpecificParts.Remove(element);
            }
        }

        /// <summary>
        /// 对 <see cref="CustomizedWindow"/> 的 IsWindowSouthWestResizeAreaPart 附加属性的新值进行强制转换。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在 <see cref="CustomizedWindow"/> 的 IsWindowSouthWestResizeAreaPart 附加属性的值改变前，若 <see cref="CustomizedWindow"/> 的 CustomizedWindowAncestor 附加属性的值为 <see langword="null"/> ，则以 <paramref name="d"/> 为基点沿可视化树向上逐级查找。若查找到第一个 <see cref="CustomizedWindow"/> 或继承其的父元素，则将其设为 <see cref="CustomizedWindow"/> 的 IsWindowSouthWestResizeAreaPart 附加属性的值。
        /// </remarks>
        /// <seealso cref="CustomizedWindow.GetCustomizedWindowAncestor(UIElement)"/>
        /// <seealso cref="CustomizedWindow.SetCustomizedWindowAncestor(UIElement, CustomizedWindow)"/>
        private static object IsWindowSouthWestResizeAreaPartCoerceValue(DependencyObject d, object baseValue)
        {
            UIElement element = d as UIElement;
            if (CustomizedWindow.GetCustomizedWindowAncestor(element) == null)
            {
                DependencyObject obj;
                for (obj = d; obj != null && !(obj is CustomizedWindow); obj = VisualTreeHelper.GetParent(obj)) ;
                if (obj != null)
                    CustomizedWindow.SetCustomizedWindowAncestor(element, obj as CustomizedWindow);
            }

            return baseValue;
        }

        /// <summary>
        /// 获取对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthWestResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">从中读取属性值的对象。</param>
        /// <returns>对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthWestResizeAreaPart 附加属性值。</returns>
        public static bool GetIsWindowSouthWestResizeAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowSouthWestResizeAreaPartProperty);

        /// <summary>
        /// 设置对象的  <see cref="CustomizedWindow"/> 的 IsWindowSouthWestResizeAreaPart 附加属性值。
        /// </summary>
        /// <param name="element">要写入该附加属性的对象。</param>
        /// <param name="value">要设置的值。</param>
        public static void SetIsWindowSouthWestResizeAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowSouthWestResizeAreaPartProperty, value);
        #endregion
        #endregion
        #endregion
        #endregion

        #region Events
        #region WindowTitleArea MouseEvents
        #region WindowTitleAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowTitleAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseDoubleClickEvent, value);
        }
        #endregion
        
        #region WindowTitleAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowTitleAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowTitleAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowTitleAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowTitleAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowTitleAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowTitleAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowTitleAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseEnterEvent, value);
        }
        #endregion
        
        #region WindowTitleAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体标题区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowTitleAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowTitleAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowTitleAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowTitleAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowTitleAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowTitleAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowTitleAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowTitleAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowTitleAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowTitleAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowTitleAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowTitleAreaMouseUp
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowTitleAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowTitleAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowTitleAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowTitleAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowTitleAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowTitleAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowTitleAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowTitleAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowTitleAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowTitleAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowTitleAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseRightButtonUpEvent, value);
        }
        #endregion
        
        #region PreviewWindowTitleAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowTitleAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowTitleAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowTitleAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowTitleAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowTitleAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowTitleAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体标题区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowTitleAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowTitleAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowTitleAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion
        
        #region WindowResizeArea MouseEvents
        #region WindowResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowResizeAreaMouseWheelEvent, value);
        }
        #endregion



        #region WindowNorthResizeArea MouseEvents
        #region WindowNorthResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体向上缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowNorthResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowNorthResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowNorthResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowNorthResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowNorthResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向上缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowNorthResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthResizeAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion

        #region WindowSouthResizeArea MouseEvents
        #region WindowSouthResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体向下缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowSouthResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowSouthResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowSouthResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowSouthResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowSouthResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向下缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowSouthResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthResizeAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion

        #region WindowWestResizeArea MouseEvents
        #region WindowWestResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowWestResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowWestResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowWestResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowWestResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowWestResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowWestResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowWestResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowWestResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体向左缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowWestResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowWestResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowWestResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowWestResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowWestResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowWestResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowWestResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowWestResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowWestResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowWestResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowWestResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowWestResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowWestResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowWestResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowWestResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowWestResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowWestResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowWestResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowWestResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowWestResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowWestResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowWestResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowWestResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowWestResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowWestResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowWestResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowWestResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowWestResizeAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion

        #region WindowEastResizeArea MouseEvents
        #region WindowEastResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowEastResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowEastResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowEastResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowEastResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowEastResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowEastResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowEastResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowEastResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体向右缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowEastResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowEastResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowEastResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowEastResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowEastResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowEastResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowEastResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowEastResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowEastResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowEastResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowEastResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowEastResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowEastResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowEastResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowEastResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowEastResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowEastResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowEastResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowEastResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowEastResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowEastResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowEastResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowEastResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowEastResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowEastResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowEastResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowEastResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowEastResizeAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion

        #region WindowNorthWestResizeArea MouseEvents
        #region WindowNorthWestResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthWestResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthWestResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthWestResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthWestResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthWestResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthWestResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthWestResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthWestResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体向左上缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthWestResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthWestResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowNorthWestResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowNorthWestResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthWestResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthWestResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowNorthWestResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthWestResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthWestResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthWestResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthWestResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthWestResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthWestResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthWestResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthWestResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthWestResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthWestResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthWestResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthWestResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthWestResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowNorthWestResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowNorthWestResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthWestResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthWestResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左上缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowNorthWestResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion

        #region WindowNorthEastResizeArea MouseEvents
        #region WindowNorthEastResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthEastResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthEastResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthEastResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthEastResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthEastResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthEastResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowNorthEastResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthEastResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体向右上缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthEastResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowNorthEastResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowNorthEastResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowNorthEastResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowNorthEastResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowNorthEastResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowNorthEastResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowNorthEastResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthEastResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthEastResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthEastResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthEastResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthEastResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthEastResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthEastResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthEastResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthEastResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthEastResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowNorthEastResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthEastResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowNorthEastResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowNorthEastResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowNorthEastResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowNorthEastResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右上缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowNorthEastResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion

        #region WindowSouthEastResizeArea MouseEvents
        #region WindowSouthEastResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthEastResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthEastResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthEastResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthEastResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthEastResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthEastResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthEastResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthEastResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体向右下缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthEastResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthEastResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowSouthEastResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowSouthEastResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthEastResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthEastResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowSouthEastResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthEastResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthEastResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthEastResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthEastResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthEastResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthEastResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthEastResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthEastResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthEastResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthEastResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthEastResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthEastResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthEastResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowSouthEastResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowSouthEastResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthEastResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthEastResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向右下缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowSouthEastResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion

        #region WindowSouthWestResizeArea MouseEvents
        #region WindowSouthWestResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthWestResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthWestResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseUp
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthWestResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthWestResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseLeftButtonUp
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseLeftButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthWestResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseRightButtonDown
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseRightButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthWestResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler WindowSouthWestResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseEnter
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseEnter"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针进入窗体区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthWestResizeAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseEnterEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseLeave
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseLeave"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当鼠标指针离开窗体向左下缩放区域边界时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthWestResizeAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler WindowSouthWestResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowSouthWestResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="WindowSouthWestResizeAreaMouseWheel"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent WindowSouthWestResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowSouthWestResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler WindowSouthWestResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowSouthWestResizeAreaMouseWheelEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseDoubleClick
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthWestResizeAreaMouseDoubleClick"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内双击或多次单击鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthWestResizeAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthWestResizeAreaMouseDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内按下任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthWestResizeAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseUp
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内松开任意鼠标按钮时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthWestResizeAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseLeftButtonDown
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthWestResizeAreaMouseLeftButtonDown"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内按下鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthWestResizeAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseLeftButtonUp
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内松开鼠标左键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthWestResizeAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseRightButtonDown
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内按下鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthWestResizeAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseRightButtonUp
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthWestResizeAreaMouseRightButtonUp"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内松开鼠标右键时发生。
        /// </summary>
        public event MouseButtonEventHandler PreviewWindowSouthWestResizeAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseMove
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthWestResizeAreaMouseMove"/> 路由事件。
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内并且移动鼠标指针时发生。
        /// </summary>
        public event MouseEventHandler PreviewWindowSouthWestResizeAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseMoveEvent, value);
        }
        #endregion

        #region PreviewWindowSouthWestResizeAreaMouseWheel
        /// <summary>
        /// 标识 <see cref="PreviewWindowSouthWestResizeAreaMouseWheel"/> 路由事件
        /// </summary>
        public static readonly RoutedEvent PreviewWindowSouthWestResizeAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        /// <summary>
        /// 当指针在窗体向左下缩放区域内并且用户滚动鼠标滚轮时发生。
        /// </summary>
        public event MouseWheelEventHandler PreviewWindowSouthWestResizeAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseWheelEvent, value);
        }
        #endregion
        #endregion
        #endregion
        #endregion

        static CustomizedWindow()
        {

        }

        /// <summary>
        /// 初始化 <see cref="CustomizedWindow"/> 的新实例。
        /// </summary>
        public CustomizedWindow() : base()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.Background = new SolidColorBrush(Colors.Transparent);
            this.MouseDoubleClick += this.CustomizedWindow_MouseDoubleClick;
            this.MouseDown += this.CustomizedWindow_MouseDown;
            this.MouseUp += this.CustomizedWindow_MouseUp;
            this.MouseLeftButtonDown += this.CustomizedWindow_MouseLeftButtonDown;
            this.MouseLeftButtonUp += this.CustomizedWindow_MouseLeftButtonUp;
            this.MouseRightButtonDown += this.CustomizedWindow_MouseRightButtonDown;
            this.MouseRightButtonUp += this.CustomizedWindow_MouseRightButtonUp;
            this.MouseMove += this.CustomizedWindow_MouseMove;
            this.MouseWheel += this.CustomizedWindow_MouseWheel;
            this.PreviewMouseDoubleClick += this.CustomizedWindow_PreviewMouseDoubleClick;
            this.PreviewMouseDown += this.CustomizedWindow_PreviewMouseDown;
            this.PreviewMouseUp += this.CustomizedWindow_PreviewMouseUp;
            this.PreviewMouseLeftButtonDown += this.CustomizedWindow_PreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonUp += this.CustomizedWindow_PreviewMouseLeftButtonUp;
            this.PreviewMouseRightButtonDown += this.CustomizedWindow_PreviewMouseRightButtonDown;
            this.PreviewMouseRightButtonUp += this.CustomizedWindow_PreviewMouseRightButtonUp;
            this.PreviewMouseMove += this.CustomizedWindow_PreviewMouseMove;
            this.PreviewMouseWheel += this.CustomizedWindow_PreviewMouseWheel;
            
            this.WindowTitleAreaMouseMove += this.CustomizedWindow_WindowTitleAreaMouseMove;
            this.WindowTitleAreaMouseLeftButtonDown += this.CustomizedWindow_WindowTitleAreaMouseLeftButtonDown;
        }

        #region RedirectingEventHandlers
        /// <summary>
        /// 改变 <see cref="IsWindowResizeAreaMouseWithin"/> 、 <see cref="IsWindowNorthResizeAreaMouseWithin"/> 、 <see cref="IsWindowSouthResizeAreaMouseWithin"/> 、 <see cref="IsWindowWestResizeAreaMouseWithin"/> 、 <see cref="IsWindowEastResizeAreaMouseWithin"/> 、 <see cref="IsWindowNorthWestResizeAreaMouseWithin"/> 、 <see cref="IsWindowNorthEastResizeAreaMouseWithin"/> 、 <see cref="IsWindowSouthEastResizeAreaMouseWithin"/> 、 <see cref="IsWindowSouthWestResizeAreaMouseWithin"/> 的值。
        /// </summary>
        /// <param name="direction">鼠标指针所在的区域的方向。</param>
        /// <seealso cref="IsWindowResizeAreaMouseWithin"/>
        /// <seealso cref="IsWindowNorthResizeAreaMouseWithin"/>
        /// <seealso cref="IsWindowSouthResizeAreaMouseWithin"/>
        /// <seealso cref="IsWindowWestResizeAreaMouseWithin"/>
        /// <seealso cref="IsWindowEastResizeAreaMouseWithin"/>
        /// <seealso cref="IsWindowNorthWestResizeAreaMouseWithin"/>
        /// <seealso cref="IsWindowNorthEastResizeAreaMouseWithin"/>
        /// <seealso cref="IsWindowSouthEastResizeAreaMouseWithin"/>
        /// <seealso cref="IsWindowSouthWestResizeAreaMouseWithin"/>
        private void WindowResizeDirectionChanged(WindowResizeDirection direction)
        {
            if (Enum.IsDefined(typeof(WindowResizeDirection), direction))
            {
                this.SetValue(CustomizedWindow.IsWindowResizeAreaMouseWithinPropertyKey, true);
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.SetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey, false);

                        this.SetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey, true);
                        break;
                    case WindowResizeDirection.South:
                        this.SetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey, false);

                        this.SetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey, true);
                        break;
                    case WindowResizeDirection.West:
                        this.SetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey, false);

                        this.SetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey, true);
                        break;
                    case WindowResizeDirection.East:
                        this.SetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey, false);

                        this.SetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey, true);
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.SetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey, false);

                        this.SetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey, true);
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.SetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey, false);

                        this.SetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey, true);
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.SetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey, false);

                        this.SetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey, true);
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.SetValue(CustomizedWindow.IsWindowNorthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthWestResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowNorthEastResizeAreaMouseWithinPropertyKey, false);
                        this.SetValue(CustomizedWindow.IsWindowSouthEastResizeAreaMouseWithinPropertyKey, false);

                        this.SetValue(CustomizedWindow.IsWindowSouthWestResizeAreaMouseWithinPropertyKey, true);
                        break;
                }
            }
            else
                this.SetValue(CustomizedWindow.IsWindowResizeAreaMouseWithinPropertyKey, false);
        }

        private void CustomizedWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);

            if (this.WindowTitleAreaContains(mousePosition))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseDoubleClickEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseDoubleClickEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);

            if (this.WindowTitleAreaContains(mousePosition))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseDownEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseDownEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseDownEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);

            if (this.WindowTitleAreaContains(mousePosition))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseUpEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseUpEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseUpEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);

            if (this.WindowTitleAreaContains(mousePosition))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseLeftButtonDownEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseLeftButtonDownEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(mousePosition))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseLeftButtonUpEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseLeftButtonUpEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(mousePosition))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseRightButtonDownEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseRightButtonDownEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(mousePosition))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseRightButtonUpEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseRightButtonUpEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            // 设置是否鼠标指针在窗体标题区域内。
            this.SetValue(CustomizedWindow.IsWindowTitleAreaMouseWithinPropertyKey, this.WindowTitleAreaContains(mousePosition));
            if (this.IsWindowTitleAreaMouseWithin)
                this.RaiseEvent(
                    new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseMoveEvent
                    }
                );

            // 设置是否鼠标指针在窗体各个缩放区域内。
            bool windowResizeAreaContains = this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction);
            this.WindowResizeDirectionChanged(direction); // 引发 MouseEnter 和 MouseLeave 事件。
            if (windowResizeAreaContains)
            {
                this.RaiseEvent(
                    new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseMoveEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                }
            }
            
            this.RefreshCursor(mousePosition);
        }

        private void CustomizedWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseWheelEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                    {
                        RoutedEvent = CustomizedWindow.WindowResizeAreaMouseWheelEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.WindowWestResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.WindowEastResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthWestResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.WindowNorthEastResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthEastResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.WindowSouthWestResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseDoubleClickEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseDoubleClickEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseDoubleClickEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseDownEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseDownEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseDownEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseUpEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseUpEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseUpEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseLeftButtonDownEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseLeftButtonDownEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseLeftButtonDownEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseLeftButtonUpEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseLeftButtonUpEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseLeftButtonUpEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseRightButtonDownEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseRightButtonDownEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseRightButtonDownEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseRightButtonUpEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseRightButtonUpEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseRightButtonUpEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseMoveEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseMoveEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseMoveEvent
                            }
                        );
                        break;
                }
            }
        }

        private void CustomizedWindow_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowTitleAreaMouseWheelEvent
                    }
                );

            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                this.RaiseEvent(
                    new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                    {
                        RoutedEvent = CustomizedWindow.PreviewWindowResizeAreaMouseWheelEvent
                    }
                );
                switch (direction)
                {
                    case WindowResizeDirection.North:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.South:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.West:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowWestResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.East:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowEastResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthWest:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthWestResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.NorthEast:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowNorthEastResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthEast:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthEastResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                    case WindowResizeDirection.SouthWest:
                        this.RaiseEvent(
                            new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                            {
                                RoutedEvent = CustomizedWindow.PreviewWindowSouthWestResizeAreaMouseWheelEvent
                            }
                        );
                        break;
                }
            }
        }
        #endregion

        /// <summary>
        /// 获取一个值，指示指定点是否在一个 <see cref="UIElement"/> 的集合或一个 <see cref="Geometry"/> 形状对象表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <param name="specificParts">表示区域的 <see cref="UIElement"/> 的集合。</param>
        /// <param name="geometry">表示区域的形状对象。</param>
        /// <returns>指定的点在区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <remarks>
        /// 当 <paramref name="specificParts"/> 不为 <see langword="null"/> 或空集合时，则以 <paramref name="specificParts"/> 表示区域，忽略参数 <paramref name="geometry"/> ；否则以 <paramref name="geometry"/> 表示区域。
        /// </remarks>
        protected virtual bool AreaContains(Point mousePosition, ICollection<UIElement> specificParts = null, Geometry geometry = null)
        {
            if (specificParts?.Count != 0)
            // 若可视化元素集合不为 null 且不为空集合。
            {
                Point defaultPoint = new Point(0, 0);
                foreach (var uielement in specificParts)
                {
                    if (uielement.IsMouseOver)
                        return true;
                }
            }
            else
            {
                if (geometry?.FillContains(mousePosition) == true)
                    return true;
            }

            return false;
        }
        
        /// <summary>
        /// 获取一个值，指示指定点是否在窗体标题区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体标题区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowTitleAreaSpecificParts"/>
        /// <seealso cref="WindowTitleArea"/>
        protected internal virtual bool WindowTitleAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowTitleAreaSpecificParts, this.WindowTitleArea);

        #region WindowResizeAreaContains
        #region WindowNorthResizeAreaContains
        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowNorthResizeAreaSpecificParts"/> 或 <see cref="WindowNorthResizeArea"/> 表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向上缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowNorthResizeAreaSpecificParts"/>
        /// <seealso cref="WindowNorthResizeArea"/>
        protected internal virtual bool WindowNorthResizeAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowNorthResizeAreaSpecificParts, this.WindowNorthResizeArea);

        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowResizeBorderThickness"/> 表示的向上缩放区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向上缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="WindowResizeBorderThickness"/>
        protected internal virtual bool WindowNorthResizeBorderAreaContains(Point mousePosition)
        {
            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            return resizeBorderThickness.Top != 0 &&
                new Rect(
                    new Point(resizeBorderThickness.Left, 0),
                    new Point(this.ActualWidth - resizeBorderThickness.Right, resizeBorderThickness.Top)
                ).Contains(mousePosition);
        }
        #endregion

        #region WindowSouthResizeAreaContains
        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowSouthResizeAreaSpecificParts"/> 或 <see cref="WindowSouthResizeArea"/> 表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向下缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowSouthResizeAreaSpecificParts"/>
        /// <seealso cref="WindowSouthResizeArea"/>
        protected internal virtual bool WindowSouthResizeAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowSouthResizeAreaSpecificParts, this.WindowSouthResizeArea);

        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowResizeBorderThickness"/> 表示的向下缩放区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向下缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="WindowResizeBorderThickness"/>
        protected internal virtual bool WindowSouthResizeBorderAreaContains(Point mousePosition)
        {
            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            return resizeBorderThickness.Bottom != 0 &&
                new Rect(
                    new Point(resizeBorderThickness.Left, this.ActualHeight - resizeBorderThickness.Bottom),
                    new Point(this.ActualWidth - resizeBorderThickness.Right, this.ActualWidth)
                ).Contains(mousePosition);
        }
        #endregion

        #region WindowWestResizeAreaContains
        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowWestResizeAreaSpecificParts"/> 或 <see cref="WindowWestResizeArea"/> 表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向左缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowWestResizeAreaSpecificParts"/>
        /// <seealso cref="WindowWestResizeArea"/>
        protected internal virtual bool WindowWestResizeAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowWestResizeAreaSpecificParts, this.WindowWestResizeArea);

        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowResizeBorderThickness"/> 表示的向左缩放区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向左缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="WindowResizeBorderThickness"/>
        protected internal virtual bool WindowWestResizeBorderAreaContains(Point mousePosition)
        {
            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            return resizeBorderThickness.Left != 0 &&
                new Rect(
                    new Point(0, resizeBorderThickness.Top),
                    new Size(resizeBorderThickness.Left, this.ActualHeight - resizeBorderThickness.Bottom)
                ).Contains(mousePosition);
        }
        #endregion

        #region WindowEastResizeAreaContains
        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowEastResizeAreaSpecificParts"/> 或 <see cref="WindowEastResizeArea"/> 表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向右缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowEastResizeAreaSpecificParts"/>
        /// <seealso cref="WindowEastResizeArea"/>
        protected internal virtual bool WindowEastResizeAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowEastResizeAreaSpecificParts, this.WindowEastResizeArea);

        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowResizeBorderThickness"/> 表示的向右缩放区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向右缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="WindowResizeBorderThickness"/>
        protected internal virtual bool WindowEastResizeBorderAreaContains(Point mousePosition)
        {
            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            return resizeBorderThickness.Right != 0 &&
                new Rect(
                    new Point(this.ActualWidth - resizeBorderThickness.Right, resizeBorderThickness.Top),
                    new Point(this.ActualWidth, this.ActualHeight - resizeBorderThickness.Bottom)
                ).Contains(mousePosition);
        }
        #endregion

        #region WindowNorthWestResizeAreaContains
        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowNorthWestResizeAreaSpecificParts"/> 或 <see cref="WindowNorthWestResizeArea"/> 表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向左上缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowNorthWestResizeAreaSpecificParts"/>
        /// <seealso cref="WindowNorthWestResizeArea"/>
        protected internal virtual bool WindowNorthWestResizeAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowNorthWestResizeAreaSpecificParts, this.WindowNorthWestResizeArea);

        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowResizeBorderThickness"/> 表示的向左上缩放区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向左上缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="WindowResizeBorderThickness"/>
        protected internal virtual bool WindowNorthWestResizeBorderAreaContains(Point mousePosition)
        {
            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            return (resizeBorderThickness.Top != 0 && resizeBorderThickness.Left != 0) &&
                new Rect(
                    new Point(0, 0),
                    new Point(resizeBorderThickness.Left, resizeBorderThickness.Top)
                ).Contains(mousePosition);
        }
        #endregion

        #region WindowNorthEastResizeAreaContains
        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowNorthEastResizeAreaSpecificParts"/> 或 <see cref="WindowNorthEastResizeArea"/> 表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向右上缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowNorthEastResizeAreaSpecificParts"/>
        /// <seealso cref="WindowNorthEastResizeArea"/>
        protected internal virtual bool WindowNorthEastResizeAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowNorthEastResizeAreaSpecificParts, this.WindowNorthEastResizeArea);

        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowResizeBorderThickness"/> 表示的向右上缩放区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向右上缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="WindowResizeBorderThickness"/>
        protected internal virtual bool WindowNorthEastResizeBorderAreaContains(Point mousePosition)
        {
            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            return (resizeBorderThickness.Top != 0 && resizeBorderThickness.Right != 0) &&
                new Rect(
                    new Point(this.ActualWidth, 0),
                    new Point(this.ActualWidth - resizeBorderThickness.Right, resizeBorderThickness.Top)
                ).Contains(mousePosition);
        }
        #endregion

        #region WindowSouthEastResizeAreaContains
        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowSouthEastResizeAreaSpecificParts"/> 或 <see cref="WindowSouthEastResizeArea"/> 表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向右下缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowSouthEastResizeAreaSpecificParts"/>
        /// <seealso cref="WindowSouthEastResizeArea"/>
        protected internal virtual bool WindowSouthEastResizeAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowSouthEastResizeAreaSpecificParts, this.WindowSouthEastResizeArea);

        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowResizeBorderThickness"/> 表示的向右下缩放区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向右下缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="WindowResizeBorderThickness"/>
        protected internal virtual bool WindowSouthEastResizeBorderAreaContains(Point mousePosition)
        {
            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            return (resizeBorderThickness.Bottom != 0 && resizeBorderThickness.Right != 0) &&
                new Rect(
                    new Point(this.ActualWidth, this.ActualHeight),
                    new Point(this.ActualWidth - resizeBorderThickness.Right, this.ActualHeight - resizeBorderThickness.Bottom)
                ).Contains(mousePosition);
        }
        #endregion

        #region WindowSouthWestResizeAreaContains
        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowSouthWestResizeAreaSpecificParts"/> 或 <see cref="WindowSouthWestResizeArea"/> 表示的区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向左下缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="AreaContains(Point, ICollection{UIElement}, Geometry)"/>
        /// <seealso cref="WindowSouthWestResizeAreaSpecificParts"/>
        /// <seealso cref="WindowSouthWestResizeArea"/>
        protected internal virtual bool WindowSouthWestResizeAreaContains(Point mousePosition) =>
            this.AreaContains(mousePosition, this.WindowSouthWestResizeAreaSpecificParts, this.WindowSouthWestResizeArea);

        /// <summary>
        /// 获取一个值，指示指定点是否在 <see cref="WindowResizeBorderThickness"/> 表示的向左下缩放区域内。
        /// </summary>
        /// <param name="mousePosition">要检测的点。</param>
        /// <returns>指定的点在窗体向左下缩放区域内，则返回 <see langword="true"/> ；否则为 <see langword="false"/> 。</returns>
        /// <seealso cref="WindowResizeBorderThickness"/>
        protected internal virtual bool WindowSouthWestResizeBorderAreaContains(Point mousePosition)
        {
            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            return (resizeBorderThickness.Bottom != 0 && resizeBorderThickness.Left != 0) &&
                new Rect(
                    new Point(0, this.ActualHeight),
                    new Point(resizeBorderThickness.Left, this.ActualHeight - resizeBorderThickness.Bottom)
                ).Contains(mousePosition);
        }
        #endregion

        protected internal virtual bool WindowResizeAreaContains(Point mousePosition, out WindowResizeDirection direction)
        {
            // 检测点是否在向各个方向的可视化元素集合或形状表示的范围内。
            if (this.WindowNorthResizeAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.North;
                return true;
            }
            else if (this.WindowSouthResizeAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.South;
                return true;
            }
            else if (this.WindowWestResizeAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.West;
                return true;
            }
            else if (this.WindowEastResizeAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.East;
                return true;
            }
            else if (this.WindowNorthWestResizeAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.NorthWest;
                return true;
            }
            else if (this.WindowNorthEastResizeAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.NorthEast;
                return true;
            }
            else if (this.WindowSouthEastResizeAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.SouthEast;
                return true;
            }
            else if (this.WindowSouthWestResizeAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.SouthWest;
                return true;
            }

            // 检测点是否在向各个方向的窗体缩放边界宽度表示的范围内。
            if (this.WindowNorthResizeBorderAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.North;
                return true;
            }
            else if (this.WindowSouthResizeBorderAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.South;
                return true;
            }
            else if (this.WindowWestResizeBorderAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.West;
                return true;
            }
            else if (this.WindowEastResizeBorderAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.East;
                return true;
            }
            else if (this.WindowNorthWestResizeBorderAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.NorthWest;
                return true;
            }
            else if (this.WindowNorthEastResizeBorderAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.NorthEast;
                return true;
            }
            else if (this.WindowSouthEastResizeBorderAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.SouthEast;
                return true;
            }
            else if (this.WindowSouthWestResizeBorderAreaContains(mousePosition))
            {
                direction = WindowResizeDirection.SouthWest;
                return true;
            }

            // 点不在窗体缩放区域内。
            direction = default(WindowResizeDirection);
            return false;
        }
        #endregion

        [Obsolete("使用 MouseEnter 、 MouseLeave 代替。", false)]
        protected virtual void RefreshCursor(Point mousePosition)
        {
            Cursor cursor;
            if (this.WindowResizeAreaContains(mousePosition, out WindowResizeDirection direction))
            {
                switch (direction)
                {
                    case WindowResizeDirection.North:
                    case WindowResizeDirection.South:
                        cursor = Cursors.SizeNS;
                        break;
                    case WindowResizeDirection.West:
                    case WindowResizeDirection.East:
                        cursor = Cursors.SizeWE;
                        break;
                    case WindowResizeDirection.NorthWest:
                    case WindowResizeDirection.SouthEast:
                        cursor = Cursors.SizeNWSE;
                        break;
                    case WindowResizeDirection.NorthEast:
                    case WindowResizeDirection.SouthWest:
                        cursor = Cursors.SizeNESW;
                        break;
                    default:
#if true
                        throw new InvalidOperationException();
#else
                        cursor = Cursors.SizeAll;
                        break;
#endif
                }
            }
            else if (this.WindowTitleAreaContains(mousePosition))
                cursor = Cursors.Arrow;
            else
                cursor = null;

            Mouse.OverrideCursor = cursor;
        }

        private void CustomizedWindow_WindowTitleAreaMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                this.DragMove();
            }
        }

        private void CustomizedWindow_WindowTitleAreaMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Minimized) return;

            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.DragMove();
        }

    }
}

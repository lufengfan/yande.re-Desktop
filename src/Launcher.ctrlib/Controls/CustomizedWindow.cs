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

        #region WindowTitleAreaProperty
        public static readonly DependencyProperty WindowTitleAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowTitleArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowTitleArea
        {
            get => (Geometry)this.GetValue(CustomizedWindow.WindowTitleAreaProperty);
            set => this.SetValue(CustomizedWindow.WindowTitleAreaProperty, value);
        }
        #endregion

        #region WindowTitleAreaParts
        public static readonly DependencyPropertyKey WindowTiTleAreaSpecificPartsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(CustomizedWindow.WindowTiTleAreaSpecificParts), typeof(SpecificPartCollection<UIElement>), typeof(CustomizedWindow), new PropertyMetadata(new SpecificPartCollection<UIElement>()));
        public static readonly DependencyProperty WindowTiTleAreaSpecificPartsProperty = CustomizedWindow.WindowTiTleAreaSpecificPartsPropertyKey.DependencyProperty;

        public SpecificPartCollection<UIElement> WindowTiTleAreaSpecificParts
        {
            get => (SpecificPartCollection<UIElement>)this.GetValue(WindowTiTleAreaSpecificPartsProperty);
        }
        #endregion

        #region IsWindowTitleAreaPart
        public static readonly DependencyProperty IsWindowTitleAreaPartProperty =
            DependencyProperty.RegisterAttached(
                "IsWindowTitleAreaPart", typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false, 
                    CustomizedWindow.IsWindowTitleAreaPartPropertyChanged,
                    CustomizedWindow.IsWindowTitleAreaPartCoerceValue
                )
            );

        private static void IsWindowTitleAreaPartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            bool newValue = (bool)e.NewValue;
            CustomizedWindow window = CustomizedWindow.GetCustomizedWindowAncestor(element);
            if (window != null)
            {
                if (newValue)
                    window.WindowTiTleAreaSpecificParts.Add(element);
                else
                    window.WindowTiTleAreaSpecificParts.Remove(element);
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

        public static bool GetIsWindowTitleAreaPart(UIElement element) =>
            (bool)element.GetValue(IsWindowTitleAreaPartProperty);

        public static void SetIsWindowTitleAreaPart(UIElement element, bool value) =>
            element.SetValue(IsWindowTitleAreaPartProperty, value);
        #endregion

        #region CustomizedWindowAncestor
        public static readonly DependencyProperty CustomizedWindowAncestorProperty =
            DependencyProperty.RegisterAttached(
                "CustomizedWindowAncestor", typeof(CustomizedWindow), typeof(CustomizedWindow),
                new PropertyMetadata(
                    null,
                    CustomizedWindow.CustomizedWindowAncestorPropertyChanged
                )
            );

        private static void CustomizedWindowAncestorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;

            if (CustomizedWindow.GetIsWindowTitleAreaPart(element))
            {
                if (e.OldValue != null)
                    (e.OldValue as CustomizedWindow).WindowTiTleAreaSpecificParts.Remove(element);

                if (e.NewValue != null)
                    (e.NewValue as CustomizedWindow).WindowTiTleAreaSpecificParts.Add(element);
            }
        }

        public static CustomizedWindow GetCustomizedWindowAncestor(UIElement element) =>
            (CustomizedWindow)element.GetValue(CustomizedWindowAncestorProperty);

        public static void SetCustomizedWindowAncestor(UIElement element, CustomizedWindow value) =>
            element.SetValue(CustomizedWindowAncestorProperty, value);
        #endregion

        #region IsWindowTitleAreaMouseWithin
        public static readonly DependencyPropertyKey IsWindowTitleAreaMouseWithinPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(CustomizedWindow.IsWindowTitleAreaMouseWithin), typeof(bool), typeof(CustomizedWindow),
                new PropertyMetadata(
                    false,
                    CustomizedWindow.IsWindowTitleAreaMouseWithinPropertyChanged
                )
            );
        public static readonly DependencyProperty IsWindowTitleAreaMouseWithinProperty =
            CustomizedWindow.IsWindowTitleAreaMouseWithinPropertyKey.DependencyProperty;

        public bool IsWindowTitleAreaMouseWithin
        {
            get => (bool)this.GetValue(CustomizedWindow.IsWindowTitleAreaMouseWithinProperty);
        }
        
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

        #region WindowResizeBorderThickness
        public static readonly DependencyProperty WindowResizeBorderThicknessProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowResizeBorderThickness), typeof(Thickness), typeof(CustomizedWindow), new PropertyMetadata(new Thickness(0.0)));

        public Thickness WindowResizeBorderThickness
        {
            get => (Thickness)this.GetValue(CustomizedWindow.WindowResizeBorderThicknessProperty);
            set => this.SetValue(CustomizedWindow.WindowResizeBorderThicknessProperty, value);
        }
        #endregion

        #region WindowNorthResizeArea
        public static readonly DependencyProperty WindowNorthResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowNorthResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowNorthResizeArea
        {
            get => (Geometry)this.GetValue(WindowNorthResizeAreaProperty);
            set => this.SetValue(WindowNorthResizeAreaProperty, value);
        }
        #endregion

        #region WindowSouthResizeArea
        public static readonly DependencyProperty WindowSouthResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowSouthResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowSouthResizeArea
        {
            get => (Geometry)this.GetValue(WindowSouthResizeAreaProperty);
            set => this.SetValue(WindowSouthResizeAreaProperty, value);
        }
        #endregion

        #region WindowWestResizeArea
        public static readonly DependencyProperty WindowWestResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowWestResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowWestResizeArea
        {
            get => (Geometry)this.GetValue(WindowWestResizeAreaProperty);
            set => this.SetValue(WindowWestResizeAreaProperty, value);
        }
        #endregion

        #region WindowEastResizeArea
        public static readonly DependencyProperty WindowEastResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowEastResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowEastResizeArea
        {
            get => (Geometry)this.GetValue(WindowEastResizeAreaProperty);
            set => this.SetValue(WindowEastResizeAreaProperty, value);
        }
        #endregion

        #region WindowNorthWestResizeArea
        public static readonly DependencyProperty WindowNorthWestResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowNorthWestResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowNorthWestResizeArea
        {
            get => (Geometry)this.GetValue(WindowNorthWestResizeAreaProperty);
            set => this.SetValue(WindowNorthWestResizeAreaProperty, value);
        }
        #endregion

        #region WindowNorthEastResizeArea
        public static readonly DependencyProperty WindowNorthEastResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowNorthEastResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowNorthEastResizeArea
        {
            get => (Geometry)this.GetValue(WindowNorthEastResizeAreaProperty);
            set => this.SetValue(WindowNorthEastResizeAreaProperty, value);
        }
        #endregion

        #region WindowSouthEastResizeArea
        public static readonly DependencyProperty WindowSouthEastResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowSouthEastResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowSouthEastResizeArea
        {
            get => (Geometry)this.GetValue(WindowSouthEastResizeAreaProperty);
            set => this.SetValue(WindowSouthEastResizeAreaProperty, value);
        }
        #endregion

        #region WindowSouthWestResizeArea
        public static readonly DependencyProperty WindowSouthWestResizeAreaProperty =
            DependencyProperty.Register(nameof(CustomizedWindow.WindowSouthWestResizeArea), typeof(Geometry), typeof(CustomizedWindow), new PropertyMetadata(null));

        public Geometry WindowSouthWestResizeArea
        {
            get => (Geometry)this.GetValue(WindowSouthWestResizeAreaProperty);
            set => this.SetValue(WindowSouthWestResizeAreaProperty, value);
        }
        #endregion

        #endregion

        #region Events

        #region WindowTitleAreaMouseDoubleClick
        public static readonly RoutedEvent WindowTitleAreaMouseDoubleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseDoubleClick), MouseDoubleClickEvent.RoutingStrategy, MouseDoubleClickEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseButtonEventHandler WindowTitleAreaMouseDoubleClick
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseDoubleClickEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseDoubleClickEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseDown
        public static readonly RoutedEvent WindowTitleAreaMouseDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseDown), MouseDownEvent.RoutingStrategy, MouseDownEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseButtonEventHandler WindowTitleAreaMouseDown
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseDownEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseUp
        public static readonly RoutedEvent WindowTitleAreaMouseUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseUp), MouseUpEvent.RoutingStrategy, MouseUpEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseButtonEventHandler WindowTitleAreaMouseUp
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseUpEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseLeftButtonDown
        public static readonly RoutedEvent WindowTitleAreaMouseLeftButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseLeftButtonDown), MouseLeftButtonDownEvent.RoutingStrategy, MouseLeftButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseButtonEventHandler WindowTitleAreaMouseLeftButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseLeftButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseLeftButtonDownEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseLeftButtonUp
        public static readonly RoutedEvent WindowTitleAreaMouseLeftButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseLeftButtonUp), MouseLeftButtonUpEvent.RoutingStrategy, MouseLeftButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseButtonEventHandler WindowTitleAreaMouseLeftButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseLeftButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseLeftButtonUpEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseRightButtonDown
        public static readonly RoutedEvent WindowTitleAreaMouseRightButtonDownEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseRightButtonDown), MouseRightButtonDownEvent.RoutingStrategy, MouseRightButtonDownEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseButtonEventHandler WindowTitleAreaMouseRightButtonDown
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseRightButtonDownEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseRightButtonDownEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseRightButtonUp
        public static readonly RoutedEvent WindowTitleAreaMouseRightButtonUpEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseRightButtonUp), MouseRightButtonUpEvent.RoutingStrategy, MouseRightButtonUpEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseButtonEventHandler WindowTitleAreaMouseRightButtonUp
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseRightButtonUpEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseRightButtonUpEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseEnter
        public static readonly RoutedEvent WindowTitleAreaMouseEnterEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseEnter), MouseEnterEvent.RoutingStrategy, MouseEnterEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseEventHandler WindowTitleAreaMouseEnter
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseEnterEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseEnterEvent, value);
        }
        #endregion
        
        #region WindowTitleAreaMouseLeave
        public static readonly RoutedEvent WindowTitleAreaMouseLeaveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseLeave), MouseLeaveEvent.RoutingStrategy, MouseLeaveEvent.HandlerType, typeof(CustomizedWindow));
        
        public event MouseEventHandler WindowTitleAreaMouseLeave
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseLeaveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseLeaveEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseMove
        public static readonly RoutedEvent WindowTitleAreaMouseMoveEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseMove), MouseMoveEvent.RoutingStrategy, MouseMoveEvent.HandlerType, typeof(CustomizedWindow));
        
        public event MouseEventHandler WindowTitleAreaMouseMove
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseMoveEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseMoveEvent, value);
        }
        #endregion

        #region WindowTitleAreaMouseWheel
        public static readonly RoutedEvent WindowTitleAreaMouseWheelEvent =
            EventManager.RegisterRoutedEvent(nameof(CustomizedWindow.WindowTitleAreaMouseWheel), MouseWheelEvent.RoutingStrategy, MouseWheelEvent.HandlerType, typeof(CustomizedWindow));

        public event MouseWheelEventHandler WindowTitleAreaMouseWheel
        {
            add => this.AddHandler(CustomizedWindow.WindowTitleAreaMouseWheelEvent, value);
            remove => this.RemoveHandler(CustomizedWindow.WindowTitleAreaMouseWheelEvent, value);
        }
        #endregion

        #endregion

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

            this.WindowTitleAreaMouseMove += this.CustomizedWindow_WindowTitleAreaMouseMove;
            this.WindowTitleAreaMouseLeftButtonDown += this.CustomizedWindow_WindowTitleAreaMouseLeftButtonDown;
        }

        #region RedirectingEventHandlers
        private void CustomizedWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseDoubleClickEvent
                    }
                );
        }

        private void CustomizedWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseDownEvent
                    }
                );
        }

        private void CustomizedWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseUpEvent
                    }
                );
        }

        private void CustomizedWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseLeftButtonDownEvent
                    }
                );
        }

        private void CustomizedWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseLeftButtonUpEvent
                    }
                );
        }

        private void CustomizedWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseRightButtonDownEvent
                    }
                );
        }

        private void CustomizedWindow_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseRightButtonUpEvent
                    }
                );
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

            this.RefreshCursor(mousePosition);
        }

        private void CustomizedWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (this.WindowTitleAreaContains(e.GetPosition(this)))
                this.RaiseEvent(
                    new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                    {
                        RoutedEvent = CustomizedWindow.WindowTitleAreaMouseWheelEvent
                    }
                );
        }
        #endregion

        protected internal virtual bool WindowTitleAreaContains(Point mousePosition)
        {
            if (this.WindowTiTleAreaSpecificParts?.Count != 0)
                // 若 WindowTiTleAreaSpecificParts 不为 null 且不为空集合。
            {
                Point defaultPoint = new Point(0, 0);
                foreach (var uielement in this.WindowTiTleAreaSpecificParts)
                {
                    if (uielement.IsMouseOver)
                        return true;
                }
            }
            else
            {
                if (this.WindowTitleArea?.FillContains(mousePosition) == true)
                    return true;
            }

            return false;
        }

        protected internal virtual bool WindowResizeAreaContains(Point mousePosition, out WindowResizeDirection direction)
        {
            if (this.WindowNorthResizeArea?.FillContains(mousePosition) == true)
            {
                direction = WindowResizeDirection.North;
                return true;
            }
            else if (this.WindowSouthResizeArea?.FillContains(mousePosition) == true)
            {
                direction = WindowResizeDirection.South;
                return true;
            }
            else if (this.WindowWestResizeArea?.FillContains(mousePosition) == true)
            {
                direction = WindowResizeDirection.West;
                return true;
            }
            else if (this.WindowEastResizeArea?.FillContains(mousePosition) == true)
            {
                direction = WindowResizeDirection.East;
                return true;
            }
            else if (this.WindowNorthWestResizeArea?.FillContains(mousePosition) == true)
            {
                direction = WindowResizeDirection.NorthWest;
                return true;
            }
            else if (this.WindowNorthEastResizeArea?.FillContains(mousePosition) == true)
            {
                direction = WindowResizeDirection.NorthEast;
                return true;
            }
            else if (this.WindowSouthEastResizeArea?.FillContains(mousePosition) == true)
            {
                direction = WindowResizeDirection.SouthEast;
                return true;
            }
            else if (this.WindowSouthWestResizeArea?.FillContains(mousePosition) == true)
            {
                direction = WindowResizeDirection.SouthWest;
                return true;
            }

            Thickness resizeBorderThickness = this.WindowResizeBorderThickness;
            if (resizeBorderThickness.Top != 0 &&
                new Rect(
                    new Point(resizeBorderThickness.Left, 0),
                    new Point(this.ActualWidth - resizeBorderThickness.Right, resizeBorderThickness.Top)
                ).Contains(mousePosition)
            )
            {
                direction = WindowResizeDirection.North;
                return true;
            }
            else if (resizeBorderThickness.Bottom != 0 &&
                new Rect(
                    new Point(resizeBorderThickness.Left, this.ActualHeight - resizeBorderThickness.Bottom),
                    new Point(this.ActualWidth - resizeBorderThickness.Right, this.ActualWidth)
                ).Contains(mousePosition)
            )
            {
                direction = WindowResizeDirection.South;
                return true;
            }
            else if (resizeBorderThickness.Left != 0 &&
                new Rect(
                    new Point(0, resizeBorderThickness.Top),
                    new Size(resizeBorderThickness.Left, this.ActualHeight - resizeBorderThickness.Bottom)
                ).Contains(mousePosition)
            )
            {
                direction = WindowResizeDirection.West;
                return true;
            }
            else if (resizeBorderThickness.Right != 0 &&
                new Rect(
                    new Point(this.ActualWidth - resizeBorderThickness.Right, resizeBorderThickness.Top),
                    new Point(this.ActualWidth, this.ActualHeight - resizeBorderThickness.Bottom)
                ).Contains(mousePosition)
            )
            {
                direction = WindowResizeDirection.East;
                return true;
            }
            else if (
                (resizeBorderThickness.Top != 0 && resizeBorderThickness.Left != 0) &&
                new Rect(
                    new Point(0, 0),
                    new Point(resizeBorderThickness.Left, resizeBorderThickness.Top)
                ).Contains(mousePosition)
            )
            {
                direction = WindowResizeDirection.NorthWest;
                return true;
            }
            else if (
                (resizeBorderThickness.Top != 0 && resizeBorderThickness.Right != 0) &&
                new Rect(
                    new Point(this.ActualWidth, 0),
                    new Point(this.ActualWidth - resizeBorderThickness.Right, resizeBorderThickness.Top)
                ).Contains(mousePosition)
            )
            {
                direction = WindowResizeDirection.NorthEast;
                return true;
            }
            else if (
                (resizeBorderThickness.Bottom != 0 && resizeBorderThickness.Right != 0) &&
                new Rect(
                    new Point(this.ActualWidth, this.ActualHeight),
                    new Point(this.ActualWidth - resizeBorderThickness.Right, this.ActualHeight - resizeBorderThickness.Bottom)
                ).Contains(mousePosition)
            )
            {
                direction = WindowResizeDirection.SouthEast;
                return true;
            }
            else if (
                (resizeBorderThickness.Bottom != 0 && resizeBorderThickness.Left != 0) &&
                new Rect(
                    new Point(0, this.ActualHeight),
                    new Point(resizeBorderThickness.Left, this.ActualHeight - resizeBorderThickness.Bottom)
                ).Contains(mousePosition)
            )
            {
                direction = WindowResizeDirection.SouthWest;
                return true;
            }

            direction = default(WindowResizeDirection);
            return false;
        }

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

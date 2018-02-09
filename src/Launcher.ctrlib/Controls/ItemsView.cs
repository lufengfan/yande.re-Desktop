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
    public class ItemsView : ItemsControl
    {

        #region ItemsPanel Templates
        #region GridItemsPanel
        /// <summary>
        /// 标识 <see cref="GridItemsPanel"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty GridItemsPanelProperty =
            DependencyProperty.Register(nameof(ItemsView.GridItemsPanel), typeof(ItemsPanelTemplate), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.Grid"/> 时的 <see cref="ItemsControl.ItemsPanel"/> 。
        /// </summary>
        public ItemsPanelTemplate GridItemsPanel
        {
            get => (ItemsPanelTemplate)this.GetValue(ItemsView.GridItemsPanelProperty);
            set => this.SetValue(ItemsView.GridItemsPanelProperty, value);
        }
        #endregion

        #region HorizontalWrapItemsPanel
        /// <summary>
        /// 标识 <see cref="HorizontalWrapItemsPanel"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty HorizontalWrapItemsPanelProperty =
            DependencyProperty.Register(nameof(ItemsView.HorizontalWrapItemsPanel), typeof(ItemsPanelTemplate), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.HorizontalWrap"/> 时的 <see cref="ItemsControl.ItemsPanel"/> 。
        /// </summary>
        public ItemsPanelTemplate HorizontalWrapItemsPanel
        {
            get => (ItemsPanelTemplate)this.GetValue(ItemsView.HorizontalWrapItemsPanelProperty);
            set => this.SetValue(ItemsView.HorizontalWrapItemsPanelProperty, value);
        }
        #endregion

        #region VerticalHangItemsPanel
        /// <summary>
        /// 标识 <see cref="VerticalHangItemsPanel"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty VerticalHangItemsPanelProperty =
            DependencyProperty.Register(nameof(ItemsView.VerticalHangItemsPanel), typeof(ItemsPanelTemplate), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.VerticalHang"/> 时的 <see cref="ItemsControl.ItemsPanel"/> 。
        /// </summary>
        public ItemsPanelTemplate VerticalHangItemsPanel
        {
            get => (ItemsPanelTemplate)this.GetValue(ItemsView.VerticalHangItemsPanelProperty);
            set => this.SetValue(ItemsView.VerticalHangItemsPanelProperty, value);
        }
        #endregion
        #endregion

        #region ItemStringFormat Templates
        #region GridItemStringFormat
        /// <summary>
        /// 标识 <see cref="GridItemStringFormat"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty GridItemStringFormatProperty =
            DependencyProperty.Register(nameof(ItemsView.GridItemStringFormat), typeof(string), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.Grid"/> 时的 <see cref="ItemsControl.ItemStringFormat"/> 。
        /// </summary>
        public string GridItemStringFormat
        {
            get => (string)this.GetValue(ItemsView.GridItemStringFormatProperty);
            set => this.SetValue(ItemsView.GridItemStringFormatProperty, value);
        }
        #endregion

        #region HorizontalWrapItemStringFormat
        /// <summary>
        /// 标识 <see cref="HorizontalWrapItemStringFormat"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty HorizontalWrapItemStringFormatProperty =
            DependencyProperty.Register(nameof(ItemsView.HorizontalWrapItemStringFormat), typeof(string), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.HorizontalWrap"/> 时的 <see cref="ItemsControl.ItemStringFormat"/> 。
        /// </summary>
        public string HorizontalWrapItemStringFormat
        {
            get => (string)this.GetValue(ItemsView.HorizontalWrapItemStringFormatProperty);
            set => this.SetValue(ItemsView.HorizontalWrapItemStringFormatProperty, value);
        }
        #endregion

        #region VerticalHangItemStringFormat
        /// <summary>
        /// 标识 <see cref="VerticalHangItemStringFormat"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty VerticalHangItemStringFormatProperty =
            DependencyProperty.Register(nameof(ItemsView.VerticalHangItemStringFormat), typeof(string), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.VerticalHang"/> 时的 <see cref="ItemsControl.ItemStringFormat"/> 。
        /// </summary>
        public string VerticalHangItemStringFormat
        {
            get => (string)this.GetValue(ItemsView.VerticalHangItemStringFormatProperty);
            set => this.SetValue(ItemsView.VerticalHangItemStringFormatProperty, value);
        }
        #endregion
        #endregion

        #region ItemTemplate Templates
        #region GridItemTemplate
        /// <summary>
        /// 标识 <see cref="GridItemTemplate"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty GridItemTemplateProperty =
            DependencyProperty.Register(nameof(ItemsView.GridItemTemplate), typeof(DataTemplate), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.Grid"/> 时的 <see cref="ItemsControl.ItemTemplate"/> 。
        /// </summary>
        public DataTemplate GridItemTemplate
        {
            get => (DataTemplate)this.GetValue(ItemsView.GridItemTemplateProperty);
            set => this.SetValue(ItemsView.GridItemTemplateProperty, value);
        }
        #endregion

        #region HorizontalWrapItemTemplate
        /// <summary>
        /// 标识 <see cref="HorizontalWrapItemTemplate"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty HorizontalWrapItemTemplateProperty =
            DependencyProperty.Register(nameof(ItemsView.HorizontalWrapItemTemplate), typeof(DataTemplate), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.HorizontalWrap"/> 时的 <see cref="ItemsControl.ItemTemplate"/> 。
        /// </summary>
        public DataTemplate HorizontalWrapItemTemplate
        {
            get => (DataTemplate)this.GetValue(ItemsView.HorizontalWrapItemTemplateProperty);
            set => this.SetValue(ItemsView.HorizontalWrapItemTemplateProperty, value);
        }
        #endregion

        #region VerticalHangItemTemplate
        /// <summary>
        /// 标识 <see cref="VerticalHangItemTemplate"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty VerticalHangItemTemplateProperty =
            DependencyProperty.Register(nameof(ItemsView.VerticalHangItemTemplate), typeof(DataTemplate), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.VerticalHang"/> 时的 <see cref="ItemsControl.ItemTemplate"/> 。
        /// </summary>
        public DataTemplate VerticalHangItemTemplate
        {
            get => (DataTemplate)this.GetValue(ItemsView.VerticalHangItemTemplateProperty);
            set => this.SetValue(ItemsView.VerticalHangItemTemplateProperty, value);
        }
        #endregion
        #endregion

        #region ItemTemplateSelector Templates
        #region GridItemTemplateSelector
        /// <summary>
        /// 标识 <see cref="GridItemTemplateSelector"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty GridItemTemplateSelectorProperty =
            DependencyProperty.Register(nameof(ItemsView.GridItemTemplateSelector), typeof(DataTemplateSelector), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.Grid"/> 时的 <see cref="ItemsControl.ItemTemplateSelector"/> 。
        /// </summary>
        public DataTemplateSelector GridItemTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(ItemsView.GridItemTemplateSelectorProperty);
            set => this.SetValue(ItemsView.GridItemTemplateSelectorProperty, value);
        }
        #endregion

        #region HorizontalWrapItemTemplateSelector
        /// <summary>
        /// 标识 <see cref="HorizontalWrapItemTemplateSelector"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty HorizontalWrapItemTemplateSelectorProperty =
            DependencyProperty.Register(nameof(ItemsView.HorizontalWrapItemTemplateSelector), typeof(DataTemplateSelector), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.HorizontalWrap"/> 时的 <see cref="ItemsControl.ItemTemplateSelector"/> 。
        /// </summary>
        public DataTemplateSelector HorizontalWrapItemTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(ItemsView.HorizontalWrapItemTemplateSelectorProperty);
            set => this.SetValue(ItemsView.HorizontalWrapItemTemplateSelectorProperty, value);
        }
        #endregion

        #region VerticalHangItemTemplateSelector
        /// <summary>
        /// 标识 <see cref="VerticalHangItemTemplateSelector"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty VerticalHangItemTemplateSelectorProperty =
            DependencyProperty.Register(nameof(ItemsView.VerticalHangItemTemplateSelector), typeof(DataTemplateSelector), typeof(ItemsView), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置当 <see cref="ViewType"/> 为 <see cref="ItemsViewType.VerticalHang"/> 时的 <see cref="ItemsControl.ItemTemplateSelector"/> 。
        /// </summary>
        public DataTemplateSelector VerticalHangItemTemplateSelector
        {
            get => (DataTemplateSelector)this.GetValue(ItemsView.VerticalHangItemTemplateSelectorProperty);
            set => this.SetValue(ItemsView.VerticalHangItemTemplateSelectorProperty, value);
        }
        #endregion
        #endregion

        #region ViewType
        public static readonly DependencyProperty ViewTypeProperty =
            DependencyProperty.Register(
                nameof(ItemsView.ViewType), typeof(ItemsViewType), typeof(ItemsView),
                new PropertyMetadata(ItemsViewType.Grid),
                ItemsView.ViewTypeValidateValue
            );

        public ItemsViewType ViewType
        {
            get => (ItemsViewType)this.GetValue(ItemsView.ViewTypeProperty);
            set => this.SetValue(ItemsView.ViewTypeProperty, value);
        }

        private static bool ViewTypeValidateValue(object value) =>
            value is ItemsViewType viewType && Enum.IsDefined(typeof(ItemsViewType), viewType);
        #endregion

        static ItemsView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemsView), new FrameworkPropertyMetadata(typeof(ItemsView)));
        }
    }
}

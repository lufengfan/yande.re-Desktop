using Launcher.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Launcher.Controls
{
    public class CustomizedGrid : Grid
    {

        #region Row Properties
        #region RowCount
        /// <summary>
        /// 标识 <see cref="RowCount"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty RowCountProperty =
            DependencyProperty.Register(
                nameof(CustomizedGrid.RowCount), typeof(int), typeof(CustomizedGrid),
                new PropertyMetadata(
                    0,
                    CustomizedGrid.RowCountPropertyChanged
                ),
                CustomizedGrid.RowCountValidateValue
            );

        /// <summary>
        /// 获取或设置 <see cref="Grid.RowDefinitions"/> 的 <see cref="RowDefinition"/> 数目。
        /// </summary>
        public int RowCount
        {
            get => (int)this.GetValue(CustomizedGrid.RowCountProperty);
            set => this.SetValue(CustomizedGrid.RowCountProperty, value);
        }

        private static void RowCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedGrid grid = (CustomizedGrid)d;
            int count = (int)e.NewValue;

            grid.UpdateRowDefinitions(count, grid.RowDefinitionSelector);
        }

        private static bool RowCountValidateValue(object value) => value is int count && count >= 0;
        #endregion

        #region RowDefinitionSelector
        /// <summary>
        /// 标识 <see cref="RowDefinitionSelector"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty RowDefinitionSelectorProperty =
            DependencyProperty.Register(
                nameof(CustomizedGrid.RowDefinitionSelector), typeof(RowDefinitionSelector), typeof(CustomizedGrid),
                new PropertyMetadata(
                    new RowDefinitionSelector(),
                    CustomizedGrid.RowDefinitionSelectorPropertyChanged
                ),
                CustomizedGrid.RowDefinitionSelectorValidateValue
            );

        /// <summary>
        /// 获取或设置 <see cref="RowDefinition"/> 选择逻辑。
        /// </summary>
        public RowDefinitionSelector RowDefinitionSelector
        {
            get => (RowDefinitionSelector)this.GetValue(CustomizedGrid.RowDefinitionSelectorProperty);
            set => this.SetValue(CustomizedGrid.RowDefinitionSelectorProperty, value);
        }

        private static void RowDefinitionSelectorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedGrid grid = (CustomizedGrid)d;
            RowDefinitionSelector selector = (RowDefinitionSelector)e.NewValue;
            
            grid.UpdateRowDefinitions(grid.RowCount, selector);
        }

        private static bool RowDefinitionSelectorValidateValue(object value) => (value as RowDefinitionSelector) != null;
        #endregion

        /// <summary>
        /// 使用指定的行数和 <see cref="Controls.RowDefinitionSelector"/> 更新 <see cref="Grid.RowDefinitions"/> 。
        /// </summary>
        /// <param name="rowCount">要设置的 <see cref="RowDefinition"/> 的数量。</param>
        /// <param name="selector">按指定逻辑选择 <see cref="RowDefinition"/> 实例。</param>
        protected virtual void UpdateRowDefinitions(int rowCount, RowDefinitionSelector selector)
        {
            this.RowDefinitions.Clear();

            for (int i = 0; i < rowCount; i++)
                this.RowDefinitions.Add(selector.Select(i, rowCount));
        }
        #endregion

        #region Column Properties
        #region ColumnCount
        /// <summary>
        /// 标识 <see cref="ColumnCount"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.Register(
                nameof(CustomizedGrid.ColumnCount), typeof(int), typeof(CustomizedGrid),
                new PropertyMetadata(
                    0,
                    CustomizedGrid.ColumnCountPropertyChanged
                ),
                CustomizedGrid.ColumnCountValidateValue
            );

        /// <summary>
        /// 获取或设置 <see cref="Grid.ColumnDefinitions"/> 的 <see cref="ColumnDefinition"/> 数目。
        /// </summary>
        public int ColumnCount
        {
            get => (int)this.GetValue(CustomizedGrid.ColumnCountProperty);
            set => this.SetValue(CustomizedGrid.ColumnCountProperty, value);
        }

        private static void ColumnCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedGrid grid = (CustomizedGrid)d;
            int count = (int)e.NewValue;

            grid.UpdateColumnDefinitions(count, grid.ColumnDefinitionSelector);
        }

        private static bool ColumnCountValidateValue(object value) => value is int count && count >= 0;
        #endregion

        #region ColumnDefinitionSelector
        /// <summary>
        /// 标识 <see cref="ColumnDefinitionSelector"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ColumnDefinitionSelectorProperty =
            DependencyProperty.Register(
                nameof(CustomizedGrid.ColumnDefinitionSelector), typeof(ColumnDefinitionSelector), typeof(CustomizedGrid),
                new PropertyMetadata(
                    new ColumnDefinitionSelector(),
                    CustomizedGrid.ColumnDefinitionSelectorPropertyChanged
                ),
                CustomizedGrid.ColumnDefinitionSelectorValidateValue
            );

        /// <summary>
        /// 获取或设置 <see cref="ColumnDefinition"/> 选择逻辑。
        /// </summary>
        public ColumnDefinitionSelector ColumnDefinitionSelector
        {
            get => (ColumnDefinitionSelector)this.GetValue(CustomizedGrid.ColumnDefinitionSelectorProperty);
            set => this.SetValue(CustomizedGrid.ColumnDefinitionSelectorProperty, value);
        }

        private static void ColumnDefinitionSelectorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomizedGrid grid = (CustomizedGrid)d;
            ColumnDefinitionSelector selector = (ColumnDefinitionSelector)e.NewValue;

            grid.UpdateColumnDefinitions(grid.ColumnCount, selector);
        }

        private static bool ColumnDefinitionSelectorValidateValue(object value) => (value as ColumnDefinitionSelector) != null;
        #endregion

        /// <summary>
        /// 使用指定的行数和 <see cref="Controls.ColumnDefinitionSelector"/> 更新 <see cref="Grid.ColumnDefinitions"/> 。
        /// </summary>
        /// <param name="columnCount">要设置的 <see cref="ColumnDefinition"/> 的数量。</param>
        /// <param name="selector">按指定逻辑选择 <see cref="ColumnDefinition"/> 实例。</param>
        protected virtual void UpdateColumnDefinitions(int columnCount, ColumnDefinitionSelector selector)
        {
            this.ColumnDefinitions.Clear();

            for (int i = 0; i < columnCount; i++)
                this.ColumnDefinitions.Add(selector.Select(i, columnCount));
        }
        #endregion

    }

    /// <summary>
    /// <see cref="RowDefinition"/> 选择逻辑。
    /// </summary>
    [ContentProperty(nameof(RowDefinitionSelector.PrimitiveValue))]
    public class RowDefinitionSelector : ISelector<int, RowDefinition>
    {
        public RowDefinition PrimitiveValue { get; set; } = new RowDefinition();

        public virtual RowDefinition Select(int source, params object[] args)
        {
            if (this.PrimitiveValue == null)
                return new RowDefinition();
            else
                return new RowDefinition()
                {
                    Height = this.PrimitiveValue.Height,
                    MinHeight = this.PrimitiveValue.MinHeight,
                    MaxHeight = this.PrimitiveValue.MaxHeight
                };
        }
    }

    /// <summary>
    /// <see cref="ColumnDefinition"/> 选择逻辑。
    /// </summary>
    [ContentProperty(nameof(ColumnDefinitionSelector.PrimitiveValue))]
    public class ColumnDefinitionSelector : ISelector<int, ColumnDefinition>
    {
        public ColumnDefinition PrimitiveValue { get; set; } = new ColumnDefinition();

        public virtual ColumnDefinition Select(int source, params object[] args)
        {
            if (this.PrimitiveValue == null)
                return new ColumnDefinition();
            else
                return new ColumnDefinition()
                {
                    Width = this.PrimitiveValue.Width,
                    MinWidth = this.PrimitiveValue.MinWidth,
                    MaxWidth = this.PrimitiveValue.MaxWidth
                };
        }
    }
}

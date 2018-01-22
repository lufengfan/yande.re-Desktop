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
    /// <summary>
    /// 圆角边界面板。
    /// </summary>
    public class FilletPanel : ContentControl
    {

        #region CornerRadius
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(FilletPanel.CornerRadius), typeof(CornerRadius), typeof(FilletPanel), new PropertyMetadata(new CornerRadius(5.0)));
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)this.GetValue(FilletPanel.CornerRadiusProperty);
            set => this.SetValue(FilletPanel.CornerRadiusProperty, value);
        }
        #endregion
        
        static FilletPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilletPanel), new FrameworkPropertyMetadata(typeof(FilletPanel)));
        }
    }
}

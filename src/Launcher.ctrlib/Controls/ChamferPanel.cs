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
    /// 倒角边界面板。
    /// </summary>
    public class ChamferPanel : ContentControl
    {

        #region CornerSize
        public static readonly DependencyProperty CornerSizeProperty =
            DependencyProperty.Register(nameof(ChamferPanel.CornerSize), typeof(CornerSize), typeof(ChamferPanel), new PropertyMetadata(new CornerSize(new Size(5.0, 5.0))));
        public CornerSize CornerSize
        {
            get => (CornerSize)this.GetValue(ChamferPanel.CornerSizeProperty);
            set => this.SetValue(ChamferPanel.CornerSizeProperty, value);
        }
        #endregion

        static ChamferPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChamferPanel), new FrameworkPropertyMetadata(typeof(ChamferPanel)));
        }
    }
}

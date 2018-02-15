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
    public class SideBar : ContentControl
    {

        #region TipDock
        public static readonly DependencyProperty TipDockProperty =
            DependencyProperty.Register(
                nameof(SideBar.TipDock), typeof(Dock), typeof(SideBar),
                new FrameworkPropertyMetadata(Dock.Left)
            );

        public Dock TipDock
        {
            get { return (Dock)GetValue(TipDockProperty); }
            set { SetValue(TipDockProperty, value); }
        }
        #endregion

        #region Tip
        public static readonly DependencyProperty TipProperty =
            DependencyProperty.Register(nameof(SideBar.Tip), typeof(object), typeof(SideBar), new PropertyMetadata(null));

        public object Tip
        {
            get { return (object)GetValue(TipProperty); }
            set { SetValue(TipProperty, value); }
        }
        #endregion

        static SideBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SideBar), new FrameworkPropertyMetadata(typeof(SideBar)));
        }
    }
}

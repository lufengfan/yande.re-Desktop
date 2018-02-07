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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher.Controls
{
    public class DropShadowWindow : CustomizedWindow
    {

        #region BlurRadius
        public static readonly DependencyProperty BlurRadiusProperty =
            DropShadowEffect.BlurRadiusProperty.AddOwner(typeof(DropShadowWindow));

        public double BlurRadius
        {
            get => (double)this.GetValue(DropShadowWindow.BlurRadiusProperty);
            set => this.SetValue(DropShadowWindow.BlurRadiusProperty, value);
        }
        #endregion

        #region DropShadowColor
        public static readonly DependencyProperty DropShadowColorProperty =
            DependencyProperty.Register(nameof(DropShadowWindow.DropShadowColor), typeof(Color), typeof(DropShadowWindow), new PropertyMetadata(Colors.Transparent));

        public Color DropShadowColor
        {
            get => (Color)this.GetValue(DropShadowWindow.DropShadowColorProperty);
            set => this.SetValue(DropShadowWindow.DropShadowColorProperty, value);
        }
        #endregion


        static DropShadowWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DropShadowWindow), new FrameworkPropertyMetadata(typeof(DropShadowWindow)));
        }



        public DropShadowWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            
        }
    }
}

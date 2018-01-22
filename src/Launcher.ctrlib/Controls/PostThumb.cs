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
    public class PostThumb : Control
    {

        #region CornerRadius
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(PostThumb.CornerRadius), typeof(CornerRadius), typeof(PostThumb), new PropertyMetadata(new CornerRadius(5.0)));
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)this.GetValue(PostThumb.CornerRadiusProperty);
            set => this.SetValue(PostThumb.CornerRadiusProperty, value);
        }
        #endregion

        #region ImageSource
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(nameof(PostThumb.ImageSource), typeof(ImageSource), typeof(PostThumb), new PropertyMetadata(null));
        public ImageSource ImageSource
        {
            get => (ImageSource)this.GetValue(PostThumb.ImageSourceProperty);
            set => this.SetValue(PostThumb.ImageSourceProperty, value);
        }
        #endregion

        static PostThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PostThumb), new FrameworkPropertyMetadata(typeof(PostThumb)));
        }
    }
}

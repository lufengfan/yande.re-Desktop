using Launcher.Controls;
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
using Yandere;
using Yandere.Data;

namespace Launcher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleRect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void wp_Loaded(object sender, RoutedEventArgs e)
        {
            PostSearchProcess process = new PostSearchProcess();
            var posts = process.Search();
            int i = 0;
            foreach (Lazy<YanderePostPreview> post in posts)
            {
                async void addPostThumb(Lazy<YanderePostPreview> _post)
                {
                    PostThumb thumb = new PostThumb()
                    {
                        Style = (Style)this.wp.Resources["VerticalOrientedPostThumbStyle"]
                    };
                    this.wp.Children.Add(thumb);

                    Uri previewImageUri = await Task.Run(() => _post.Value.PreviewImageUri);
                    thumb.ImageSource = new BitmapImage(previewImageUri);
                }
                this.Dispatcher.BeginInvoke(new Action<Lazy<YanderePostPreview>>(addPostThumb), post);
                i++;
                if (i == 15) break;
            }
        }
    }
}

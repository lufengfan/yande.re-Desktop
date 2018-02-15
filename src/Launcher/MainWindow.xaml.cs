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
    public partial class MainWindow : DropShadowWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            FullScreenManager.RepairWpfWindowFullScreenBehavior(this);
        }

        private void TitleRect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PostSearchProcess process = new Yandere.Json.JsonPostSearchProcess();
            var searchResult = process.Search();

            this.NavigationFrame.Navigate(new Uri("/Pages/PostSearchResultPage.xaml", UriKind.Relative), searchResult);
#if false
            this.PostThumbView.DataContext = searchResult;
            new System.Threading.Thread(() =>
            {
                searchResult.Load(
                    count: 30,
                    dispatcher: this.Dispatcher
                ); // 加载 30 个。
            })
            { IsBackground = true }
                .Start();
            /*
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
                if (i == 5) break;
            }
            */
#endif
        }

        private void MinimizeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Minimized && this.ResizeMode != ResizeMode.NoResize)
                e.CanExecute = true;
        }

        private void MinimizeCommand_Executed(object sender, ExecutedRoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void MaximizeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized && (this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip))
                e.CanExecute = true;
        }

        private void MaximizeCommand_Executed(object sender, ExecutedRoutedEventArgs e) => this.WindowState = WindowState.Maximized;

        private void NormalCommand_Executed(object sender, ExecutedRoutedEventArgs e) => this.WindowState = WindowState.Normal;

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e) => this.Close();

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            return;
            if (this.sA == null || this.sR == null || this.sG == null || this.sB == null) return;

            Color color = Color.FromArgb((byte)this.sA.Value, (byte)this.sR.Value, (byte)this.sG.Value, (byte)this.sB.Value);
            Application.Current.Resources[LauncherTheme.DropShadowColorKey] = color;
        }

        private void NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.DataContext = e.ExtraData;
            }
        }
    }
}

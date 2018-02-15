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

namespace Launcher.Pages
{
    /// <summary>
    /// PostSearchResultPage.xaml 的交互逻辑
    /// </summary>
    public partial class PostSearchResultPage : Page
    {
        public PostSearchResultPage()
        {
            InitializeComponent();
        }

        private void StatusInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PostSearchResult searchResult = this.PostThumbView.DataContext as PostSearchResult;
            return;
            new System.Threading.Thread(() =>
            {
                if (searchResult.IsSearching) return;
                else if (searchResult.IsAbort || searchResult.IsSearchComplete)
                    searchResult.Update();

                searchResult.Load(
                    count: 30,
                    dispatcher: this.Dispatcher
                ); // 加载 30 个。
            })
            { IsBackground = true }
                .Start();
        }

        private void PostThumbView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is PostSearchResult searchResult)
            {
                return;
                new System.Threading.Thread(() =>
                {
                    searchResult.Load(
                        count: 30,
                        dispatcher: this.Dispatcher
                    ); // 加载 30 个。
                })
                { IsBackground = true }
                .Start();
            }
        }
    }
}

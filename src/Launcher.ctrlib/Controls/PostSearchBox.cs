using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Yandere.Data;

namespace Launcher.Controls
{
    public class PostSearchBox : TextBox
    {
        
        #region YanderePosts
        public static readonly DependencyPropertyKey YandereTagsPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(PostSearchBox.YandereTags), typeof(ObservableCollection<YandereTag>), typeof(PostSearchBox), new PropertyMetadata(null));
        public static readonly DependencyProperty YandereTagsProperty = PostSearchBox.YandereTagsPropertyKey.DependencyProperty;

        public ObservableCollection<YandereTag> YandereTags
        {
            get => (ObservableCollection<YandereTag>)this.GetValue(YandereTagsProperty);
            protected set => this.SetValue(YandereTagsPropertyKey, value);
        }
        #endregion

        static PostSearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PostSearchBox), new FrameworkPropertyMetadata(typeof(PostSearchBox)));
            PropertyMetadata metadata = TextProperty.GetMetadata(typeof(TextBox));
            TextProperty.OverrideMetadata(typeof(PostSearchBox),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                    (PropertyChangedCallback)((d, e) =>
                    {
                        metadata.PropertyChangedCallback?.Invoke(d, e);
                        ((PostSearchBox)d).YandereTags = new ObservableCollection<YandereTag>(YandereTagCollection.Parse((string)e.NewValue));
                    }),
                    metadata.CoerceValueCallback,
                    true,
                    UpdateSourceTrigger.LostFocus
                )
            );
        }
    }
}

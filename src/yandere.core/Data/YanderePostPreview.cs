using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere.ComponentModel;
using Yandere.Data.Html;

namespace Yandere.Data
{
    public class YanderePostPreview : INotifyPropertyChanged
    {
        private uint id;
        public virtual uint ID
        {
            get => this.id;
            protected internal set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.NotifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        private Uri previewImageUri;
        public virtual Uri PreviewImageUri
        {
            get => this.previewImageUri;
            protected internal set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));

                if (this.previewImageUri != value)
                {
                    this.previewImageUri = value;
                    this.NotifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        private Size size;
        public virtual Size Size
        {
            get => this.size;
            protected internal set
            {
                if (this.size != value)
                {
                    this.size = value;
                    this.NotifyPropertyChanged.OnPropertyChanged();
                }
            }
        }
        
        public virtual YandereTagCollection Tags { get; protected internal set; }

        private Lazy<YanderePost> post;
        public virtual Lazy<YanderePost> Post
        {
            get => this.post;
            protected internal set
            {
                value = value?? new Lazy<YanderePost>(() => HtmlYanderePost.GetPost(this.ID));

                if (this.post != value)
                {
                    this.post = value;
                    this.NotifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        public YanderePostPreview(uint id, Uri previewImageUri, Size size, YandereTagCollection tags, Lazy<YanderePost> post = null)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);

            this.ID = id;
            this.PreviewImageUri = previewImageUri ?? throw new ArgumentNullException(nameof(previewImageUri));
            this.Size = size;
            this.Tags = tags ?? throw new ArgumentNullException(nameof(tags));
            this.Post = post ?? new Lazy<YanderePost>(() => HtmlYanderePost.GetPost(id));
        }

        #region INotifyPropertyChanged Members
        private NotifyPropertyChanged notifyPropertyChanged;
        protected virtual NotifyPropertyChanged NotifyPropertyChanged => this.notifyPropertyChanged;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.NotifyPropertyChanged.PropertyChanged += value;
            remove => this.NotifyPropertyChanged.PropertyChanged -= value;
        }
        #endregion
    }
}

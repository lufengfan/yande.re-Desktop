using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere.Collections.ObjectModel;
using Yandere.ComponentModel;
using Yandere.Data;

namespace Yandere
{
    public class PostSearchResult : INotifyPropertyChanged
    {
        private IEnumerable<YanderePostPreview> previews;
        private IEnumerator<YanderePostPreview> enumerator;

        private bool isSearching = false;
        public bool IsSearching
        {
            get => this.isSearching;
            set
            {
                if (this.isSearching != value)
                {
                    this.isSearching = value;
                    this.notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        private ObservableIndexedList<YanderePostPreview> collection = new ObservableIndexedList<YanderePostPreview>();
        public ObservableIndexedList<YanderePostPreview> PostPreviews => this.collection;

        public PostSearchResult(IEnumerable<YanderePostPreview> previews)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);

            this.previews = previews ?? throw new ArgumentNullException(nameof(previews));
            this.Update();
        }

        public void Update()
        {
            this.collection.Clear();
            this.enumerator = this.previews.GetEnumerator();
            this.isSearching = false;
        }

        public void Load(int count = 5)
        {
            bool hasNext = false;
            int i = 0;
            for (; this.enumerator.MoveNext() && i < count; i++)
            {
                hasNext = true;
                this.collection.Add(this.enumerator.Current);
            }

            if (!hasNext)
                this.SearchCompleted?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler SearchCompleted;

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Yandere.Collections.ObjectModel;
using Yandere.ComponentModel;
using Yandere.Data;

namespace Yandere
{
    public class PostSearchResult : INotifyPropertyChanged
    {
        private IEnumerable<YanderePostPreview> previews;
        private IEnumerator<YanderePostPreview> enumerator;
        private int index;

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

        private bool isSearchComplete = false;
        public bool IsSearchComplete
        {
            get => this.isSearchComplete;
            protected set
            {
                if (this.isSearchComplete != value)
                {
                    this.isSearchComplete = value;
                    this.notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        private bool isAbort = false;
        public bool IsAbort
        {
            get => this.isAbort;
            protected set
            {
                if (this.isAbort != value)
                {
                    this.isAbort = value;
                    this.notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        public ObservableIndexedList<YanderePostPreview> PostPreviews { get; } = new ObservableIndexedList<YanderePostPreview>();

        public ObservableCountedList<YandereTag> RelatedTags { get; } = new ObservableCountedList<YandereTag>();
        
        public PostSearchResult(IEnumerable<YanderePostPreview> previews)
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);

            this.previews = previews ?? throw new ArgumentNullException(nameof(previews));
            this.PostPreviews.CollectionChanged += (sender, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                        this.RelatedTags.Clear();
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        if (e.OldItems != null)
                        {
                            foreach (ObservableCollectionItem<YanderePostPreview> item in e.OldItems)
                            {
                                foreach (var tag in item.Value.Tags)
                                {
                                    this.RelatedTags.Remove(tag);
                                }
                            }
                        }

                        if (e.NewItems != null)
                        {
                            foreach (ObservableCollectionItem<YanderePostPreview> item in e.NewItems)
                            {
                                foreach (var tag in item.Value.Tags)
                                {
                                    this.RelatedTags.Add(tag);
                                }
                            }
                        }
                        break;
                }
            };

            this.Update();
        }

        public void Update(Dispatcher dispatcher = null)
        {
            dispatcher?.BeginInvoke((Action)delegate
            {
                this.RelatedTags.Clear();
                this.PostPreviews.Clear();
            });
            this.enumerator = this.previews.GetEnumerator();
            this.index = 0;
            this.isSearching = false;
            this.isSearchComplete = false;
        }

        public void Load(int count = 40, Dispatcher dispatcher = null)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "数目不能小于零。");
            else if (count == 0)
                return;
            else
            {
                this.IsSearching = true;
                bool hasNext = false;
                int i = 0;
                while (i < count)
                {
                    this.IsSearching = true;
                    try
                    {
                        hasNext = this.enumerator.MoveNext();
                    }
                    catch (Exception)
                    {
                        hasNext = false;
                        this.IsAbort = true;
                        this.ErrorRaised?.Invoke(this, EventArgs.Empty);
                        break;
                    }
                    if (!hasNext)
                    {
                        this.IsSearchComplete = true;
                        this.SearchCompleted?.Invoke(this, EventArgs.Empty);
                        break;
                    }
                    
                    dispatcher?.BeginInvoke(
                        (Action<int, YanderePostPreview>)((index, postPreview) =>
                        {
                            this.PostPreviews.Insert(index, postPreview);
                        }),
                        this.index, this.enumerator.Current
                    );

                    i++;
                    this.index++;
                }
                this.IsSearching = false;
            }
        }

        public event EventHandler SearchCompleted;
        public event EventHandler ErrorRaised;

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

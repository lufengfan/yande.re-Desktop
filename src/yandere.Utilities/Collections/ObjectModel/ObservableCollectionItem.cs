using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere.ComponentModel;

namespace Yandere.Collections.ObjectModel
{
    [DebuggerDisplay("[{Index}], {Value}")]
    public class ObservableCollectionItem<T> : INotifyPropertyChanged
    {
        internal object owner;

        private ValueBox<int> indexBox = ValueBox<int>.NonValue;
        public int Index
        {
            get => this.indexBox.HasValue ? this.indexBox.Value : 0;
            internal set
            {
                if (!this.indexBox.HasValue || this.indexBox.Value != value)
                {
                    this.indexBox.Value = value;
                    this.notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        private ValueBox<T> valueBox;
        public T Value
        {
            get => this.valueBox.HasValue ? this.valueBox.Value : default(T);
            set {
                if (!this.valueBox.HasValue || !EqualityComparer<T>.Default.Equals(this.valueBox.Value, value))
                {
                    this.valueBox.Value = value;
                    this.notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        private NotifyPropertyChanged notifyPropertyChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.notifyPropertyChanged.PropertyChanged += value;
            remove => this.notifyPropertyChanged.PropertyChanged -= value;
        }

        public ObservableCollectionItem()
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
            this.valueBox = ValueBox<T>.NonValue;
        }

        public ObservableCollectionItem(T value) : this() => this.valueBox.Value = value;
    }
}

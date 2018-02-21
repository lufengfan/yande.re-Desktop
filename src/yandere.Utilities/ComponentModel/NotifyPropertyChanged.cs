using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.ComponentModel
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        private object sender;
        protected object Sender => this.sender;

        public NotifyPropertyChanged(object sender = null) =>
            this.sender = sender;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) =>
            this.PropertyChanged?.Invoke(this.sender, e);

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this.sender, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnPropertyChangedOverrideSender(object sender, [CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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

        public NotifyPropertyChanged(object sender) =>
            this.sender = sender;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this.sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}

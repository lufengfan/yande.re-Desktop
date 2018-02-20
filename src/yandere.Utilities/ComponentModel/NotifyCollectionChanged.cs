using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.ComponentModel
{
    public class NotifyCollectionChanged : INotifyCollectionChanged
    {
        private object sender;

        public NotifyCollectionChanged(object sender) =>
            this.sender = sender;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.CollectionChanged?.Invoke(this.sender, e);
        }
    }
}

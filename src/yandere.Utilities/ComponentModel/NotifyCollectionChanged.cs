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
        protected object Sender => this.sender;

        public NotifyCollectionChanged(object sender = null) =>
            this.sender = sender;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.CollectionChanged?.Invoke(this.sender, e);
        }

        public virtual void OnCollectionChangedOverrideSender(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.CollectionChanged?.Invoke(sender, e);
        }
    }
}

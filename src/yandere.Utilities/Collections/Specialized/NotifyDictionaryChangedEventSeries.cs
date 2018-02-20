using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Collections.Specialized
{
    public delegate void NotifyDictionaryChangedEventHandler<TKey, TValue>(object sender, NotifyDictionaryChangedEventArgs<TKey, TValue> e);

    public class NotifyDictionaryChangedEventArgs<TKey, TValue> : EventArgs
    {
        private NotifyDictionaryChangedAction action;
        private TKey changedKey;
        private TValue oldValue;
        private TValue newValue;

        public NotifyDictionaryChangedAction Action => this.action;
        public TKey ChangedKey => this.changedKey;
        public TValue OldValue => this.oldValue;
        public TValue NewValue => this.newValue;

        public NotifyDictionaryChangedEventArgs(NotifyDictionaryChangedAction action)
        {
            if (action != NotifyDictionaryChangedAction.Reset)
                throw new ArgumentOutOfRangeException(nameof(action), action, $"动作参数应为 {nameof(NotifyDictionaryChangedAction.Reset)} 。");
            this.action = action;
        }

        public NotifyDictionaryChangedEventArgs(NotifyDictionaryChangedAction action, TKey changedKey, TValue changedValue)
        {
            switch (action)
            {
                case NotifyDictionaryChangedAction.Add:
                    this.action = action;
                    this.changedKey = changedKey;
                    this.newValue = changedValue;
                    break;
                case NotifyDictionaryChangedAction.Remove:
                    this.action = action;
                    this.changedKey = changedKey;
                    this.oldValue = changedValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, $"动作参数应为 {nameof(NotifyDictionaryChangedAction.Add)} 或 {nameof(NotifyDictionaryChangedAction.Remove)} 。");
            }
        }

        public NotifyDictionaryChangedEventArgs(NotifyDictionaryChangedAction action, TKey changedKey, TValue oldValue, TValue newValue)
        {
            if (!Enum.IsDefined(typeof(NotifyDictionaryChangedAction), action)) throw new ArgumentOutOfRangeException(nameof(action), action, $"动作参数未在枚举 {typeof(NotifyDictionaryChangedAction)} 中定义。");

            this.action = action;
            this.changedKey = changedKey;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }
    }
}

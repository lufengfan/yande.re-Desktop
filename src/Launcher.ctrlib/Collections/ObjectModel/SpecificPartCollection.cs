using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Launcher.Collections.ObjectModel
{
    public class SpecificPartCollection<T> : ObservableCollection<T>, IAddChild
    {
        public SpecificPartCollection() : base() { }
        public SpecificPartCollection(List<T> list) : base(list) { }
        public SpecificPartCollection(IEnumerable<T> collection) : base(collection) { }

        protected virtual void AddChild(object value)
        {
            if (value == null && typeof(T).IsValueType)
                throw new ArgumentNullException(nameof(value));

            if (!(value == null && value is T))
                throw new ArgumentOutOfRangeException(nameof(value), value, "不接受的值。");

            this.Add((T)value);
        }

        protected virtual void AddText(string text)
        {
            try { this.AddChild(text); }
            catch (Exception e)
            {
                throw new NotSupportedException("不支持向集合中添加字符串", e);
            }
        }

        void IAddChild.AddChild(object value) => this.AddChild(value);

        void IAddChild.AddText(string text) => this.AddText(text);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere
{
    public class ValueBox<T> : IEquatable<ValueBox<T>>
    {
        public static ValueBox<T> NonValue => new ValueBox<T>();

        private object syncObj = new object();

        private bool hasValue;
        public bool HasValue => this.hasValue;

        private T value;
        public T Value
        {
            get
            {
                lock (this.syncObj)
                {
                    if (this.hasValue)
                        return this.value;
                    else
                        throw new InvalidOperationException("未设置值。");
                }
            }
            set
            {
                lock (this.syncObj)
                {
                    this.value = value;
                    this.hasValue = true;
                }
            }
        }

        public ValueBox() => this.hasValue = false;

        public ValueBox(T value) : this() => this.Value = value;

        public void Clear()
        {
            this.hasValue = false;
        }

        public override bool Equals(object obj) => (obj is ValueBox<T> box) && this.Equals(box);

        public bool Equals(ValueBox<T> other)
        {
            if (this.HasValue && other.HasValue)
                return EqualityComparer<T>.Default.Equals(this.Value, other.Value);
            else
                return !(this.HasValue ^ other.HasValue);
        }

        public override int GetHashCode()
        {
            if (this.HasValue)
                return this.Value.GetHashCode();
            else
                return 0;
        }

        public static bool operator ==(ValueBox<T> left, ValueBox<T> right) => EqualityComparer<ValueBox<T>>.Default.Equals(left, right);

        public static bool operator !=(ValueBox<T> left, ValueBox<T> right) => !(left == right);

        public static implicit operator ValueBox<T>(T value) => new ValueBox<T>(value);

        public static explicit operator T(ValueBox<T> box) => box.Value;
    }
}

using System;
using System.Collections.Generic;

namespace FO.Utilities
{
    public class ObservableType<T>
    {
        [UnityEngine.SerializeField]
        protected T value = default;

        protected List<Action<T>> valueHasChangedCallbacks;

        public virtual T Value
        {
            get => value;
            set
            {
                this.value = value;
                foreach (var callback in valueHasChangedCallbacks)
                {
                    callback?.Invoke(this.value);
                }
            }
        }

        public ObservableType(T value)
        {
            this.value = value;
            valueHasChangedCallbacks = new List<Action<T>>();
        }

        public void Subscribe(Action<T> callback)
        {
            valueHasChangedCallbacks.Add(callback);
        }

        public void Unsubscribe(Action<T> callback)
        {
            valueHasChangedCallbacks.Remove(callback);
        }

        public static ObservableType<T> operator +(ObservableType<T> value, Action<T> action)
        {
            value.valueHasChangedCallbacks.Add(action);
            return value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ObservableType<T>))
            {
                return false;
            }

            var _value = (ObservableType<T>)obj;

            return EqualityComparer<T>.Default.Equals(value, _value.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
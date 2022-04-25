//
//  NumericObservable.cs
//
//  Created by FrancescObrador on 16/05/2022
//

using System;
using System.Collections.Generic;

namespace FO.Utilities
{
    [Serializable]
    public class NumericObservable
    {
        private List<Action<double>> valueHasChangedCallbacks;

        [UnityEngine.SerializeField]
        private double value;

        public double Value
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

        public NumericObservable(double value = 0)
        {
            this.value = value;
            valueHasChangedCallbacks = new List<Action<double>>();
        }

        public void Subscribe(Action<double> callback)
        {
            valueHasChangedCallbacks.Add(callback);
        }

        public void Unsubscribe(Action<double> callback)
        {
            valueHasChangedCallbacks.Remove(callback);
        }

        public static NumericObservable operator +(NumericObservable value, Action<double> action)
        {
            value.valueHasChangedCallbacks.Add(action);
            return value;
        }

        public static NumericObservable operator +(NumericObservable value, double amount)
        {
            value.value += amount;

            foreach (var callback in value.valueHasChangedCallbacks)
            {
                callback(value.value);
            }
            return value;
        }

        public static NumericObservable operator ++(NumericObservable value)
        {
            value.value += 1;

            foreach (var callback in value.valueHasChangedCallbacks)
            {
                callback(value.value);
            }
            return value;
        }

        public static NumericObservable operator -(NumericObservable value, double amount)
        {
            value.value -= amount;

            foreach (var callback in value.valueHasChangedCallbacks)
            {
                callback(value.value);
            }

            return value;
        }

        public static NumericObservable operator --(NumericObservable value)
        {
            value.value -= 1;

            foreach (var callback in value.valueHasChangedCallbacks)
            {
                callback(value.value);
            }
            return value;
        }

        public static implicit operator double(NumericObservable observable)
        {
            return observable.value;
        }

        public static bool operator ==(NumericObservable value, double amount)
        {
            return value.Value == amount;
        }

        public static bool operator !=(NumericObservable value, double amount)
        {
            return value.Value != amount;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is NumericObservable))
            {
                return false;
            }

            var _value = (NumericObservable)obj;

            return value == _value;

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

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
    public class NumericObservable : ObservableType<double>
    {
        public NumericObservable(double value = 0) : base(value)
        {
        }

        public static NumericObservable operator +(NumericObservable value, double amount)
        {
            value.Value += amount;
            return value;
        }

        public static NumericObservable operator ++(NumericObservable value)
        {
            value.Value += 1;
            return value;
        }

        public static NumericObservable operator -(NumericObservable value, double amount)
        {
            value.Value -= amount;
            return value;
        }

        public static NumericObservable operator --(NumericObservable value)
        {
            value.Value -= 1;
            return value;
        }

        public static NumericObservable operator *(NumericObservable value, double multiplier)
        {
            value.Value *= multiplier;
            return value;
        }

        public static NumericObservable operator /(NumericObservable value, double divisor)
        {
            value.Value /= divisor;
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
    }
}

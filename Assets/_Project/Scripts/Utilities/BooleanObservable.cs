//
//  NumericObservable.cs
//
//  Created by FrancescObrador on 16/05/2022
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FO.Utilities
{
    [Serializable]
    public class BooleanObservable
    {
        private List<Action<bool>> valueHasChangedCallbacks;

        [UnityEngine.SerializeField]
        private bool value;

        public bool Value
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

        public BooleanObservable(bool value)
        {
            this.value = value;
            valueHasChangedCallbacks = new List<Action<bool>>();
        }

        public void Subscribe(Action<bool> callback)
        {
            valueHasChangedCallbacks.Add(callback);
        }

        public void Unsubscribe(Action<bool> callback)
        {
            valueHasChangedCallbacks.Remove(callback);
        }

        public static implicit operator bool(BooleanObservable value)
        {
            return value.value;
        }

        public static bool operator ==(BooleanObservable lhs, bool rhs)
        {
            return lhs.value == rhs;
        }

        public static bool operator !=(BooleanObservable lhs, bool rhs)
        {
            return lhs.value != rhs;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BooleanObservable))
            {
                return false;
            }

            var _value = (BooleanObservable)obj;

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

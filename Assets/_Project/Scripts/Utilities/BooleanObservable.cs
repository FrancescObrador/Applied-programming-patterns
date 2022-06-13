//
//  NumericObservable.cs
//
//  Created by FrancescObrador on 16/05/2022
//

using System;

namespace FO.Utilities
{
    [Serializable]
    public class BooleanObservable : ObservableType<bool>
    {
        public BooleanObservable(bool value) : base(value)
        {
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
    }
}

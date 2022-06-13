//
//  StringObservable.cs
//
//  Created by FrancescObrador on 05/06/2022
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace FO.Utilities
{
    [Serializable]
    public class StringObservable : ObservableType<string>
    {
        public StringObservable(string value = "") : base(value)
        { 
        }

        public static StringObservable operator +(StringObservable value, string str)
        {
            value.Value += str;
            return value;
        }

        public static bool operator ==(StringObservable value, string str)
        {
            return value.Value == str;
        }

        public static bool operator !=(StringObservable value, string str)
        {
            return value.Value != str;
        }
    }
}


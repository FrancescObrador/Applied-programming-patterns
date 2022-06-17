//
//  AaNotationConversor.cs
//
//  Created by Gram Games
//

using System;
using System.Collections.Generic;

namespace FO.Utilities
{
    public static class AaNotationConversor
    {
        private static readonly int charA = Convert.ToInt32('a');

        private static readonly Dictionary<int, string> units = new Dictionary<int, string>
    {
        {0, ""},
        {1, "K"},
        {2, "M"},
        {3, "B"},
        {4, "T"}
    };

        public static string FormatNumber(double value)
        {
            if (value < 1)
            {
                return "0";
            }

            var n = (int)Math.Log(value, 1000);
            var m = (value / Math.Pow(1000, n));
            var unit = string.Empty;

            if (n < units.Count)
            {
                unit = units[n];
            }
            else
            {
                var unitInt = n - units.Count;
                var secondUnit = unitInt % 26;
                var firstUnit = unitInt / 26;
                unit = Convert.ToChar(firstUnit + charA).ToString() + Convert.ToChar(secondUnit + charA).ToString();
            }

            // Math.Floor(m * 100) / 100) fixes rounding errors
            return (Math.Floor(m * 100) / 100).ToString("F2") + unit;
        }
    }
}
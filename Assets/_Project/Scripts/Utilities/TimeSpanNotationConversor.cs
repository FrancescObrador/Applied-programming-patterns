//
//  TimeSpanNotationConversor.cs
//
//  Created by FrancescObrador on 18/04/2022
//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FO.Utilities
{
    public static class TimeSpanNotationConversor
    {
        static readonly Dictionary<int, string> bigPeriods = new Dictionary<int, string>() {
            { 365, " years " },
            { 30, " months " },
        };

        public static string FormatSecondsToTime(int _time)
        {
            var time = new TimeSpan(0, 0, _time);
            var result = "";
            int days = time.Days;

            foreach (var timespan in bigPeriods) {
                if(days > timespan.Key) {
                    var period = days / timespan.Key;
                    result += period.ToString() + timespan.Value;

                    days -= period * timespan.Key;
                }
            }

            if (days > 0) {
                result += days.ToString() + "d ";
            }
            if (time.Hours > 0) {
                result += time.Hours.ToString() + "h ";
            }
            if (time.Minutes > 0) {
                result += time.Minutes.ToString() + "m ";
            }

            result += time.Seconds.ToString() + "s";

            return result;
        }
    }
}

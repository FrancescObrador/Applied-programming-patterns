//
//  TimeSpanNotationConversor.cs
//
//  Created by FrancescObrador on 18/04/2022
//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeSpanNotationConversor 
{
    public static string FormatSecondsToTime(TimeSpan time)
    {
        var result = "";

        int days = time.Days;

        if (days > 365)
        {
            var years = days / 365;
            result += years.ToString() + " years ";

            days -= years * 365;
        }

        if (days > 30)
        {
            var months = days / 30;
            result += months.ToString() + " months ";
            days -= months * 30;
        }

        if (days > 0)
        {
            result += days.ToString() + "d ";
        }

        if (time.Hours > 0)
        {
            result += time.Hours.ToString() + "h ";
        }

        if (time.Minutes > 0)
        {
            result += time.Minutes.ToString() + "m ";
        }

        result += time.Seconds.ToString() + "s";

        return result;
    }
}

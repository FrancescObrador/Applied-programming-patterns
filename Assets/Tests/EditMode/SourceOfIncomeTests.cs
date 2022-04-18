using System;
using NUnit.Framework;
using UnityEngine;
using ViewModels;

public class SourceOfIncomeTests
{
    [Test]
    public void SourceOfIncomeTest_TimeSpan_Complete_Display()
    {
        VM_SourceOfIncome source = new VM_SourceOfIncome();

        source.time = new TimeSpan(1, 10, 11);

        Debug.Log(source.GetTimeSpanText());

        Assert.AreEqual("1h 10m 11s", source.GetTimeSpanText());
    }

    [Test]
    public void SourceOfIncomeTest_TimeSpan_Only_Seconds()
    {
        VM_SourceOfIncome source = new VM_SourceOfIncome();

        source.time = new TimeSpan(0, 0, 11);

        Debug.Log(source.GetTimeSpanText());

        Assert.AreEqual("11s", source.GetTimeSpanText());
    }
}

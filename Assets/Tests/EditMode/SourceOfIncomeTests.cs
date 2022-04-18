using System;
using NUnit.Framework;
using UnityEngine;
using ViewModels;

public class SourceOfIncomeTests
{
    [Test]
    public void SourceOfIncomeTest_TimeSpan_CompleteDisplay()
    {
        VM_SourceOfIncome source = new VM_SourceOfIncome();

        source.time = TimeSpan.FromSeconds(143523463);

        Debug.Log(source.TimeSpanText);

        Assert.AreEqual("4 years 6 months 21d 3h 37m 43s", source.TimeSpanText);
    }

    [Test]
    public void SourceOfIncomeTest_TimeSpan_OnlySeconds()
    {
        VM_SourceOfIncome source = new VM_SourceOfIncome();

        source.time = new TimeSpan(0, 0, 11);

        Debug.Log(source.TimeSpanText);

        Assert.AreEqual("11s", source.TimeSpanText);
    }

    [Test]
    public void SourceOfIncomeTest_TimeSpan_MinutesAndSeconds()
    {
        VM_SourceOfIncome source = new VM_SourceOfIncome();

        source.time = new TimeSpan(0, 1, 11);

        Debug.Log(source.TimeSpanText);

        Assert.AreEqual("1m 11s", source.TimeSpanText);
    }
}

using System;
using NUnit.Framework;
using UnityEngine;
using FO.ViewModels;

public class SourceOfIncomeTests
{
    VM_SourceOfIncome source = new VM_SourceOfIncome();

    [Test]
    public void SourceOfIncomeTest_TimeSpan_CompleteDisplay()
    {
        source.waitTime = 143523463;

        Debug.Log(source.TimeSpanText);

        Assert.AreEqual("4 years 6 months 21d 3h 37m 43s", source.TimeSpanText);
    }

    [Test]
    public void SourceOfIncomeTest_TimeSpan_OnlySeconds()
    {
        source.waitTime = 11;

        Debug.Log(source.TimeSpanText);

        Assert.AreEqual("11s", source.TimeSpanText);
    }

    [Test]
    public void SourceOfIncomeTest_TimeSpan_MinutesAndSeconds()
    {
        source.waitTime = 661;

        Debug.Log(source.TimeSpanText);

        Assert.AreEqual("11m 1s", source.TimeSpanText);
    }
}

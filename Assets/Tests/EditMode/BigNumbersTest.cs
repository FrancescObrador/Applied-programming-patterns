using NUnit.Framework;
using UnityEngine;
using FO.Utilities;

public class BigNumbersTest
{
    public const double MaxValue = 1.7976931348623157E+308;

    [Test]
    public void BigNumbersTestSimplePass()
    {
        Assert.AreEqual("1.00", AaNotationConversor.FormatNumber(1));
    }

    [Test]
    public void BigNumbers_K()
    {
        Assert.AreEqual("1.00K", AaNotationConversor.FormatNumber(1000));
    }

    [Test]
    public void BigNumbers_M()
    {
        Assert.AreEqual("1.00M", AaNotationConversor.FormatNumber(1000000));
    }

    [Test]
    public void BigNumbers_B()
    {
        Assert.AreEqual("1.00B", AaNotationConversor.FormatNumber(1000000000));
    }

    [Test]
    public void BigNumbers_T()
    {
        Assert.AreEqual("1.00T", AaNotationConversor.FormatNumber(1000000000000));
    }
}

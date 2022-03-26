using NUnit.Framework;
using UnityEngine;

public class BigNumbersTest
{
    public const double MaxValue = 1.7976931348623157E+308;

    [Test]
    public void BigNumbersTestSimplePasses()
    {
        Debug.Log(AaNotationConversor.FormatNumber(MaxValue));
        Assert.AreEqual("1", AaNotationConversor.FormatNumber(1));
    }
}

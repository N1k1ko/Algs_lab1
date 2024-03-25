using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class TestsClass
{
    private static string F(string num1, string op, string num2) => Exsr3.Exsr3.PerformOperation(num1, op, num2);
    
    #region DefaultTests
    [TestMethod]
    public void DefaultTest1() => Assert.AreEqual("1122", F("123", "+", "999"));

    [TestMethod]
    public void DefaultTest2() => Assert.AreEqual("132", F("232", "+", "-100"));

    [TestMethod]
    public void DefaultTest3() => Assert.AreEqual("-299", F("-100", "-", "199"));
    #endregion

    #region OpPlusTests
    [TestMethod]
    public void TestPPP() => Assert.AreEqual("299", F("199", "+", "100"));
    [TestMethod]
    public void TestPPP2() => Assert.AreEqual("299", F("100", "+", "199"));
    [TestMethod]
    public void TestPPP3() => Assert.AreEqual("160", F("107", "+", "53"));
    [TestMethod]
    public void TestPPP4() => Assert.AreEqual("160", F("53", "+", "107"));
    [TestMethod]
    public void TestPPP5() => Assert.AreEqual("200", F("100", "+", "100"));
    [TestMethod]
    public void TestPPM() => Assert.AreEqual("-99", F("100", "+", "-199"));
    [TestMethod]
    public void TestPPM2() => Assert.AreEqual("99", F("199", "+", "-100"));
    [TestMethod]
    public void TestPPM3() => Assert.AreEqual("0", F("100", "+", "-100"));
    [TestMethod]
    public void TestMPP() => Assert.AreEqual("-99", F("-199", "+", "100"));
    [TestMethod]
    public void TestMPP2() => Assert.AreEqual("99", F("-100", "+", "199"));
    [TestMethod]
    public void TestMPP3() => Assert.AreEqual("0", F("-100", "+", "100"));
    [TestMethod]
    public void TestMPM() => Assert.AreEqual("-299", F("-199", "+", "-100"));
    [TestMethod]
    public void TestMPM2() => Assert.AreEqual("-299", F("-100", "+", "-199"));
    [TestMethod]
    public void TestMPM3() => Assert.AreEqual("-200", F("-100", "+", "-100"));
    #endregion

    #region OpMinusTests
    [TestMethod]
    public void TestPMP() => Assert.AreEqual("-99", F("100", "-", "199"));
    [TestMethod]
    public void TestPMP2() => Assert.AreEqual("99", F("199", "-", "100"));
    [TestMethod]
    public void TestPMP3() => Assert.AreEqual("0", F("100", "-", "100"));
    [TestMethod]
    public void TestPMP4() => Assert.AreEqual("50", F("53", "-", "3"));
    [TestMethod]
    public void TestPMM() => Assert.AreEqual("299", F("100", "-", "-199"));
    [TestMethod]
    public void TestPMM2() => Assert.AreEqual("299", F("199", "-", "-100"));
    [TestMethod]
    public void TestPMM3() => Assert.AreEqual("200", F("100", "-", "-100"));
    [TestMethod]
    public void TestMMP() => Assert.AreEqual("-299", F("-100", "-", "199"));
    [TestMethod]
    public void TestMMP2() => Assert.AreEqual("-299", F("-199", "-", "100"));
    [TestMethod]
    public void TestMMP3() => Assert.AreEqual("-200", F("-100", "-", "100"));
    [TestMethod]
    public void TestMMM() => Assert.AreEqual("-99", F("-199", "-", "-100"));
    [TestMethod]
    public void TestMMM2() => Assert.AreEqual("99", F("-100", "-", "-199"));
    [TestMethod]
    public void TestMMM3() => Assert.AreEqual("0", F("-100", "-", "-100"));
    #endregion

    #region MaxTests
    #region OpPlusTests
    [TestMethod]
    public void TestMaxPPP() => Assert.AreEqual(new string('8',1000), F(new string('3',1000), "+", new string('5',1000)));
    [TestMethod]
    public void TestMaxPPP2() => Assert.AreEqual(new string('8',1000), F(new string('5',1000), "+", new string('3',1000)));
    [TestMethod]
    public void TestMaxPPP3() => Assert.AreEqual(new string('6',1000), F(new string('3',1000), "+", new string('3',1000)));
    [TestMethod]
    public void TestMaxPPM() => Assert.AreEqual("5"+new string('2',999), F(new string('5',1000), "+", "-"+new string('3',999)));
    [TestMethod]
    public void TestMaxPPM2() => Assert.AreEqual("2"+new string('7',998)+"8", F(new string('3',1000), "+", "-"+new string('5',999)));
    [TestMethod]
    public void TestMaxPPM3() => Assert.AreEqual("0", F(new string('3',999), "+", "-"+new string('3',999)));
    [TestMethod]
    public void TestMaxMPP() => Assert.AreEqual("5"+new string('2',999), F("-"+new string('3',999), "+", new string('5',1000)));
    [TestMethod]
    public void TestMaxMPP2() => Assert.AreEqual("2"+new string('7',998)+"8", F("-"+new string('5',999), "+", new string('3',1000)));
    [TestMethod]
    public void TestMaxMPP3() => Assert.AreEqual("0", F("-"+new string('3',999), "+", new string('3',999)));
    [TestMethod]
    public void TestMaxMPM() => Assert.AreEqual("-"+new string('8',999), F("-"+new string('3',999), "+", "-"+new string('5',999)));
    [TestMethod]
    public void TestMaxMPM2() => Assert.AreEqual("-"+new string('8',999), F("-"+new string('5',999), "+", "-"+new string('3',999)));
    [TestMethod]
    public void TestMaxMPM3() => Assert.AreEqual("-"+new string('6',999), F("-"+new string('3',999), "+", "-"+new string('3',999)));
    #endregion

    #region OpMinusTests
    [TestMethod]
    public void TestMaxPMP() => Assert.AreEqual("-"+new string('2',1000), F(new string('3',1000), "-", new string('5',1000)));
    [TestMethod]
    public void TestMaxPMP2() => Assert.AreEqual(new string('2',1000), F(new string('5',1000), "-", new string('3',1000)));
    [TestMethod]
    public void TestMaxPMP3() => Assert.AreEqual("0", F(new string('3',1000), "-", new string('3',1000)));
    [TestMethod]
    public void TestMaxPMM() => Assert.AreEqual("3"+new string('8',999), F(new string('3',1000), "-", "-"+new string('5',999)));
    [TestMethod]
    public void TestMaxPMM2() => Assert.AreEqual("5"+new string('8',999), F(new string('5',1000), "-", "-"+new string('3',999)));
    [TestMethod]
    public void TestMaxPMM3() => Assert.AreEqual("3"+new string('6',999), F(new string('3',1000), "-", "-"+new string('3',999)));
    [TestMethod]
    public void TestMaxMMP() => Assert.AreEqual("-5"+new string('8',999), F("-"+new string('3',999), "-", new string('5',1000)));
    [TestMethod]
    public void TestMaxMMP2() => Assert.AreEqual("-3"+new string('8',999), F("-"+new string('5',999), "-", new string('3',1000)));
    [TestMethod]
    public void TestMaxMMP3() => Assert.AreEqual("-3"+new string('6',999), F("-"+new string('3',999), "-", new string('3',1000)));
    [TestMethod]
    public void TestMaxMMM() => Assert.AreEqual("5"+new string('2',999), F("-"+new string('3',999), "-", "-"+new string('5',1000)));
    [TestMethod]
    public void TestMaxMMM2() => Assert.AreEqual("2"+new string('7',998)+"8", F("-"+new string('5',999), "-", "-"+new string('3',1000)));
    [TestMethod]
    public void TestMaxMMM3() => Assert.AreEqual("0", F("-"+new string('3',999), "-", "-"+new string('3',999)));
    #endregion
    #endregion
}
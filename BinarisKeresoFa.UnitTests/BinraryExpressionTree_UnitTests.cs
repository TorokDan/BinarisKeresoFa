using NUnit.Framework;
using BinarisKeresoFa;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace BinarisKeresoFa.UnitTests
{
    public class BinraryExpressionTree_UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("2", TestName = "only node")]
        [TestCase("23+", TestName = "Simple operation")]
        [TestCase("23-", TestName = "Simple operation")]
        [TestCase("23*", TestName = "Simple operation")]
        [TestCase("23/", TestName = "Simple operation")]
        [TestCase("23^", TestName = "Simple operation")]
        public void Build(string data)
        {
            Assert.AreEqual( data, BinaryExpressionTree.Build(data).ToString());
        }

        [Test]
        [TestCase("2", "2", TestName = "only node")]
        [TestCase("(2+3)", "23+", TestName = "Simple operation")]
        [TestCase("(2-3)", "23-", TestName = "Simple operation")]
        [TestCase("(2*3)", "23*", TestName = "Simple operation")]
        [TestCase("(2/3)", "23/", TestName = "Simple operation")]
        [TestCase("(2^3)", "23^", TestName = "Simple operation")]
        [TestCase("(2+(3*4))", "234*+", TestName = "Example operation")]
        [TestCase("((2*3)+4)", "23*4+", TestName = "Example operation")]
        [TestCase("((2*3)+(4*5))", "23*45*+", TestName = "Example operation")]
        [TestCase("((2+3)/(4-5))", "23+45-/", TestName = "Example operation")]
        [TestCase("((((2+3)*4)+5)/((6^7)+8))", "23+4*5+67^8+/", TestName = "Example operation")]
        public void Convert(string expRes, string input)
        {
            Assert.AreEqual( expRes, BinaryExpressionTree.Build(input).Convert());
        }

        [Test]
        [TestCase("28+", 5, TestName = "Simple operation")]
        [TestCase( "28-", -6, TestName = "Simple operation")]
        [TestCase("28*", 16, TestName = "Simple operation")]
        [TestCase("28/", 0.25, TestName = "Simple operation")]
        [TestCase("23^", 256, TestName = "Simple operation")]
        [TestCase("234*+", 14, TestName = "Example operation")]
        [TestCase("23*4+", 10, TestName = "Example operation")]
        [TestCase("23*45*+", 26, TestName = "Example operation")]
        [TestCase("23+45-/", -5, TestName = "Example operation")]
        [TestCase("23+4*5+67^8+/", 0.00009, TestName = "Example operation")]
        public void Evaluate(string data, double expRes)
        {
            Assert.AreEqual( expRes, BinaryExpressionTree.Build(data).Evaluate());
        }
    }
}
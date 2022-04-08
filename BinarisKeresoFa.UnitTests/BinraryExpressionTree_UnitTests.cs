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
    }
}
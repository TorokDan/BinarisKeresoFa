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
        [TestCase("2", "2", TestName = "only node")]
        [TestCase("2+3", "23+", TestName = "Simple operation")]
        [TestCase("2-3", "23-", TestName = "Simple operation")]
        [TestCase("2*3", "23*", TestName = "Simple operation")]
        [TestCase("2/3", "23/", TestName = "Simple operation")]
        [TestCase("2^3", "23^", TestName = "Simple operation")]
        [TestCase("(2+(3*4))", "234*+", TestName = "Example operation")]
        [TestCase("((2*3)+4)", "23*4+", TestName = "Example operation")]
        [TestCase("((2*3)+(4*5))", "23*45*+", TestName = "Example operation")]
        [TestCase("((2+3)/(4-5))", "23+45-/", TestName = "Example operation")]
        [TestCase("((((2+3)*4)+5)/((6^7)+8))", "23+4*5+67^8+/", TestName = "Example operation")]
        public void Build(string data, string expRes)
        {
            Assert.AreEqual( expRes, BinaryExpressionTree.Build(data).ToString());
        }
    }
}
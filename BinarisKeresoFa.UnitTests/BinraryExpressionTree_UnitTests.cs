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
        [TestCase("2+3", "23+")]
        [TestCase("2+3*4", "23+4*")]
        public void Build(string data, string expRes)
        {
            Assert.AreEqual( expRes, BinaryExpressionTree.Build(data).ToString());
        }
    }
}
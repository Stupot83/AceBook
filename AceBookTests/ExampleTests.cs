using NUnit.Framework;
using AceBook.Models;

namespace AceBookTests
{
    [TestFixture]
    public class CalculatorTest
    {
        Calculator sut;
        [SetUp]
        

        public void TestSetup()
        {
            sut = new Calculator();
        }

        [Test]
        public void ShouldAddTwoNumbers()
        {
            int expectedResult = sut.Add(10, 8);
            Assert.That(expectedResult, Is.EqualTo(17));
        }

        [Test]
        public void ShouldMultiplyTwoNumbers()
        {
            int expectedResult = sut.Multiply(10, 10);
            Assert.That(expectedResult, Is.EqualTo(100));
        }

        [Test]
        public void ShouldDivideTwoNumbers()
        {
            float expectedResult = sut.Divide(10, 10);
            Assert.That(expectedResult, Is.EqualTo(1));
        }
    }
}
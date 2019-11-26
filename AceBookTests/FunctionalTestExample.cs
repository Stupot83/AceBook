using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AceBookTests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]

    class UnitTest1
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void IndexHasTitle()
        {
            // Arrange

            var url = "https://google.com";

            // Act
            _driver.Navigate().GoToUrl(url);
            var result = _driver.Title;


            // Assert
            Assert.That(result, Does.Contain("Google").IgnoreCase);

        }
    }
}
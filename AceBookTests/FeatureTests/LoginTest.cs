using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AceBookTests.FeatureTests
{
    [TestFixture]

    public class LoginTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void FillInFormAndLogin()
        {
            var url = "https://localhost:5001/Account/Login";

            _driver.Navigate().GoToUrl(url);

            
            _driver.Get("#email").SendKeys("a@a.com");
            _driver.Get("#password").SendKeys("c");
            _driver.Get("#submit").Click();

            Assert.That(_driver.PageSource, Does.Contain("Acebook"));
        }

        [Test]
        public void CheckRedirect()
        {
            var url = "https://localhost:5001/Account/Login";

            _driver.Navigate().GoToUrl(url);

            _driver.Get("#email").SendKeys("a@a.com");
            _driver.Get("#password").SendKeys("c");
            _driver.Get("#submit").Click();

            var expectedUrl = _driver.Url;

            Assert.AreEqual("https://localhost:5001/", expectedUrl);
        }

        [Test]
        public void CheckNonRedirect()
        {
            var url = "https://localhost:5001/Account/Login";

            _driver.Navigate().GoToUrl(url);

            _driver.Get("#email").SendKeys("b@b.com");
            _driver.Get("#password").SendKeys("a");
            _driver.Get("#submit").Click();

            var expectedUrl = _driver.Url;

            Assert.AreEqual("https://localhost:5001/Account/Login", expectedUrl);
        }
    }
}

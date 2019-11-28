using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AceBookTests
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

            
            _driver.FindElement(By.CssSelector("#email")).SendKeys("a@a.com");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("c");
            _driver.FindElement(By.CssSelector("#submit")).Click();

            Assert.That(_driver.PageSource, Does.Contain("Acebook"));
        }

        [Test]
        public void CheckRedirect()
        {
            var url = "https://localhost:5001/Account/Login";

            _driver.Navigate().GoToUrl(url);

            _driver.FindElement(By.CssSelector("#email")).SendKeys("a@a.com");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("c");
            _driver.FindElement(By.CssSelector("#submit")).Click();

            var expectedUrl = _driver.Url;

            Assert.AreEqual("https://localhost:5001/", expectedUrl);
        }

        [Test]
        public void CheckNonRedirect()
        {
            var url = "https://localhost:5001/Account/Login";

            _driver.Navigate().GoToUrl(url);

            _driver.FindElement(By.CssSelector("#email")).SendKeys("b@b.com");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("a");
            _driver.FindElement(By.CssSelector("#submit")).Click();

            var expectedUrl = _driver.Url;

            Assert.AreEqual("https://localhost:5001/Account/Login", expectedUrl);
        }
    }
}

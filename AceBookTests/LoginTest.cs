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
            var url = "http://localhost:5000/account/login";

            _driver.Navigate().GoToUrl(url);

            _driver.FindElement(By.CssSelector("#email")).SendKeys("83@a.com");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("c");
            _driver.FindElement(By.CssSelector("#submit")).Click();

            Assert.That(_driver.PageSource, Does.Contain("Welcome to Acebook"));
        }
    }
}

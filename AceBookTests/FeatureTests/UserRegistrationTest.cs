using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AceBookTests.FeatureTests
{
    [TestFixture]
    public class UserRegistrationTest
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
        public void FillInFormAndSubmit()
        {
            var url = "http://localhost:5000/user/register";
            
            _driver.Navigate().GoToUrl(url);

            _driver.FindElement(By.CssSelector("#firstName")).SendKeys("Susan");
            _driver.FindElement(By.CssSelector("#lastName")).SendKeys("Longley");
            _driver.FindElement(By.CssSelector("#email")).SendKeys("Susan.Longley@bglgroup.co.uk");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("thelegend27");
            _driver.FindElement(By.CssSelector("#confirmPassword")).SendKeys("thelegend27");
            _driver.FindElement(By.CssSelector("#phoneNumber")).SendKeys("Susan");
            _driver.FindElement(By.CssSelector("#birthDate")).SendKeys("11/11/11");
            _driver.FindElement(By.CssSelector("#gender")).SendKeys("Susan");
            _driver.FindElement(By.CssSelector("#submit")).Click();
            
            Assert.That(_driver.PageSource, Does.Contain("Acebook"));
        }
    }
}
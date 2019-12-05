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

            _driver.Get("#firstName").SendKeys("Susan");
            _driver.Get("#lastName").SendKeys("Longley");
            _driver.Get("#email").SendKeys("Susan.Longley@bglgroup.co.uk");
            _driver.Get("#password").SendKeys("thelegend27");
            _driver.Get("#confirmPassword").SendKeys("thelegend27");
            _driver.Get("#phoneNumber").SendKeys("Susan");
            _driver.Get("#birthDate").SendKeys("11/11/11");
            _driver.Get("#gender").SendKeys("Susan");
            _driver.Get("#submit").Click();
            
            Assert.That(_driver.PageSource, Does.Contain("Acebook"));
        }
    }
}
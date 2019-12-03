using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AceBookTests.FeatureTests
{
    [TestFixture]

    public class FriendRequestTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            Login();
        }

        private void Login()
        {
            var url = "https://localhost:5001/Account/Login";
            _driver.Navigate().GoToUrl(url);

            _driver.FindElement(By.CssSelector("#email")).SendKeys("Susan.Longley@bglgroup.co.uk");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("thelegend27");
            _driver.FindElement(By.CssSelector("#submit")).Click();
            _driver.FindElement(By.CssSelector("#friendRequests")).Click();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void GoToFriendRequestPage()
        {
            Assert.That(_driver.Url, Does.Contain("/User/FriendRequest"));
        }

        //[Test]
        //public void FriendRequestIsPopulated()
        //{
        //    var requesterEmail = _driver.FindElement(By.CssSelector("#userFriendRequest"));
        //    Assert.That(requesterEmail.GetAttribute("value"), Is.EqualTo("tim@tim"));
        //}
    }
}

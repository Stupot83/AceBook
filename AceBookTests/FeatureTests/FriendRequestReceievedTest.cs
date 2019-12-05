using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AceBook.Helpers;

namespace AceBookTests.FeatureTests
{
    [TestFixture]

    public class FriendRequestTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            DbHelper.ClearCollection("friend");
            _driver = new ChromeDriver();
            CreateFriendRequest();
            Login();
            _driver.Get("#friendRequests").Click();
        }

        private void Login()
        {
            var url = "https://localhost:5001/Account/Login";
            _driver.Navigate().GoToUrl(url);

            _driver.Get("#email").SendKeys("Susan.Longley@bglgroup.co.uk");
            _driver.Get("#password").SendKeys("thelegend27");
            _driver.Get("#submit").Click();
        }

        private void CreateFriendRequest()
        {
            DbHelper.AddFriend("tim@tim", "Susan.Longley@bglgroup.co.uk");
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

        [Test]
        public void FriendRequestIsPopulated()
        {
            IWebElement requesterEmail = _driver.Get(".friendRequestEmail");
            Assert.That(requesterEmail.Text, Is.EqualTo("tim@tim"));
        }

        [Test]
        public void AcceptFriendRequest()
        {
            _driver.Get(".friendRequestAccept").Click();
            var noRequestsBoss = _driver.Get("#noRequestsBoss");
            Assert.That(noRequestsBoss.Displayed, Is.EqualTo(true));
        }

        [Test]
        public void DeclineFriendRequest()
        {
            _driver.Get(".friendRequestDecline").Click();
            var noRequestsBoss = _driver.Get("#noRequestsBoss");
            Assert.That(noRequestsBoss.Displayed, Is.EqualTo(true));
        }
    }
}

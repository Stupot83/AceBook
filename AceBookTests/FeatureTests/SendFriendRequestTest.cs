using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AceBook.Helpers;
using AceBook.Models;
using System;
using System.Threading;

namespace AceBookTests.FeatureTests
{
    [TestFixture]

    public class SendFriendRequest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            DbHelper.ClearCollection("friend");
            _driver = new ChromeDriver();            
            Login();
            var user = User.GetUserByEmail("tim@tim");
            _driver.Navigate().GoToUrl($"https://localhost:5001/User/Profile/{user.Id.ToString()}");
            Console.WriteLine($"https://localhost:5001/User/Profile/{user.Id.ToString()}");
        }

        private void Login()
        {
            var url = "https://localhost:5001/Account/Login";
            _driver.Navigate().GoToUrl(url);

            _driver.Get("#email").SendKeys("Susan.Longley@bglgroup.co.uk");
            _driver.Get("#password").SendKeys("thelegend27");
            _driver.Get("#submit").Click();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void ClickSendFriendRequest()
        {
            _driver.Get("#sendFriendRequestButton").Click();
            var friendRequestSentMessage = _driver.Get("#friendRequestSentMessage");
            Assert.That(friendRequestSentMessage.Displayed, Is.EqualTo(true));
        }

        [Test]
        public void FriendRequestAcceptedText()
        {
            _driver.Get("#sendFriendRequestButton").Click();
            var request = Friend.GetOutgoingRequest("Susan.Longley@bglgroup.co.uk")[0];
            DbHelper.SetFriendRequestStatus(request.Id, DbHelper.RequestAccepted);
            
            _driver.Navigate().Refresh();
            Thread.Sleep(10000);
            var friendRequestAcceptedMessage = _driver.Get("#friendRequestAcceptedMessage");
            Assert.That(friendRequestAcceptedMessage.Displayed, Is.EqualTo(true));
        }

        [Test]
        public void FriendRequestDeclinedText()
        {
            _driver.Get("#sendFriendRequestButton").Click();
            var request = Friend.GetOutgoingRequest("Susan.Longley@bglgroup.co.uk")[0];
            DbHelper.SetFriendRequestStatus(request.Id, DbHelper.RequestDeclined);
            Thread.Sleep(2000);
            _driver.Navigate().Refresh();
            var friendRequestDeclinedMessage = _driver.Get("#friendRequestDeclinedMessage");
            Assert.That(friendRequestDeclinedMessage.Displayed, Is.EqualTo(true));
        }
    }
}
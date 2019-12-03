using NUnit.Framework;
using AceBook.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AceBook.Helpers;
using AceBook.Models;
using Microsoft.AspNetCore.Session;
using Moq;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    public class UserControllerTest
    {
        private UserController controller;

        string firstName = "Joseph";
        string lastName = "Timothy";
        string email = "JosephTimothy@email.com";
        string password = "$upa$ecret";
        string confirmPassword = "$upa$ecret";
        string phoneNumber = "1234567890";
        string birthDate = "27/06/2001";
        string gender = "Frube";

        [SetUp]
        public void TestSetup()
        {
            controller = new UserController();
            DbHelper.ClearCollection("friend");
            DbHelper.AddFriend("JosephTimothy@email.com", "Susan.Longley@bglgroup.co.uk");
        }

        [Test]
        public void GetRegister()
        {
            var result = controller.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }

        [Test]
        public void UserRegisterSuccess()
        {
            var result = controller.Register(
                firstName,
                lastName,
                email,
                password,
                confirmPassword,
                phoneNumber,
                birthDate,
                gender) as RedirectResult;
            Assert.AreEqual("/home", result.Url);
        }

        [Test]
        public void UserRegisterFail()
        {
            var result = controller.Register(
                firstName,
                lastName,
                email,
                password,
                "non matching password",
                phoneNumber,
                birthDate,
                gender) as BadRequestResult;
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void AddFriendSuccessful()
        {
            var mockContext = new Mock<HttpContext>();
            var mockSession = new MockSession();
            mockSession.SetString("email", "Susan.Longley@bglgroup.co.uk");
            mockContext.Setup(s => s.Session).Returns(mockSession);
            controller.ControllerContext.HttpContext = mockContext.Object;
            var result = controller.AddFriend("JosephTimothy@email.com") as OkResult;
            
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void AcceptFriendSuccessful()
        {
            var mockContext = new Mock<HttpContext>();
            var mockSession = new MockSession();
            mockSession.SetString("email", "JosephTimothy@email.com");
            mockContext.Setup(s => s.Session).Returns(mockSession);
            controller.ControllerContext.HttpContext = mockContext.Object;
            var friendRequests = Friend.GetIncomingRequest("Susan.Longley@bglgroup.co.uk");
            var result = controller.AcceptFriend(friendRequests[0].Id.ToString()) as RedirectResult;

            Assert.AreEqual("/User/FriendRequest", result.);
        }

        [Test]
        public void DeclineFriendSuccessful()
        {
            var mockContext = new Mock<HttpContext>();
            var mockSession = new MockSession();
            mockSession.SetString("email", "JosephTimothy@email.com");
            mockContext.Setup(s => s.Session).Returns(mockSession);
            controller.ControllerContext.HttpContext = mockContext.Object;
            var friendRequests = Friend.GetIncomingRequest("Susan.Longley@bglgroup.co.uk");
            var result = controller.DeclineFriend(friendRequests[0].Id.ToString()) as RedirectResult;

            Assert.AreEqual("/User/FriendRequest", result.Url);
        }
    }    
}
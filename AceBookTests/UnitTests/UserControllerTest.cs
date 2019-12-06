using NUnit.Framework;
using AceBook.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AceBook.Helpers;
using AceBook.Models;
using Microsoft.AspNetCore.Session;
using Moq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    public class UserControllerTest
    {
        private UserController controller;

        public class File : IFormFile
        {
            public string ContentDisposition => throw new System.NotImplementedException();

            public string ContentType => throw new System.NotImplementedException();

            public string FileName => throw new System.NotImplementedException();

            public IHeaderDictionary Headers => throw new System.NotImplementedException();

            public long Length => throw new System.NotImplementedException();

            public string Name => throw new System.NotImplementedException();

            public void CopyTo(Stream target)
            {
                target.Write(Encoding.ASCII.GetBytes("someString"));
            }

            public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
            {
                throw new System.NotImplementedException();
            }

            public Stream OpenReadStream()
            {
                throw new System.NotImplementedException();
            }
        }

        string firstName = "Joseph";
        string lastName = "Timothy";
        string email = "JosephTimothy@email.com";
        string password = "$upa$ecret";
        string confirmPassword = "$upa$ecret";
        string phoneNumber = "1234567890";
        string birthDate = "27/06/2001";
        string gender = "Frube";
        IFormFile image = new File();

        [SetUp]
        public void TestSetup()
        {
            controller = new UserController();
            DbHelper.ClearCollection("friend");
            DbHelper.AddFriend("JosephTimothy@email.com", "Susan.Longley@bglgroup.com");
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
                gender,
                image) as RedirectResult;
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
                gender,
                image) as BadRequestResult;
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void AddFriendSuccessful()
        {
            var mockContext = new Mock<HttpContext>();
            var mockSession = new MockSession();
            mockSession.SetString("email", "Susan.Longley@bglgroup.com");
            mockContext.Setup(s => s.Session).Returns(mockSession);
            controller.ControllerContext.HttpContext = mockContext.Object;
            var userId = User.GetUserByEmail("JosephTimothy@email.com").Id.ToString();
            var result = controller.AddFriend("JosephTimothy@email.com", userId) as RedirectResult;

            Assert.That(result.Url, Does.Contain($"/User/{userId}"));
        }

        [Test]
        public void AcceptFriendSuccessful()
        {
            var mockContext = new Mock<HttpContext>();
            var mockSession = new MockSession();
            mockSession.SetString("email", "JosephTimothy@email.com");
            mockContext.Setup(s => s.Session).Returns(mockSession);
            controller.ControllerContext.HttpContext = mockContext.Object;
            var friendRequests = Friend.GetIncomingRequest("Susan.Longley@bglgroup.com");
            var result = controller.AcceptFriend(friendRequests[0].Id.ToString()) as RedirectResult;

            Assert.That(result.Url, Does.Contain("User/FriendRequest"));
        }

        [Test]
        public void DeclineFriendSuccessful()
        {
            var mockContext = new Mock<HttpContext>();
            var mockSession = new MockSession();
            mockSession.SetString("email", "JosephTimothy@email.com");
            mockContext.Setup(s => s.Session).Returns(mockSession);
            controller.ControllerContext.HttpContext = mockContext.Object;
            var friendRequests = Friend.GetIncomingRequest("Susan.Longley@bglgroup.com");
            var result = controller.DeclineFriend(friendRequests[0].Id.ToString()) as RedirectResult;

            Assert.That(result.Url, Does.Contain("User/FriendRequest"));
        }
    }    
}
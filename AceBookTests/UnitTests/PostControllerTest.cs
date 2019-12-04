using NUnit.Framework;
using AceBook.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    public class PostControllerTest
    {
        private PostController controller;

        string userId = "1";
        string message = "Hello";
        string datePosted = "adad";

        [SetUp]
        public void TestSetup()
        {
            controller = new PostController();
        }

        [Test]
        public void GetStatus()
        {
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void PostSuccesful()
        {
            var result = controller.PostStatus(
                userId,
                message) as RedirectResult;
            Assert.AreEqual("/", result.Url);
        }

        [Test]
        public void PostFailed()
        {
            var result = controller.PostStatus(
                userId,
                "") as BadRequestResult;
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}

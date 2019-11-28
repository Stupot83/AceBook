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
                message,
                datePosted) as StatusCodeResult;
            Assert.AreEqual(201, result.StatusCode);
        }

        [Test]
        public void PostFailed()
        {
            var result = controller.PostStatus(
                userId,
                "",
                datePosted) as BadRequestResult;
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}

using NUnit.Framework;
using AceBook.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    public class PostTest
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
    }
}

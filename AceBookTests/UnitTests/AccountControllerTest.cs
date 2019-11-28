using System;
using NUnit.Framework;
using AceBook.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    public class AccountConttollerTest
    {
        [Test]
        public void TestLoginView()
        {
            var controller = new AccountController();
            var result = controller.Login() as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }
    }
}

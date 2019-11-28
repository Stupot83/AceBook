using System;
using NUnit.Framework;
using AceBook.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    public class AccountConttollerTest
    {

        private AccountController controller;


        [SetUp]
        public void TestSetup()
        {
            controller = new AccountController();
        }


        [Test]
        public void GetLogin()
        {
            var result = controller.Login() as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }
    }
}

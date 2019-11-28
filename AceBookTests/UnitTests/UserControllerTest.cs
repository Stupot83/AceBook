using NUnit.Framework;
using AceBook.Controllers;
using Microsoft.AspNetCore.Mvc;

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
    }    
}
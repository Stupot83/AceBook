using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AceBookTests.FeatureTests
{
    [TestFixture]

    public class ProfileViewTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            UserRegistrationHelper.ClearUsersAndRegister();
            Login();
        }

        private void Login()
        {
            var url = "https://localhost:5001/Account/Login";
            _driver.Navigate().GoToUrl(url);

            _driver.Get("#email").SendKeys("Susan.Longley@testMail.com");
            _driver.Get("#password").SendKeys(UserRegistrationHelper.password);
            _driver.Get("#submit").Click();
            Thread.Sleep(10000);
            _driver.Get(".dropdownTrigger").Click();
            Thread.Sleep(10000);
            _driver.Get("#profile").Click();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void GoToProfilePage()
        {
            Assert.That(_driver.Url, Does.Contain("/User/Profile"));
        }

        [Test]
        public void UserFirstNameIsPopulated()
        {
            var firstNameInput = _driver.Get("#firstName");
            Assert.That(firstNameInput.GetAttribute("value"), Is.EqualTo("Susan"));
        }

        [Test]
        public void UserLastNameIsPopulated()
        {
            var lastNameInput = _driver.Get("#lastName");
            Assert.That(lastNameInput.GetAttribute("value"), Is.EqualTo("Longley"));
        }

        [Test]
        public void UserGenderIsPopulated()
        {
            var GenderInput = _driver.Get("#gender");
            Assert.That(GenderInput.GetAttribute("value"), Is.EqualTo("Frube"));
        }

        [Test]
        public void UserDateOfBirthIsPopulated()
        {
            var DobInput = _driver.Get("#birthDate");
            Assert.That(DobInput.GetAttribute("value"), Is.EqualTo("27/06/2001"));
        }

        [Test]
        public void UserEmailIsPopulated()
        {
            var EmailInput = _driver.Get("#email");
            Assert.That(EmailInput.GetAttribute("value"), Is.EqualTo("Susan.Longley@testMail.com"));
        }

        [Test]
        public void UserPhoneNumberIsPopulated()
        {
            var EmailInput = _driver.Get("#phoneNumber");
            Assert.That(EmailInput.GetAttribute("value"), Is.EqualTo(UserRegistrationHelper.phoneNumber));
        }
    }
}

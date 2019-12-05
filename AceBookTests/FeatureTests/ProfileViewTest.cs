using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            Login();
        }

        private void Login()
        {
            var url = "https://localhost:5001/Account/Login";
            _driver.Navigate().GoToUrl(url);

            _driver.Get("#email").SendKeys("83@a.com");
            _driver.Get("#password").SendKeys("c");
            _driver.Get("#submit").Click();
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
            Assert.That(firstNameInput.GetAttribute("value"), Is.EqualTo("stu"));
        }

        [Test]
        public void UserLastNameIsPopulated()
        {
            var lastNameInput = _driver.Get("#lastName");
            Assert.That(lastNameInput.GetAttribute("value"), Is.EqualTo("pot"));
        }

        [Test]
        public void UserGenderIsPopulated()
        {
            var GenderInput = _driver.Get("#gender");
            Assert.That(GenderInput.GetAttribute("value"), Is.EqualTo("non-binary"));
        }

        [Test]
        public void UserDateOfBirthIsPopulated()
        {
            var DobInput = _driver.Get("#birthDate");
            Assert.That(DobInput.GetAttribute("value"), Is.EqualTo("01/01/2001"));
        }

        [Test]
        public void UserEmailIsPopulated()
        {
            var EmailInput = _driver.Get("#email");
            Assert.That(EmailInput.GetAttribute("value"), Is.EqualTo("83@a.com"));
        }

        [Test]
        public void UserPhoneNumberIsPopulated()
        {
            var EmailInput = _driver.Get("#phoneNumber");
            Assert.That(EmailInput.GetAttribute("value"), Is.EqualTo("07777777777"));
        }
    }
}

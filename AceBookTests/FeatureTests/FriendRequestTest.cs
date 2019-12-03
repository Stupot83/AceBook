using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AceBookTests.FeatureTests
{
    [TestFixture]

    public class FriendRequestTest
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

            _driver.FindElement(By.CssSelector("#email")).SendKeys("Susan.Longley@bglgroup.co.uk");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("thelegend27");
            _driver.FindElement(By.CssSelector("#submit")).Click();
            _driver.FindElement(By.CssSelector("#friendRequests")).Click();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void GoToFriendRequestPage()
        {
            Assert.That(_driver.Url, Does.Contain("/User/FriendRequest"));
        }

        [Test]
        public void FriendRequestIsPopulated()
        {
            var firstNameInput = _driver.FindElement(By.CssSelector("#userFriendRequest"));
            Assert.That(firstNameInput.GetAttribute("value"), Is.EqualTo("stu"));
        }

        //[Test]
        //public void UserLastNameIsPopulated()
        //{
        //    var lastNameInput = _driver.FindElement(By.CssSelector("#lastName"));
        //    Assert.That(lastNameInput.GetAttribute("value"), Is.EqualTo("pot"));
        //}

        //[Test]
        //public void UserGenderIsPopulated()
        //{
        //    var GenderInput = _driver.FindElement(By.CssSelector("#gender"));
        //    Assert.That(GenderInput.GetAttribute("value"), Is.EqualTo("non-binary"));
        //}

        //[Test]
        //public void UserDateOfBirthIsPopulated()
        //{
        //    var DobInput = _driver.FindElement(By.CssSelector("#birthDate"));
        //    Assert.That(DobInput.GetAttribute("value"), Is.EqualTo("01/01/2001"));
        //}

        //[Test]
        //public void UserEmailIsPopulated()
        //{
        //    var EmailInput = _driver.FindElement(By.CssSelector("#email"));
        //    Assert.That(EmailInput.GetAttribute("value"), Is.EqualTo("83@a.com"));
        //}

        //[Test]
        //public void UserPhoneNumberIsPopulated()
        //{
        //    var EmailInput = _driver.FindElement(By.CssSelector("#phoneNumber"));
        //    Assert.That(EmailInput.GetAttribute("value"), Is.EqualTo("07777777777"));
        //}
    }
}

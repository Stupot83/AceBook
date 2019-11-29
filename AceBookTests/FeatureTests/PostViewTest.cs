using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AceBookTests.FeatureTests
{
    [TestFixture]
    public class PostViewTest
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

            _driver.FindElement(By.CssSelector("#email")).SendKeys("83@a.com");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("c");
            _driver.FindElement(By.CssSelector("#submit")).Click();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]

        public void CheckInputBox()
        {
            Assert.That(_driver.PageSource.Contains("PostInput"), Is.EqualTo(true));
        }

        [Test]
        public void CheckCanInput()
        {
            var inputBox = _driver.FindElement(By.CssSelector("#PostInput"));
            inputBox.SendKeys("this is a post");
            Assert.That(inputBox.GetAttribute("value"), Is.EqualTo("this is a post"));
        }

        [Test]
        public void CheckCanPost()
        {
            _driver.FindElement(By.CssSelector("#PostInput")).SendKeys("this is a post");
            _driver.FindElement(By.CssSelector("#PostSubmit")).Click();
            Assert.That(_driver.PageSource.Contains("this is a post"));
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Text;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace AceBookTests.FeatureTests
//{
//    [TestFixture]
//    public class PostViewTest
//    {

//        private IWebDriver _driver;

//        [SetUp]
//        public void Init()
//        {
//            _driver = new ChromeDriver();
//            Login();
//        }

//        private void Login()
//        {
//            var url = "https://localhost:5001/Account/Login";
//            _driver.Navigate().GoToUrl(url);

//            _driver.Get("#email").SendKeys("83@a.com");
//            _driver.Get("#password").SendKeys("c");
//            _driver.Get("#submit").Click();
//        }

//        [TearDown]
//        public void CleanUp()
//        {
//            _driver.Quit();
//            _driver.Dispose();
//        }

//        [Test]

//        public void CheckInputBox()
//        {
//            Assert.That(_driver.PageSource.Contains("PostInput"), Is.EqualTo(true));
//        }

//        [Test]
//        public void CheckCanInput()
//        {
//            var inputBox = _driver.Get("#PostInput");
//            inputBox.SendKeys("this is a post");
//            Assert.That(inputBox.GetAttribute("value"), Is.EqualTo("this is a post"));
//        }

//        [Test]
//        public void CheckCanPost()
//        {
//            _driver.Get("#PostInput").SendKeys("this is a post");
//            _driver.Get("#PostSubmit").Click();
//            Assert.That(_driver.PageSource.Contains("this is a post"));
//        }
//    }
//}
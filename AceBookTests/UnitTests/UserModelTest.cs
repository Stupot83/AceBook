using NUnit.Framework;
using AceBook.Models;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    class UserModelTests
    {
        User user;

        [SetUp]
        public void TestSetup()
        {
            user = new User
            {
                FirstName = "Joseph",
                LastName = "Timothy",
                Email = "JosephTimothy@email.com"
            };
        }

        [Test]
        [Category("setup")]
        public void ShouldBeAnInstanceOfUser()
        {
            Assert.That(user, Is.InstanceOf<User>());
        }

        [Test]
        public void HasFirstName()
        {
            Assert.AreEqual(user.FirstName, "Joseph");
        }

        [Test]
        public void HasLastName()
        {
            Assert.AreEqual(user.LastName, "Timothy");
        }

        [Test]
        public void HasEmail()
        {
            Assert.AreEqual(user.Email, "JosephTimothy@email.com");
        }
    }
}

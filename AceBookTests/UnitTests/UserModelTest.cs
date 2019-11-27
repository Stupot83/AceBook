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
                Email = "JosephTimothy@email.com",
                Password = "$upa$ecret",
                PhoneNumber = "1234567890",
                BirthDate = "27/06/2001",
                Gender = "Frube"
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

        [Test]
        public void HasPassword()
        {
            Assert.AreEqual(user.Password, "$upa$ecret");
        }

        [Test]
        public void HasPhoneNumber() 
        {
            Assert.AreEqual(user.PhoneNumber, "1234567890");
        }

        [Test]
        public void HasBirthDate()
        {
            Assert.AreEqual(user.BirthDate, "27/06/2001");
        }

        [Test]
        public void HasGender()
        {
            Assert.AreEqual(user.Gender, "Frube");
        }
    }
}

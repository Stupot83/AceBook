using NUnit.Framework;
using AceBook.Models;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    class UserModelTests
    {
        User user;

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
            user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                BirthDate = birthDate,
                Gender = gender
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
            Assert.AreEqual(user.FirstName, firstName);
        }

        [Test]
        public void HasLastName()
        {
            Assert.AreEqual(user.LastName, lastName);
        }

        [Test]
        public void HasEmail()
        {
            Assert.AreEqual(user.Email, email);
        }

        [Test]
        public void HasPassword()
        {
            Assert.AreEqual(user.Password, password);
        }

        [Test]
        public void HasPhoneNumber()
        {
            Assert.AreEqual(user.PhoneNumber, phoneNumber);
        }

        [Test]
        public void HasBirthDate()
        {
            Assert.AreEqual(user.BirthDate, birthDate);
        }

        [Test]
        public void HasGender()
        {
            Assert.AreEqual(user.Gender, gender);
        }

        [Test]
        [Category("registration")]
        public void RegistersAUser()
        {
            User newUser = User.Register(firstName, lastName, email, password, confirmPassword, phoneNumber, birthDate, gender);
            Assert.That(newUser, Is.InstanceOf<User>());
        }
    }
}

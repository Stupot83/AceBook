using NUnit.Framework;
using AceBook.Models;
using System;
using MongoDB.Bson;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    class UserModelTests
    {
        User user;

        string Id = "5de50e985606090f02e1e461";
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
        public void HasId()
        {
            Assert.IsNotNull(Id);
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

        [Test]
        [Category("Get user by id")]
        public void GetsAUserById()
        {
            User newUser = User.GetUserById(Id);
            Assert.That(newUser, Is.InstanceOf<User>());
        }

        [Test]
        [Category("Get user by email")]
        public void GetsAUserByEmail()
        {
            User newUser = User.GetUserByEmail(email);
            Assert.That(newUser, Is.InstanceOf<User>());
        }

        [Test]
        [Category("Get all users")]
        public void GetsAllUsers()
        {
            var users = User.GetAll();
            Assert.That(users, Is.TypeOf<System.Collections.Generic.List<User>>());
        }

        [Test]
        [Category("Get auto complete data")]
        public void GetsAutoCompleteData()
        {
            var data = User.GetAutoCompleteData();
            Assert.IsNotNull(data);
        }

        [Test]
        [Category("Authenticate user")]
        public void AuthenticateUser()
        {
            User newUser = User.AuthenticateAndGet(email, password);
            Assert.That(newUser, Is.InstanceOf<User>());
        }

        [Test]
        public void PasswordsDoNotMatch()
        {
            string notConfirmPassword = "jdsdfakdsksdaj;dsafj;";
            Assert.That(() => {
                User.Register(firstName, lastName, email, password, notConfirmPassword, phoneNumber, birthDate, gender); }, 
                Throws.TypeOf<Exception>());
        }
    }
}


//breaking speed limits of testing
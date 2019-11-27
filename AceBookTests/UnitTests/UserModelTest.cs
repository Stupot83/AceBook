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
            user = new User();
        }

        [Test]

        public void ShouldBeAnInstanceOfUser()
        {
            Assert.That(user, Is.InstanceOf<User>());
        }
    }
}

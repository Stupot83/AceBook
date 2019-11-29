/*using NUnit.Framework;
using MongoDB.Bson;
using MongoDB.Driver;
using AceBook.Models;
using System;
using AceBook.Helpers;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    class DatabaseTest
    {
        [Test]
        public void GetUserSuccess()
        {
            DbHelper.RegisterUser("stu", "pot", "83@a.com", "c", "07777777777", "01/01/2001", "non-binary");
            bool result = DbHelper.GetUser("83@a.com", "c");
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetUserUnsuccessful()
        {
            DbHelper.RegisterUser("stu", "pot", "83@a.com", "c", "07777777777", "01/01/2001", "non-binary");
            bool result = DbHelper.GetUser("99@a.com", "b");
            Assert.That(result, Is.False);
        }
    }
}
*/
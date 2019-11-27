﻿using NUnit.Framework;
using AceBook.Models;

namespace AceBookTests.UnitTests
{
    [TestFixture]
    class PostModelTest
    {
        Post post;

        string userId = "Joe123";
        string message = "Hello World";
        string datePosted = "12/12/2012";

        [SetUp]
        public void TestSetup()
        {
            post = new Post
            {
                UserId = userId,
                Message = message,
                DatePosted = datePosted
            };
        }
          
        [Test]
        [Category("setup")]
        public void ShouldBeAnInstanceOfPost()
        {
            Assert.That(post, Is.InstanceOf<Post>());
        }

        [Test]
        public void HasUserId()
        {
            Assert.AreEqual(post.UserId, userId);
        }
    }

}
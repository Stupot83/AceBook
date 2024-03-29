﻿using System;
using System.Collections.Generic;
using AceBook.Helpers;
using MongoDB.Bson;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AceBook.Models
{
    public class User
    {
        public BsonObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        
        public static User Register(string firstName, string lastName, string email, string password, string confirmPassword, string phoneNumber, string birthDate, string gender, string image)
        { 
            if (CheckPassword(password, confirmPassword))
            {
                EmailHelper.SendEmail(email);
                DbHelper.RegisterUser(firstName, lastName, email, password, phoneNumber, birthDate, gender, image);
                return new User
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
            throw new Exception("Password do not match");
        }

        public static User AuthenticateAndGet(string email, string password)
        {
            var data = DbHelper.GetUserByEmail(email);
            var storedPassword = (string) data.GetValue("password");

            if (PasswordHasher.Verify(password, storedPassword))
            {
                return new User
                {
                    Id = (BsonObjectId)data.GetValue("_id"),
                    FirstName = (string) data.GetValue("firstName"),
                    LastName = (string) data.GetValue("lastName"),
                    Email = (string) data.GetValue("email"),
                    PhoneNumber = (string) data.GetValue("phoneNumber"),
                    BirthDate = (string) data.GetValue("birthDate"),
                    Gender = (string) data.GetValue("gender"),
                    Image = (string) data.GetValue("image")
                };
            }
            
            throw new Exception("Could not authenticate user");
        }

        public static List<User> GetAll()
        {
            var data = DbHelper.GetUserByName();
            var users = new List<User> { };
            foreach (BsonDocument user in data)
            {
                users.Add(new User
                {
                    FirstName = user.GetValue("firstName").ToString(),
                    LastName = user.GetValue("lastName").ToString(),
                    Image = user.GetValue("image").ToString(),
                    Id = (BsonObjectId) user.GetValue("_id")
                });

            }
            return users;
        }

        public static string GetAutoCompleteData()
        {
            var users = GetAll();

            var data = new Dictionary<string, string> { };
            foreach (User user in users)
            {
                data[user.Id.ToString()] = $"{user.FirstName} {user.LastName}";
            }

            return JsonSerializer.Serialize(data);
        }

        public static User GetUserByEmail(string email)
        {
            var data = DbHelper.GetUserByEmail(email);

            return new User
            {
                Id = (BsonObjectId)data.GetValue("_id"),
                FirstName = (string)data.GetValue("firstName"),
                LastName = (string)data.GetValue("lastName"),
                Email = (string)data.GetValue("email"),
                PhoneNumber = (string)data.GetValue("phoneNumber"),
                BirthDate = (string)data.GetValue("birthDate"),
                Gender = (string)data.GetValue("gender"),
                Image = (string)data.GetValue("image")
            };            
        }

        public static User GetUserById(string userId)
        {
            var data = DbHelper.GetUserById(userId);

            return new User
            {
                FirstName = (string)data.GetValue("firstName"),
                LastName = (string)data.GetValue("lastName"),
                Email = (string)data.GetValue("email"),
                PhoneNumber = (string)data.GetValue("phoneNumber"),
                BirthDate = (string)data.GetValue("birthDate"),
                Gender = (string)data.GetValue("gender"),
                Image = (string)data.GetValue("image")
            };
        }

        private static bool CheckPassword(string password, string confirmPassword)
        { return (password == confirmPassword); }
    }
}

using System;
namespace AceBook.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        
        public static User Register(string firstName, string lastName, string email, string password, string confirmPassword, string phoneNumber, string birthDate, string gender)
        { 
            if (CheckPassword(password, confirmPassword))
            {
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
            throw new System.Exception("Password do not match");
        }

        private static bool CheckPassword(string password, string confirmPassword)
        { return (password == confirmPassword); }
    }
}

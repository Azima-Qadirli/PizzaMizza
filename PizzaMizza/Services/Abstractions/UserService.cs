using PizzaMizza.Models;
using PizzaMizza.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaMizza.Services.Abstractions
{
    public class UserService:IUserService
    {
        private List<User> users = new List<User>();

        public string? Signup()
        {
            Console.WriteLine("Enter a username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a password:");
            string password = Console.ReadLine();

            var passwordCheck = IsCorrectPassword(password);
            if (passwordCheck != null)
            {
                return passwordCheck;
            }

            if (users.Any(u => u.Name == username))
            {
                return "Username already exists. Please choose a different username.";
            }

            User user = new User(Guid.NewGuid(), username, password);
            users.Add(user);
            return null;
        }

        public bool Login()
        {
            Console.WriteLine("Dear user, please enter your username:");
            string? username = Console.ReadLine();
            Console.WriteLine("Now, enter your password:");
            string? password = Console.ReadLine();

            var user = users.FirstOrDefault(u => u.Name == username);
            return user != null && user.Password == password;
        }

        private string? IsCorrectPassword(string password)
        {
            if (password.Length < 6)
            {
                return "Password must be at least 6 characters long.";
            }
            bool uppercase = password.Any(char.IsUpper);
            int digitCount = password.Count(char.IsDigit);
            if (!uppercase)
            {
                return "Password must contain at least one uppercase letter.";
            }
            if (digitCount < 3)
            {
                return "Password must contain at least three digits.";
            }
            return null; 
        }
       

    }
}

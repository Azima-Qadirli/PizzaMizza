using PizzaMizza.Models;
using PizzaMizza.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Services.Interfaces
{
    public interface IUserService:IService<User>
    {
         public void AuthenticationUser();
         public string Signup(User user);
        public bool Login(string username, string password);
        public  string IsCorrectPassword(string password);

    }
}

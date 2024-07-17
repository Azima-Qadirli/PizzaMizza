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
    public interface IUserService : IService<User>
    {
        string Signup();
        bool Login();
    }
}

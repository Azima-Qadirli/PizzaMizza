using PizzaMizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Services.Interfaces
{
    public interface IService<T>where T:Entity
    {
         //void SignUp();
         //void Login();

         List<T> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Models
{
    public class User:Entity
    {
        public string Password { get; set; }
        public User(Guid id,string name,string password):base(id,name)
        {
            Password = password;
        }
    }
}

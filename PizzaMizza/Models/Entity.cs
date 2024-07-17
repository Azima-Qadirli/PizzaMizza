using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Models
{
    public class Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Entity(Guid id,string name)
        {
            Name = name;
            Id = id;
        }
    }
}

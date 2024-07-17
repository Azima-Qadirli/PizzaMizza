using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Models
{
    public class Pizza:Entity
    {
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public List<string>Ingredients { get; set; }
        public Pizza(string name,Guid id):base(id,name)
        {
            
        }
    }
    public enum Size 
    {
        Small,
        Medium,
        Large
    }


}

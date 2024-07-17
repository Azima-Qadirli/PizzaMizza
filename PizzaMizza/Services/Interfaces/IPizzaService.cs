using PizzaMizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Services.Interfaces
{
    public interface IPizzaService:IService<Pizza>
    {
        public Pizza GetPizzaById(Guid id);
        public void Create(Pizza pizza);

    }
}

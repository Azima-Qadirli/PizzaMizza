using PizzaMizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Services.Interfaces
{
    public interface IPizzaService : IService<Pizza>
    {
        void Create(Pizza pizza);
        Pizza GetPizzaById(Guid id);
        List<Pizza> GetAll();
        void Update(Guid id, Pizza pizza);
        void Delete(Guid id);
    }
}

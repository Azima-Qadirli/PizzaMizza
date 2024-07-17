using PizzaMizza.Models;
using PizzaMizza.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Services.Abstractions
{
    public class PizzaService:IPizzaService
    {
        private List<Pizza> pizzas = new List<Pizza>();

        public void Create(Pizza pizza)
        {
            pizzas.Add(pizza);
        }
        public List<Pizza> GetAllPizzas()
        {
            return pizzas;
        }
        public Pizza GetPizzaById(Guid id)
        {
            return pizzas.FirstOrDefault(p => p.Id == id);
        }
         
        List<Pizza> IService<Pizza>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

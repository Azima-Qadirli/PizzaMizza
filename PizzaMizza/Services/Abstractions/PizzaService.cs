using PizzaMizza.Exceptions;
using PizzaMizza.Models;
using PizzaMizza.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Services.Abstractions
{
    public class PizzaService : IPizzaService
    {
        private readonly List<Pizza> _pizzas = new List<Pizza>();

        public void Create(Pizza pizza)
            =>_pizzas.Add(pizza);

        public void Delete(Guid id)
        {
            Pizza pizza = GetPizzaById(id);
            _pizzas.Remove(pizza);
        }

        public List<Pizza> GetAll()
            => _pizzas;

        public Pizza GetPizzaById(Guid id)
        {
            foreach (Pizza pizza in _pizzas)
                if (pizza.Id == id)
                    return pizza;


            throw new EntityNotFoundException("Pizza is not found");
        }

        public void Update(Guid id, Pizza pizza)
        {
            Pizza updatedPizza = GetPizzaById(id);

            updatedPizza.Size = pizza.Size;
            updatedPizza.Price = pizza.Price;
            updatedPizza.Name = pizza.Name;
            updatedPizza.Ingredients = pizza.Ingredients;   
        }
    }
}

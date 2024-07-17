using PizzaMizza.Models;
using PizzaMizza.Services.Abstractions;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        PizzaService pizzaService = new PizzaService();
        UserService userService = new UserService();

        Console.WriteLine("Welcome to PizzaMizza!");

        if (AuthenticateUser(userService))
        {
            MainMenu(pizzaService);
        }
    }

    public static bool AuthenticateUser(UserService userService)
    {
        while (true)
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup");
            Console.WriteLine("0. Exit");
            Console.Write("Please, select your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (userService.Login())
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, but this account doesn't exist,please first create an account.");
                    }
                    break;
                case "2":
                    string signupResult = userService.Signup();
                    if (signupResult == null)
                    {
                        Console.WriteLine("Congrats, signup was successful. You can now access the main menu.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Signup failed: {signupResult}");
                    }
                    break;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Incorrect choice. Please try again.");
                    break;
            }
        }
    }

    static void MainMenu(PizzaService pizzaService)
    {
        while (true)
        {
            Console.WriteLine("1. Show all pizzas");
            Console.WriteLine("2. Create a new pizza");
            Console.WriteLine("0. Exit");
            Console.Write("Please, select your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllPizzas(pizzaService);
                    break;
                case "2":
                    CreateNewPizza(pizzaService);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Incorrect choice. Please try again.");
                    break;
            }
        }
    }

    static void ShowAllPizzas(PizzaService pizzaService)
    {
        var pizzas = pizzaService.GetAllPizzas();

        foreach (var pizza in pizzas)
        {
            Console.WriteLine($"Id: {pizza.Id}, Name: {pizza.Name}, Price: {pizza.Price}");
        }

        Console.WriteLine("If you want to get detailed information about the pizza, enter the Id of the pizza, if you don't want it, enter 0");
        string idInput = Console.ReadLine();

        if (idInput != "0")
        {
            if (Guid.TryParse(idInput, out Guid id))
            {
                var pizza = pizzaService.GetPizzaById(id);
                if (pizza != null)
                {
                    Console.WriteLine($"Name: {pizza.Name}");
                    Console.WriteLine($"Price: {pizza.Price}");
                    Console.WriteLine("Ingredients: " + string.Join(", ", pizza.Ingredients));
                    Console.WriteLine("Sizes available:");
                    Console.WriteLine("Small");
                    Console.WriteLine("Medium");
                    Console.WriteLine("Large");
                }
                else
                {
                    Console.WriteLine("Pizza not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Id format.");
            }
        }
    }

    static void CreateNewPizza(PizzaService pizzaService)
    {
        Console.WriteLine("Enter the name of the pizza:");
        string name = Console.ReadLine();

        Console.WriteLine("Choose the size of the pizza (0 for Small, 1 for Medium, 2 for Large):");
        Size size = (Size)int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the price of the pizza:");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter the ingredients of the pizza:");
        List<string> ingredients = new List<string>(Console.ReadLine().Split(','));

        Pizza pizza = new Pizza(name, Guid.NewGuid())
        {
            Size = size,
            Price = price,
            Ingredients = ingredients
        };

        pizzaService.Create(pizza);

        Console.WriteLine("Pizza created successfully.");
    }
}

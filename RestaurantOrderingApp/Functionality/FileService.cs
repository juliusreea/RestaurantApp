using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantOrderingApp.Models;
using System.IO;

namespace RestaurantOrderingApp.Functionality
{
    public class FileService
    {
        public List<Drink> ReadDrinksFromFile(string fileName)
        {
            FilePath filePath = new FilePath($"{fileName}.csv");
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath.Path).ToList();

            List<Drink> drinks = new List<Drink>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                Drink drinkData = new();
                drinkData.Name = parts[0];
                drinkData.Price = Convert.ToDecimal(parts[1]);
                drinks.Add(drinkData);
            }
            return drinks;
        }
        public List<Food> ReadFoodsFromFile(string fileName)
        {
            FilePath filePath = new FilePath($"{fileName}.csv");
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath.Path).ToList();

            List<Food> foods = new List<Food>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                Food foodData = new();
                foodData.Name = parts[0];
                foodData.Price = Convert.ToDecimal(parts[1]);
                foods.Add(foodData);
            }
            return foods;
        }
        
        public Order DrinksParse(Drink drink)
        {
            Order order = new Order();
            order.Name = ReadDrinksFromFile("Drinks")[0].Name;
            order.Price = ReadDrinksFromFile("Drinks")[0].Price;
            return order;
        }
        public Order FoodsParse(Food food)
        {
            Order order = new Order();
            order.Name = ReadFoodsFromFile("Foods")[0].Name;
            order.Price = ReadFoodsFromFile("Foods")[0].Price;
            return order;
        }
    }
}

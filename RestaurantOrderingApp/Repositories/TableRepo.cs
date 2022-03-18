using System;
using System.Collections.Generic;
using RestaurantOrderingApp.Models;
using System.IO;

namespace RestaurantOrderingApp.Repositories
{
    public class TableRepo
    {
        public List<Table> Tables { get; private set; }


        public TableRepo()
        {
            Tables = new List<Table>() {             new Table("Table [1]", true),
                                                     new Table("Table [2]", true),
                                                     new Table("Table [3]", true),
                                                     new Table("Table [4]", true),
                                                     new Table("Table [5]", true)};
        }
        public void AddDrinkToOrder(int tableSelected, Drink drink, int quantity)
        {
            Order order = new Order();
            order.Name = drink.Name;
            order.Price = drink.Price;
            order.Quantity = quantity;
            Tables[tableSelected].Orders.Add(order);
        }
        public void AddFoodToOrder(int tableSelected, Food food, int quantity)
        {
            Order order = new Order();
            order.Name = food.Name;
            order.Price = food.Price;
            order.Quantity = quantity;
            Tables[tableSelected].Orders.Add(order);
        }
        public void DisplayAll()
        {
            Tables.ForEach(t => Console.WriteLine($"{t} {t.TableInfo()}"));
        }
        public void DisplaySelected(int input)
        {
            Console.WriteLine(($"---{Tables[input]} selected---"));
        }
        public void DisplayOrder(int input)
        {
            Tables[input].Orders.ForEach(o => Console.WriteLine(o));
            decimal totalSum = Tables[input].TotalAmount();
            Console.WriteLine($"Total amount for {Tables[input]} is {totalSum} euro");
            Console.WriteLine("Press any key to return to table list");
        }
        public void ClearTable(int input)
        {
            Tables[input].Customers = 0;
            Tables[input].Orders.Clear();
        }
    }
}

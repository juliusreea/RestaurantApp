using RestaurantOrderingApp.Repositories;
using RestaurantOrderingApp.Functionality;
using RestaurantOrderingApp.Models;
using Xunit;


namespace RestaurantOrderingAppUnitTests
{
    public class OrderParseTest
    {
        [Fact]
        public void Test_If_Parsing_Drink_To_Order_Works()
        {
            FileService fileService = new FileService();
            TableRepo tableRepo = new TableRepo();
            Drink drink = new Drink();

            
            drink = fileService.ReadDrinksFromFile("Drinks")[0];
            tableRepo.AddDrinkToOrder(0, drink, 1);

            Order order = tableRepo.Tables[0].Orders[0];

            Assert.Equal(drink.Name, order.Name);
        }
        [Fact]
        public void Test_If_Parsing_Food_To_Order_Works()
        {
            FileService fileService = new FileService();
            TableRepo tableRepo = new TableRepo();
            Food food = new Food();


            food = fileService.ReadFoodsFromFile("Foods")[0];
            tableRepo.AddFoodToOrder(0, food, 1);

            Order order = tableRepo.Tables[0].Orders[0];

            Assert.Equal(food.Name, order.Name);
        }
    }
}

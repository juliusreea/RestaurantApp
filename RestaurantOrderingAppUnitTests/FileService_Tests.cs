using RestaurantOrderingApp.Functionality;
using RestaurantOrderingApp.Models;
using Xunit;

namespace RestaurantOrderingAppUnitTests
{
    public class FileService_Tests
    {
        [Fact]
        public void Test_If_FileService_Filereader_For_Drinks_Returns_Correct_Values()
        {
            FileService fileService = new FileService();
            Drink drink = new Drink();

            drink = fileService.ReadDrinksFromFile("Drinks")[1];

            Assert.Equal("Water", drink.Name);
        }
        [Fact]
        public void Test_If_FileService_Filereader_For_Foods_Returns_Correct_Values()
        {
            FileService fileService = new FileService();
            Food food = new Food();

            food = fileService.ReadFoodsFromFile("Foods")[1];

            Assert.Equal("Pizza", food.Name);
        }
    }
}

using System;
using RestaurantOrderingApp.Models;
using RestaurantOrderingApp.Repositories;
using RestaurantOrderingApp.Functionality;
using RestaurantOrderingApp.Functionality.Extensions;

namespace RestaurantOrderingApp
{
    public class MenuInterface
    {
        ConsoleInfo consoleInfo = new ConsoleInfo();
        FoodRepo foodRepo = new FoodRepo();
        DrinkRepo drinkRepo = new DrinkRepo();
        TableRepo tableRepo = new TableRepo();
        CheckCustomer checkCustomer = new CheckCustomer();
        CheckRestaurant checkRestaurant = new CheckRestaurant();
        MailingService mailingService = new MailingService();

        public void StartUp()
        {
            bool doContinue = true;
            while (doContinue)
            {
                Console.Clear();
                tableRepo.DisplayAll();
                ("Please select table or press x to exit").Printer();
                string tableSelect = Console.ReadLine().Trim().ToLower();
                if (tableSelect == "x") { Environment.Exit(0); }
                else if(!int.TryParse(tableSelect, out int tableSelected) || tableSelected < 1 || tableSelected > 5)
                {
                    consoleInfo.WrongInput();
                }
                else
                {
                    tableRepo.DisplaySelected(tableSelected-1); //displays operations of selected table
                    consoleInfo.TableInfo();

                    if (int.TryParse(Console.ReadLine(), out int tableMenuInput)) { } else { consoleInfo.WrongInput(); };
                    switch (tableMenuInput)
                    {
                        case 1:                                  //seating customers at the table 
                            while (true)
                            {
                                Console.WriteLine("enter number of customers at the table");
                                if (!int.TryParse(Console.ReadLine(), out int customersSeated)) { consoleInfo.WrongInput(); }
                                else
                                {
                                    tableRepo.Tables[tableSelected - 1].Customers = customersSeated;
                                    break;
                                }
                            }
                            break;
                        case 2:                                  //adding foods to order
                            while (true)
                            {
                                Console.Clear();
                                foodRepo.DisplayFoods();

                                ("please select food to add or n to return").Printer();
                                string foodSelect = Console.ReadLine();
                                if (foodSelect == "n") { break; }
                                else if (!int.TryParse(foodSelect, out int foodOrdered)||foodOrdered<=0||foodOrdered>foodRepo.Foods.Count)
                                {
                                    consoleInfo.WrongInput();
                                }
                                else
                                {
                                    ("please add food quantity").Printer();
                                    var qty = Console.ReadLine().Validation();
                                    tableRepo.AddFoodToOrder(tableSelected-1, foodRepo.Foods[foodOrdered-1], qty);
                                }
                            }
                            break;
                        case 3:                             //adding drink to order
                            while (true)
                            {
                                Console.Clear();
                                drinkRepo.DisplayDrinks();

                                ("please select drink to add or n to return").Printer();
                                string drinkSelect = Console.ReadLine();
                                if (drinkSelect == "n") { break; }
                                else if (!int.TryParse(drinkSelect, out int drinkOrdered) || drinkOrdered <= 0 || drinkOrdered > foodRepo.Foods.Count)
                                {
                                    consoleInfo.WrongInput();
                                }
                                else
                                {
                                    ("please add drink quantity").Printer();
                                    var qty = Console.ReadLine().Validation();
                                    tableRepo.AddDrinkToOrder(tableSelected - 1, drinkRepo.Drinks[drinkOrdered - 1], qty);
                                }
                            }
                            break;
                        case 4:                        //view selected table order list with total
                            tableRepo.DisplayOrder(tableSelected - 1);
                            Console.ReadKey();
                            break;
                        case 5:                      //write check text to file of selected table also frees table
                            checkRestaurant.PrintCheck(tableRepo.Tables[tableSelected - 1]);
                            checkCustomer.PrintCheck(tableRepo.Tables[tableSelected - 1]);
                            tableRepo.ClearTable(tableSelected - 1);
                            ("check has been printed").Printer();
                            mailingService.MailSendInquiry();
                            break;
                        case 6:                         //exit table menu
                            break;
                            
                    }
                }
            }
        }
    }
}

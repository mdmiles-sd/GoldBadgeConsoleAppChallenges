using GoldBadgeConsoleAppChallenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeUI
{
    class ProgramUI
    {
        private MenuRepo _itemRepo = new MenuRepo();
        //runs ap
        public void Run()
        {
            SeedItemList();
            Menu();
        }
        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options to manager
                Console.WriteLine("What Would You Like To Do?:\n" +
                    "1. Create New Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. All Items\n" +
                    "4. Display Menu Item\n" +
                    "5. Exit");
                // Get the user input
                string input = Console.ReadLine();
                // Evaluate the user's input
                switch (input)
                {
                    case "1":
                        //Create new item
                        CreateNewItem();
                        break;
                    case "2":
                        //Delete item
                        DeleteMenuItem();
                        break;
                    case "3":
                        //veiw all items
                        AllItems();
                        break;
                    case "4":
                        // Display Menu Item
                        DisplayItemByMealNumber();
                        break;
                    case "5":
                        // exit
                        Console.WriteLine("Have a Great Day");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // create new MenuItem
        private void CreateNewItem()
        {
            Console.Clear();
            MenuItems newItem = new MenuItems();


            //Meal Number
            Console.WriteLine("Enter the meal number for the item");
            newItem.MealNumber = int.Parse (Console.ReadLine());

            // Meal Name
            Console.WriteLine("Enter the meal name");
            newItem.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the Description of item");
            newItem.Description = Console.ReadLine();

            //list of ingredients
            Console.WriteLine("Enter the list of ingredients");
            newItem.ListOfIngredients = Console.ReadLine();

            //price
            Console.WriteLine("Price");
            newItem.Price = int.Parse (Console.ReadLine());            

            _itemRepo.AddItemToMenu(newItem);
        }

        private void DeleteMenuItem()
        {
            
            AllItems();
            //get item by menu number
            Console.WriteLine("\nEnter Menu Number:");

            int input = int.Parse (Console.ReadLine());

            //call the delete method
            bool wasDeleted = _itemRepo.RemoveItemFromList(input);

            // it he content was deleted, so 
            // otherwise state it could ot be deleted
            if (wasDeleted)
            {
                Console.WriteLine("Item successfully deleted.");
            }
            else
            {
                Console.WriteLine("Not Deleted.");
            }
        }

        private void AllItems()
        {
            Console.Clear();
            List<MenuItems> listofitems = _itemRepo.GetMenuItems();

            foreach (MenuItems items in listofitems)
            {
                Console.WriteLine($"MealNumber: {items.MealNumber}\n" +
                    $"MealName: {items.MealName}");
            }
        }

        private void DisplayItemByMealNumber()
        {
            Console.Clear();
            //Promt user to give meal number
            Console.WriteLine("Enter the Meal Number");
            // get user input
            int mealNumber = int.Parse (Console.ReadLine());

            // Find the item by that title
            MenuItems items = _itemRepo.GetItemsByMealNumber(mealNumber);

            // display content if not null
            if (items != null)
            {
                Console.WriteLine($"MealNumber: {items.MealNumber}\n" +
                    $"MealName: {items.MealName}\n" +
                    $"Description: {items.Description}\n" +
                    $"List of Ingredients: {items.ListOfIngredients}\n" +
                    $"Price: {items.Price}");
            }
            else
            {
                Console.WriteLine("No Items by Meal Number");
            }
        }

        //see method
        private void SeedItemList()
        {
            MenuItems number1 = new MenuItems(1, "Chicken and Fries", "Hot and Ready","Thighs and Wings with Lemon Pepper", 9.99m);
            MenuItems number2 = new MenuItems(2, "Hamburgers and Fries","Fresh off the Grill","Agus Beef,Pepper Jack Cheese", 9.9m);
            MenuItems number3 = new MenuItems(3, "Fish and Fries", "Fried Fish Right", "Fresh Salmon with Blacken Seasoning", 9.99m);

            _itemRepo.AddItemToMenu(number1);
            _itemRepo.AddItemToMenu(number2);
            _itemRepo.AddItemToMenu(number3);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    class ProgramUI
    {
        private MenuRepository _menuRepository = new MenuRepository();

        public void Run()
        {
            SeedData();
            Menu();
        }
        private void Menu()
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine(
                    "1. Create Menu Item\n" +
                    "2. Show All Menu Items\n" +
                    "3. Remove Menu Item\n" +
                    "4. All Done!"
                    );
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        CreateMenuItem();
                        break;
                    case 2:
                        ShowAllMenuItems();
                        break;
                    case 3:
                        RemoveMenuItem();
                        break;
                    case 4:
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Please Select items 1, 2, 3 or 4");
                        Console.ReadKey();
                        break;

                }
            }

        }
        private void CreateMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            Console.WriteLine("What is the name of this menu item?");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("What is the description for this menu item?");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("What meal number should be assigned to this menu item?");
            newItem.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the price?");
            newItem.MealPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the first ingredient?");
            newItem.IngredientList.Add(Console.ReadLine());
            _menuRepository.CreateMenuItem(newItem);

            bool additionalIngredient = true;
            while (additionalIngredient)
            {

                Console.WriteLine("Is there another ingredient? y/n");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    Console.WriteLine("What's the next ingredient?");
                    newItem.IngredientList.Add(Console.ReadLine());

                }
                else
                {
                    additionalIngredient = false;
                }
            }
            PressAnyKey();
        }

        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> listAllItems = _menuRepository.ShowAllMenuItems();

            foreach (MenuItem menuItem in listAllItems)
            {
                DisplayMenuItem(menuItem);
            }

            PressAnyKey();
        }

        private void RemoveMenuItem()
        {
            Console.Clear();
            List<MenuItem> listAllItems = _menuRepository.ShowAllMenuItems();

            int index = 1;

            foreach (MenuItem menuItem in listAllItems)
            {
                Console.WriteLine(($"{index}. {menuItem.MealName}"));
                index++;
            }
            Console.WriteLine("Which menu item number would you like to remove?");
            int targetItem = int.Parse(Console.ReadLine());

            int targetIndex = targetItem - 1;
            if (targetIndex >= 0 && targetIndex < listAllItems.Count)
            {
                MenuItem target = listAllItems[targetIndex];
                if (_menuRepository.DeleteMenuItem(target))
                {
                    Console.WriteLine($"{target.MealName} was successfully removed.");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }


        //Helper Methods and Seed Data
        private void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void DisplayMenuItem(MenuItem menuItem)
        {
            Console.WriteLine($"\n Meal Name: {menuItem.MealName}\n" +
                $"Meal Number: {menuItem.MealNumber}\n" +
                $"Meal Price: {menuItem.MealPrice} \n" +
                $"Meal Description: {menuItem.MealDescription}\n" +
                $"Ingredients:");
            menuItem.IngredientList.ForEach(Console.WriteLine);

        }

        //seed data
        private void SeedData()
        {
            MenuItem sandwich = new MenuItem(1, "Grilled Cheese", "big and cheesy", 2.56);
            MenuItem croissant = new MenuItem(2, "Croissant", "very French", 5.25);
            MenuItem quiche = new MenuItem(3, "Quiche", "also French", 2.25);
            quiche.IngredientList.Add("cheese");

            _menuRepository.CreateMenuItem(sandwich);
            _menuRepository.CreateMenuItem(croissant);
            _menuRepository.CreateMenuItem(quiche);
        }

    }
}

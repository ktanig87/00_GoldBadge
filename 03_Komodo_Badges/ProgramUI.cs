using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badges
{
    class ProgramUI
    {
        public BadgeRepository _badgeRepository = new BadgeRepository();

        public void Run()
        {
            SeedData();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine(
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +  //add or remove
                    "3. List All badges\n" +
                    "4. All Done!"
                    );
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        CreateBadge();
                        break;
                    case 2:
                        UpdateAccess();
                        break;
                    case 3:
                        GetBadges();
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

        //1. Add a badge
        private void CreateBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            Console.WriteLine("What is the Badge ID number?");
            newBadge.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("List a Door that it needs access to:");
            newBadge.AccessibleDoors.Add(Console.ReadLine());
            _badgeRepository.CreateBadge(newBadge);


            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("Any Other doors? y/n ");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    Console.WriteLine("List a door it needs access to:");
                    newBadge.AccessibleDoors.Add(Console.ReadLine());
                }
                else
                {
                    addingDoors = false;
                }
            }
            PressAnyKey();
        }

        //2. Edit a badge
        private void UpdateAccess()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number you want to update?");
            int input = int.Parse(Console.ReadLine());

            List<string> toUpdate = _badgeRepository.GetDoorsByID(input);
            if (toUpdate == null)
            {
                Console.WriteLine("Badge Not Found");
                PressAnyKey();
                return;
            }

            Badge updatedBadge = new Badge();

            Console.WriteLine($"Currently this badge has access to doors:");
            _badgeRepository.badgeDictionary[input].ForEach(Console.WriteLine);

            Console.WriteLine("What would you like to do? \n  1. Add a door. \n 2. Remove a door.");
            string selection = Console.ReadLine();


            if (selection == "1")
            {
                Console.WriteLine("List a Door that it needs access to:");
                updatedBadge.AccessibleDoors.Add(Console.ReadLine());
                _badgeRepository.CreateBadge(updatedBadge);

                bool addingDoors = true;
                while (addingDoors)
                {
                    Console.WriteLine("Any Other doors? y/n ");
                    string inputyn = Console.ReadLine();
                    if (inputyn == "y")
                    {
                        Console.WriteLine("List another door it needs access to:");
                        updatedBadge.AccessibleDoors.Add(Console.ReadLine());
                    }
                    else
                    {
                        addingDoors = false;
                    }
                }
            }
            else if (selection == "2")
            {
                Console.WriteLine("List a Door that should be removed");
                updatedBadge.AccessibleDoors.Remove(Console.ReadLine());

                bool removingDoors = true;
                while (removingDoors)
                {
                    Console.WriteLine("Any Other Doors y/n?");
                    string inputs = Console.ReadLine();
                    if (inputs == "y")
                    {
                        Console.WriteLine("List Another door to remove");
                        updatedBadge.AccessibleDoors.Remove(Console.ReadLine());
                    }
                    else
                    {
                        removingDoors = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("error");
            }

            PressAnyKey();
            //Badge toUpdate =

        }

        //3. List All badges
        private void GetBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> listAllBadges = _badgeRepository.GetBadges();

            foreach (KeyValuePair<int, List<string>> kvp in listAllBadges)
            {
                Console.WriteLine($"{kvp.Key}");
                _badgeRepository.badgeDictionary[kvp.Key].ForEach(Console.WriteLine);
            }

            PressAnyKey();

        }



        //Helper Methods & Seed Data
        private void PressAnyKey()
        {
            Console.WriteLine("press key to continue");
            Console.ReadKey();
        }
        private void SeedData()
        {
            Badge badgeOne = new Badge(1);
            Badge badgeTwo = new Badge(2);
            badgeTwo.AccessibleDoors.Add("A1");
            badgeTwo.AccessibleDoors.Add("A2");
            badgeOne.AccessibleDoors.Add("B1");
            badgeOne.AccessibleDoors.Add("B2");
            _badgeRepository.CreateBadge(badgeTwo);
            _badgeRepository.CreateBadge(badgeOne);




        }
    }
}

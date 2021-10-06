using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings
{
    class ProgramUI
    {
        private OutingRepository _repo = new OutingRepository();

        public void Run()
        {
            SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number you want:\n" +
                    "1. See all Outings.\n" +
                    "2. Add outing to List\n" +
                    "3. See Costs.\n" +
                    "4. TTFN.\n"
                    );
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        CalculateCosts();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Pick a Number,  1 through 4\n" + "Press any key to continue");
                        Console.ReadKey();
                        break;
                }

            }
        }
        //Display List of all outings
        private void GetOutings()
        {
            Console.Clear();
            List<Outing> outingList = _repo.GetOutings();
            foreach(Outing outing in outingList)
            {
                DisplayDetails(outing);
            }

            PressAnyKey();

        }
        

        //Add new outing to list 
        private void AddOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            Console.WriteLine("How Many Attendees?");
            newOuting.NumberAttendees = int.Parse(Console.ReadLine());

            Console.WriteLine("When is the event?");
            newOuting.EventDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("What is the cost per attendee?");
            newOuting.PerPersonCost = decimal.Parse(Console.ReadLine());

            Console.WriteLine("What type of event is this?");
            Console.WriteLine("1.Golf \n 2.Bowling \n 3.Amusement Park \n 4.Concert \n ");
            int inputEventType = int.Parse(Console.ReadLine());
            newOuting.EventType = (EventType)inputEventType;
            
            _repo.AddOuting(newOuting);
           
            PressAnyKey();
        }
        //Calculate costs x2
        private void CalculateCosts()
        {
            Console.Clear();
            Console.WriteLine("Which would you like to see? \n 1. Combined Costs for all outings \n \n or\n \n 2. Outing Costs by type? \n\n");
            string input = Console.ReadLine();
            if( input == "1")
            { 
                decimal cost = _repo.CombinedCosts();
                Console.WriteLine($"The Combined Cost for all outings is ${cost}");
            }
            else if (input =="2")
            {
                Console.Clear();
                Console.WriteLine("What type of event do you the cost for?");
                Console.WriteLine(" 1.Golf \n 2.Bowling \n 3.Amusement Park \n 4.Concert \n ");
                int inputEventType = int.Parse(Console.ReadLine());
                Outing outing = new Outing();
              
                switch(inputEventType)
                {
                    case 1:
                        outing.EventType = EventType.Golf;
                        Console.WriteLine(_repo.CostByOutingType(outing));
                        break;
                    case 2:
                        outing.EventType = EventType.Bowling;
                        Console.WriteLine(_repo.CostByOutingType(outing));
                        break;
                    case 3:
                        outing.EventType = EventType.AmusementPark;
                        Console.WriteLine(_repo.CostByOutingType(outing));
                        break;
                    case 4:
                        outing.EventType = EventType.Concert;
                        Console.WriteLine(_repo.CostByOutingType(outing)); 
                        break;
                    default:
                        Console.WriteLine("Should've picked a number.");
                        Console.ReadKey();
                        break;
                }
                              
            }
            else
            {
                Console.WriteLine("Pick 1 or 2.  Don't be crazy. ");
            }

            
            

            PressAnyKey();
        }
        //Helper and Seed Methods
        private void PressAnyKey()
        {
            Console.WriteLine("press key to continue");
            Console.ReadKey();
        }

        private void DisplayDetails(Outing outing)
        {
            Console.WriteLine($"Event Type: {outing.EventType}\n" +
                $"Number of Attendees: {outing.NumberAttendees}\n" +
                $"Date of Event: {outing.EventDate}\n" +
                $"Per Person Cost: {outing.PerPersonCost}\n" +
                $"Total Event Cost: {outing.TotalEventCost}\n \n" );

        }

        private void SeedData()
        {
            Outing outing1 = new Outing(42, new DateTime(2012, 12, 12), 52.22m, EventType.Golf);
            Outing outing2 = new Outing(53, new DateTime(2011, 11, 11), 12.50m, EventType.Concert);
            Outing outing3 = new Outing(64, new DateTime(2021, 10, 10), 62.33m, EventType.AmusementPark);
            _repo.AddOuting(outing1);
            _repo.AddOuting(outing2);
            _repo.AddOuting(outing3);
        }
    }
}

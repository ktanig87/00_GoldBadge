using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims
{
    class ProgramUI
    {
        private Claims_Repository _repo = new Claims_Repository();

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
                    "1. See all claims.\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter New Claim.\n" +
                    "4. Abandon Ship.\n"
                    );
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetClaims();
                        break;
                    case "2":
                        GetNextClaim();
                        break;
                    case "3":
                        CreateClaim();
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

        private void GetClaims()
        {
            Console.Clear();
            Queue<Claim_POCO> listAllClaims = _repo.GetAllClaims();
            Console.WriteLine("Claim ID  Claim Type  Claim Amount        Claim Date      Incident Date       Valid       Description \n");

            foreach (Claim_POCO claim in listAllClaims)
            {
                DisplayClaim(claim);
            }
            PressAnyKey();
        }

        private void GetNextClaim()
        {
            Console.Clear();
            Claim_POCO listNextClaim = _repo.GetNextClaim();
            Console.WriteLine("Here are the details for the next claim to be handeled.");
            Console.WriteLine("Claim ID  Claim Type  Claim Amount        Claim Date      Incident Date       Valid       Description \n");
            DisplayClaim(listNextClaim);



            Console.WriteLine("Do you want to deal with this claim now? y/n");
            string input = Console.ReadLine();

            if (input == "y")
            {
                _repo._ClaimsList.Dequeue();
            }
            else if (input == "n")
            {
                Console.WriteLine("\n No?! You procrastinate with the best of them!  Hats off to you.\n");
                PressAnyKey();
            }
            else
            {
                Console.WriteLine("error");
                PressAnyKey();
            }


        }


        private void CreateClaim()
        {
            Console.Clear();
            Claim_POCO newClaim = new Claim_POCO();

            Console.WriteLine("Please enter Claim ID");
            newClaim.ClaimID = Console.ReadLine();

            Console.WriteLine("What is the type of claim- \n" +
                "1. Car   \n" +
                "2. Home \n" +
                "3. Theft ");

            string selectClaimType = Console.ReadLine();
            bool selectType = false;
            while (selectType == false)
                switch (selectClaimType)
                {
                    case "1":
                        newClaim.ClaimType = "Car";
                        selectType = true;
                        break;
                    case "2":
                        newClaim.ClaimType = "Home";
                        selectType = true;
                        break;
                    case "3":
                        newClaim.ClaimType = "Theft";
                        selectType = true;
                        break;
                    default:
                        newClaim.ClaimType = "Please Try again.";
                        selectType = true;
                        Console.WriteLine("Need to select 1, 2, or 3");
                        break;

                }


            Console.WriteLine("Please enter the claim Date ");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the incident date ");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter claim amount");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a claim description:");
            newClaim.Description = Console.ReadLine();

            _repo.CreateClaim(newClaim);
        }

        
        //SeedData& Helpers

        private void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void DisplayClaim(Claim_POCO claim)
        {
            Console.WriteLine(
                $"{claim.ClaimID} " + $"{claim.ClaimType} " + $"${claim.ClaimAmount}     " + $"{claim.DateOfClaim}    " + $"{claim.DateOfIncident}" + $" {claim.IsValid}" + $" {claim.Description}\n");
        }

        private void SeedData()
        {
            Claim_POCO firstClaim = new Claim_POCO("kt1", "car", 1500.02m, new DateTime(2020 / 12 / 12), new DateTime(2020, 12, 25), "bad car, bad driver");
            Claim_POCO secondClaim = new Claim_POCO("kt2", "home", 15000000.3m, new DateTime(2012, 12, 12), new DateTime(2012, 12, 15), "dang hurricanes");

            _repo.CreateClaim(firstClaim);
            _repo.CreateClaim(secondClaim);
        }
    }
}

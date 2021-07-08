using System;
using KomodoClaimsDepartmentRepo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartmentConsoleApp
{
    class ProgramUI
    {
        private ClaimsReop _contentRepo = new ClaimsReop();
       
        //runs 
        public void Go()
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
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");
                    
                // Get the user input
                string input = Console.ReadLine();
                // Evaluate the user's input
                switch (input)
                {
                    case "1":
                        //veiw all items
                        DisplayAllClaims();                       
                        break;
                    case "2":
                        DisplayNextClaim();
                        // Take Care of next claim
                        break;
                    case "3":
                        //Enter a new Claim
                        CreateNewClaim();
                        break;                    
                    case "4":
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

        // create new Claim
        private void CreateNewClaim()
        {
            Console.Clear();

            ClaimContent newClaim = new ClaimContent();  

            //ClaimID
            Console.WriteLine("Enter Claim ID");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            // Description
            Console.WriteLine("Enter Desciption");
            newClaim.Description = Console.ReadLine();

            //Amount
            Console.WriteLine("Enter Amount of Claim");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            //Date of accident
            Console.WriteLine("Enter Date Of Accident");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //date of claim
            Console.WriteLine("Date Of Claim");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //Is Valid
            Console.WriteLine("Is Claim Valid? (y/n)");
            newClaim.IsVaild = bool.Parse(Console.ReadLine());

            _contentRepo.AddContentToList(newClaim);
        }

        private void DisplayAllClaims()
        {
            Console.Clear();
            List<ClaimContent> listofContent = _contentRepo.GetClaimContents();

            foreach (ClaimContent content in listofContent)
            {
                Console.WriteLine($"ClaimID: {content.ClaimID}\n" +
                    $"MealName: {content.TypeOfClaim}");
            }
           
        }

        public void DisplayNextClaim()
        {
            Console.Clear();

            //defining a queue
            Queue<ClaimContent> claimQueue = new Queue<ClaimContent>();            
            {
              
            }

        }




        
        

     

        //see method
        public void SeedItemList()
        {
            ClaimContent number1 = new ClaimContent(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018,04,25), new DateTime(2018,04,27), true);
            ClaimContent number2 = new ClaimContent(2, ClaimType.Home, "Hous fire in kitchen", 4000.00m, new DateTime(2018,04,11), new DateTime(2018,04,12), true);
            ClaimContent number3 = new ClaimContent(3, ClaimType.Theft, "Stolen pancakes", 4.00m, new DateTime(2018,04,27), new DateTime(2018,06,01), false);

            _contentRepo.AddContentToList(number1);
            _contentRepo.AddContentToList(number2);
            _contentRepo.AddContentToList(number3);
        }
    }
}


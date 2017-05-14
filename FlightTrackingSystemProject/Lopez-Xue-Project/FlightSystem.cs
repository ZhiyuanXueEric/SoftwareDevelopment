//Kassandra Lopez & Zhiyuan Xue Project
//Demo to American Airlines
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomelandSecurity;

namespace Lopez_Xue_Project
{ 
    class FlightSystem
    {
        Flight[] flightList;//create flightList array
        int menuScreenSelection;
        int flightCount;
        int passengerCount;
        int subMenuSelection;
        int flightSelection;

        static void Main(string[] args)
        {
            FlightSystem flightProgram = new FlightSystem();
            flightProgram.LoadTempData();
            flightProgram.DisplayMenuHeader();
            flightProgram.MenuScreenSelection();

            Console.ReadLine();
        }

        // Method outer class
        public void LoadTempData()
        {
            flightList = new Flight [20];

            //Create three flights and store them into the flightList array
            flightList[0] = new Flight(321, "Phoenix", "New York");
            flightCount++;//Increment flightCount
            flightList[1] = new Flight(145, "Tucson", "Washington");
            flightCount++;
            flightList[2] = new Flight(213, "Austin", "Dallas");
            flightCount++;

            //Create 5 passenger into each flight and store them into the passengerManifest array
            flightList[0].PassengerManifest[0] = new Passenger("Jason","Lee","111234");
            flightList[0].PassengerCount++;//Increment passengerCount
            flightList[0].PassengerManifest[1] = new Passenger("Jay","Hsu","212894");
            flightList[0].PassengerCount++;
            flightList[0].PassengerManifest[2] = new Passenger("Tom", "Ray","178902");
            flightList[0].PassengerCount++;
            flightList[0].PassengerManifest[3] = new Passenger("Tony","Jackson","189308");
            flightList[0].PassengerCount++;
            flightList[0].PassengerManifest[4] = new Passenger("Lisa","Jackson","100234");
            flightList[0].PassengerCount++;

            flightList[1].PassengerManifest[0] = new Passenger("Will","Barbosa","131240");
            flightList[1].PassengerCount++;
            flightList[1].PassengerManifest[1] = new Passenger("Mike","Johnson","199390");
            flightList[1].PassengerCount++;
            flightList[1].PassengerManifest[2] = new Passenger("Wang","Hong","998834");
            flightList[1].PassengerCount++;
            flightList[1].PassengerManifest[3] = new Passenger("Eric","Denis","234134");
            flightList[1].PassengerCount++;
            flightList[1].PassengerManifest[4] = new Passenger("Kelly","Denis","902134");
            flightList[1].PassengerCount++;

            flightList[2].PassengerManifest[0] = new Passenger("Joesph", "Williamson", "909123");
            flightList[2].PassengerCount++;
            flightList[2].PassengerManifest[1] = new Passenger("Peter", "Herding", "349380");
            flightList[2].PassengerCount++;
            flightList[2].PassengerManifest[2] = new Passenger("Brian", "Houston", "98832");
            flightList[2].PassengerCount++;
            flightList[2].PassengerManifest[3] = new Passenger("Ryan", "Len", "284104");
            flightList[2].PassengerCount++;
            flightList[2].PassengerManifest[4] = new Passenger("Tracy", "lena", "972134");
            flightList[2].PassengerCount++;
        }
        //Display menu header
        public void DisplayMenuHeader()
        {
            Console.WriteLine("\t\t\tAmerican Airline Flight Inventory and Tracking System\n");
            Console.WriteLine("\t\t\t\t\t--FITS--");
        }
        
        public void MenuScreenSelection()//Main menu that let the user select option
        {
            bool displayMenu = true;
            do
            {
                Console.WriteLine();
                Console.Clear();
                DisplayMenuHeader();
                Console.WriteLine("\n1.Display Flight List");
                Console.WriteLine("\n2.Add New Flight");
                Console.WriteLine("\n3.Select Flight");
                Console.WriteLine("\n4. Search by Passenger");
                Console.WriteLine("\n5. Exit");
                Console.WriteLine();

                menuScreenSelection = Utilities.ReadInteger("\nYour selection:  ");//Error message will be displayed if the user enter non-numeric value
                switch (menuScreenSelection) //Display menu selections
                {
                    case 1://Display flight information 
                        DisplayFlightInfo();
                        Console.WriteLine("\nPress Enter to Continue...");
                        Console.ReadLine();
                        break;
                    case 2://Add new flight
                        AddNewFlight();
                        Console.ReadLine();
                        break;
                    case 3://Select Flight
                        SelectFlight();
                        SubMenuSelection();//Display the Sub-Menu
                        Console.ReadLine();
                        break;
                    case 4://Search by Passenger
                        SearchPassenger();
                        Console.ReadLine();
                        break;
                    case 5://Exit the program
                        System.Environment.Exit(0);
                        break;
                }
                
            } while (displayMenu);
            
        }
        public void DisplayFlightInfo()
        {
            Console.Clear();
            DisplayMenuHeader();
            Console.WriteLine("\t\t\t\tCurrent Flights");
            for (int i = 0; i < flightCount; i++) //Loop through the flightList array
            {
              Console.WriteLine();
              Console.WriteLine(i+1 + "." +"Flight   " + flightList[i].FlightNo + "  \t" + flightList[i].FlightOrigin + "  -->  \t" + flightList[i].FlightDestination);
              Console.WriteLine();
            }
        }
        public void DisplayPassengerInfo()
        {
            string flaggedSign = "";
            Console.Clear();
            DisplayMenuHeader();
            Console.WriteLine("\t\t\t\tManifest for Flight " + flightList[flightSelection - 1].FlightNo);//Display passenger manifest header
            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4,-15}\n","Number",  "FirstName",  "LastName", "LoyaltyNumber", "Flagged");
            for (int i = 0; i < flightList[flightSelection - 1].PassengerCount; i++) //Loop through the passengerManifest array
            {
                if (flightList[flightSelection - 1].PassengerManifest[i].SecurityFlag) //Security flag check
                {
                    flaggedSign = "!!!";//Display "!!!" sign
                }
                else
                {
                    flaggedSign= "";
                }
                Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4,-15}", i + 1, flightList[flightSelection - 1].PassengerManifest[i].FirstName, flightList[flightSelection - 1].PassengerManifest[i].LastName,
                                    flightList[flightSelection - 1].PassengerManifest[i].LoyaltyNumber, flaggedSign);//Display the passenger's first name, last name and loyalty number
            }

        }
        public FlightSystem()//Constructor for the flight system
        {
            flightList = new Flight [20];
        }
        public void AddNewFlight()
        {
           Console.Clear();
           DisplayMenuHeader();
           Console.WriteLine("\n\t\t\t\tAdd a New Flight");
           Flight myFlight = new Flight(); //Create an instance of flight
           myFlight.FlightNo = Utilities.ReadInteger("\nEnter a new flight no: "); //Error message will be displayed if the user enter non-numeric value
           Console.Write("Enter a new flight origin: ");
           myFlight.FlightOrigin = Console.ReadLine();
           Console.Write("Enter a new flight destination: ");
           myFlight.FlightDestination = Console.ReadLine();
           Console.WriteLine("\nFlight added to the system...");
           Console.Write("Press Enter to continue!");
           Flight tempFlightList = new Flight(myFlight.FlightNo,myFlight.FlightOrigin,myFlight.FlightDestination);//Store user input respectively
           flightList [flightCount] = tempFlightList; //put flight into the library 
           flightCount++;
        }
        public void SelectFlight()
        {
            Console.Clear();
            DisplayMenuHeader();
            Console.WriteLine("\t\t\t\tCurrent Flights");
            DisplayFlightInfo();
            flightSelection= Utilities.ReadInteger("\nEnter your selection:  ");//error message will be displayed if an error exists
        }
        public void SearchPassenger() //Search by passenger method
        {
            string FirstName;//declare passenger first name
            string LastName;//declare passenger last name
            Console.Clear();
            DisplayMenuHeader();
            Console.WriteLine();
            Console.WriteLine("\n\t\t\t\tFind Passenger");
            Console.Write("Enter Passenger First Name: ");
            FirstName = Console.ReadLine();
            Console.Write("Enter Passenger Last Name: ");
            LastName = Console.ReadLine();
            
            for (int i = 0; i < flightList.Length; i++)
            {
                if (flightList[i] != null)
                {
                    for (int j = 0; j < flightList[i].PassengerManifest.Length; j++)
                    {
                        if (flightList[i].PassengerManifest[j] != null)
                        {
                            if (flightList[i].PassengerManifest[j].FirstName == FirstName &&
                            flightList[i].PassengerManifest[j].LastName == LastName) //Check if first name matches as well as last name
                            {
                                Console.Write("\n\nFlight" + "{1,15}" + "{2,15}" + "{3,15}", flightList[i].FlightNo, flightList[i].PassengerManifest[j].FirstName, flightList[i].PassengerManifest[j].LastName, flightList[i].PassengerManifest[j].LoyaltyNumber);
                            }
                        }
                    }//end inner for loop
                }
            }//end outer for loop
        }
                       
        public void SubMenuSelection()
        {
            bool displaySubMenu = true;
           
            do
            {
                Console.Clear();
                DisplayMenuHeader();
                Console.WriteLine("\n\t\t\tFlight Menu --- Flight "+ flightList[flightSelection - 1].FlightNo);
                Console.WriteLine("\n\t\tFlight   " + flightList[flightSelection-1].FlightNo + "  \t" + flightList[flightSelection-1].FlightOrigin + "  -->  \t" + flightList[flightSelection-1].FlightDestination);
                Console.WriteLine("\n1.Display passenger manifest");
                Console.WriteLine("\n2.Edit flight information");
                Console.WriteLine("\n3.Add new passengers to manifest");
                Console.WriteLine("\n4.Run passenger security check");
                Console.WriteLine("\n5.Exit to FITS");

                subMenuSelection = Utilities.ReadInteger("\nYour selection:  ");//Error message will be displayed if the user enter non-numeric value
                switch (subMenuSelection) //Display sub-menu selections
                {
                    case 1://Display passenger manifest
                        DisplayPassengerInfo();
                        Console.WriteLine("\nPress Enter to Continue...");
                        Console.ReadLine();
                        break;
                    case 2://Edit flight information
                        EditFlightInformation();
                        Console.WriteLine("\nPress Enter to Continue...");
                        Console.ReadLine();
                        break;
                    case 3://Add new passengers to manifest
                        AddPassenger();
                        Console.WriteLine("\nPress Enter to Continue...");
                        break;
                    case 4://Run passenger security check
                        Console.WriteLine("Security check run...");
                        SecurityCheck();
                        break;
                    case 5://Exit to FITS
                        MenuScreenSelection();
                        break;
                }
            } while (displaySubMenu);
        }
        public void AddPassenger()
        {
            Console.Clear();
            DisplayMenuHeader();
            Console.WriteLine("\t\t\t\tAdd a new passenger");
            Passenger myPassenger = new Passenger(); //Create an instance of flight
            Console.Write("\nEnter a new passenger's first name: ");
            myPassenger.FirstName = Console.ReadLine();//user input for the new passenger's first name
            Console.Write("Enter a new passenger's last name: ");
            myPassenger.LastName = Console.ReadLine();//user input for the new passenger's last name
            Console.Write("Enter a new passenger's loyalty number: ");
            myPassenger.LoyaltyNumber = Console.ReadLine();//user input for the new passenger's loyalty number
            Console.WriteLine("\nPassenger added to the system...");
            Console.Write("Press Enter to continue!");
            
            flightList[flightSelection - 1].PassengerManifest[flightList[flightSelection-1].PassengerCount] = myPassenger; //put new passenger information into the library 
            passengerCount++;//Increment passengerCount
        }
        public void EditFlightInformation()
        {
            Console.Clear();
            DisplayMenuHeader();
            Flight editedFlight= flightList[flightSelection-1];
            Console.WriteLine("\n\t\t\t Edit Flight Information --- Flight " + flightList[flightSelection - 1].FlightNo);
            Console.WriteLine("\n"+flightList[flightSelection - 1].FlightNo + "  \t" + flightList[flightSelection - 1].FlightOrigin + "  -->  \t" + flightList[flightSelection - 1].FlightDestination);
            editedFlight.FlightNo  = Utilities.ReadInteger("\nEnter New Flight Number: ");//user input for editing flight number
            Console.WriteLine("Enter New Flight Origin:");
            editedFlight.FlightOrigin = Console.ReadLine();//user input for editing flight origin
            Console.WriteLine("Enter New Flight Destination:");
            editedFlight.FlightDestination = Console.ReadLine();//user input for editing flight destination
            Console.WriteLine("\nFlight Information Added...");

            flightList[flightSelection-1] = editedFlight; //put the editedflight into the library 
        }
        public void SecurityCheck()
        {
            TSA flaggedPassenger = new TSA();
            HomelandSecurity.FlaggedPassenger[] flagged = flaggedPassenger.RunSecurityCheck(flightList[flightSelection - 1].PassengerManifest, flightList[flightSelection - 1].PassengerCount);
            int i = 0;
            int j = 0;
            for (i = 0; i < flagged.Length; i++) //look through all the passengers of the flagged array
            {
                for (j = 0; j < flightList[flightSelection -1].PassengerCount; j++)
                {
                    if (flightList[flightSelection - 1].PassengerManifest[j].FirstName == flagged[i].FirstName &&
                        flightList[flightSelection - 1].PassengerManifest[j].LastName == flagged[i].LastName &&
                        flightList[flightSelection - 1].PassengerManifest[j].LoyaltyNumber == flagged[i].LoyaltyNumber)
                    {
                        flightList[flightSelection - 1].PassengerManifest[j].SecurityFlag = true;
                    }//end if
                }//end inter for loop
            }//End outer for loop
            Console.ReadLine();
        }

    }
}

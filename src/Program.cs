using System;
using System.Collections.Generic;
using System.IO;

namespace PracticalWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Airport airport = new Airport();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("             Air UFV                ");
                Console.WriteLine("=====================================");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Load flights from file.");
                Console.WriteLine("2. Load a flight manually.");
                Console.WriteLine("3. Start simulation (Manual).");
                Console.WriteLine("4. Start simulation (Automatic).");
                Console.WriteLine("5. Exit.");
                Console.Write("Choose your option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        airport.LoadFlightsFromFile();
                        break;
                    case "2":
                        airport.LoadFlightManually();
                        break;
                    case "3":
                        airport.AdvanceTick();
                        airport.ShowStatus();

                        break;
                    case "4":
                        while(true)
                        {
                            airport.AdvanceTick();
                            airport.ShowStatus();
                            Console.WriteLine("Press any Key to continue the simulation");
                            Console.ReadKey();
                        }

                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option, press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    
    

}
}
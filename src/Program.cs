using System;
using System.Collections.Generic;
using System.IO;

namespace PracticalWork1
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
                        airport.StartSimulation(manual: true);
                        break;
                    case "4":
                        airport.StartSimulation(manual: false);
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
    public void LoadFlightsFromFile()
    {
        Console.Write("Enter the filename to load flights from: ");
        string filename = Console.ReadLine();

        try
        {
            List<Aircraft> tempAircraftList = new List<Aircraft>();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length != 5)
                    {
                        throw new FormatException("Incorrect file format.");
                    }

                    string id = parts[0];  
                    string type = parts[1];  
                    double speed = double.Parse(parts[2]); 
                    double fuel = double.Parse(parts[3]);  
                    double distance = double.Parse(parts[4]); 

                    Aircraft aircraft = new Aircraft(id, type, speed, fuel, distance);
                    tempAircraftList.Add(aircraft);
                }
            }

            AircraftList.AddRange(tempAircraftList);
            Console.WriteLine("Flights loaded successfully!");
        }
        catch (IOException)
        {
            Console.WriteLine("Error: File does not exist or cannot be read.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

}
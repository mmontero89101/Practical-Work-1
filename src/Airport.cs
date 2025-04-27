using System;
using System.Collections.Generic;

namespace PracticalWork
{
    public class Airport
    {
        public List<Runway> Runways {get;set;}= new List<Runway> ();
        public List<Aircraft> Aircrafts {get;set;} = new List<Aircraft>();

        public void AddAircraft(Aircraft aircraft) => Aircrafts.Add(aircraft);

        public void ShowStatus()
        {
            Console.WriteLine("Runway Status: ");

            foreach(var runway in Runways)
            {
                Console.WriteLine($"{runway.ID}: {runway.Status} {(runway.CurrentAircraft != null ? $"-{runway.CurrentAircraft.ID}-{runway.TicksAvailability} ticks left" : "")}");
            }

            Console.WriteLine("\n Aircraft Status: ");
            foreach(var aircraft in Aircrafts)
            {

                Console.WriteLine($"{aircraft.ID}: {aircraft.Status} - Distance: {aircraft.Distance} Km - Fuel: {aircraft.CurrentFuel} L");

            }
        }

        

        public void AdvanceTick()
        {

            Console.WriteLine("\nAdvancing Simulation: ");

            foreach(var aircraft in Aircrafts)
            {
            switch(aircraft.Status)
            {
                case Aircraft.AircraftStatus.InFlight:
                    if (aircraft.Distance > 0)
                    {
                        double distanceTravelled = aircraft.Speed / 4.0; 
                        aircraft.Distance = (int)Math.Max(0.0, (double)aircraft.Distance - distanceTravelled);
                        aircraft.CurrentFuel -= distanceTravelled * aircraft.FuelConsumption;

                        if (aircraft.Distance == 0)
                        {
                            aircraft.Status = Aircraft.AircraftStatus.Waiting;
                        }
                    }
                    break;

                case Aircraft.AircraftStatus.Waiting:
                    var freeRunway = Runways.Find(r => r.Status == Runway.RunwayStatus.Free);
                    if (freeRunway != null)
                    {
                        freeRunway.RequestRunway(aircraft);
                        aircraft.Status = Aircraft.AircraftStatus.Landing;
                    }
                    break;

                case Aircraft.AircraftStatus.Landing:
                    
                    break;

                case Aircraft.AircraftStatus.OnGround:
                    
                    break;
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

                    Aircraft aircraft = null;
                    if(type.Equals("Commercial", StringComparison.OrdinalIgnoreCase))
                    {
                        aircraft = new CommercialAircraft(id, (int)speed, fuel, 0.1, (int)distance, 150);
                    }
                    else if(type.Equals("Private", StringComparison.OrdinalIgnoreCase))
                    {
                        aircraft = new PrivateAircraft(id, (int)speed, fuel, 0.2, (int)distance, "Moises Martinez (GOAT)");
                    }
                    else if(type.Equals("Cargo", StringComparison.OrdinalIgnoreCase))
                    {
                        aircraft = new CargoAircraft(id, (int)speed, fuel, 0.15, (int)distance, 150);
                    }



                    

                    if (aircraft != null)
                    {
                        tempAircraftList.Add(aircraft);
                    }
                    
                    
                }
            }

            Aircrafts.AddRange(tempAircraftList);
            Console.WriteLine("Flights loaded successfully!");
        }
        catch (IOException)
        {
            Console.WriteLine("Error: File does not exist .");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        Console.WriteLine("Press any key to return to  menu");
        Console.ReadKey();
    }

    public void LoadFlightManually()
    {
        Console.WriteLine("Enter the type of aircraft you want: ");
        Console.WriteLine("1. Commercial Aircraft");
        Console.WriteLine("2. Private Aircraft");
        Console.WriteLine("3. Cargo Aircraft");
        Console.Write("Enter your option: ");
        
        string type = Console.ReadLine();
        Console.Write("Enter an Aircraft ID: ");
        string id = Console.ReadLine();
        Console.Write("Enter the Speed: ");
        int speed = int.Parse(Console.ReadLine());
        Console.Write("Enter the fuel capacity: ");
        double fuelCapacity= double.Parse(Console.ReadLine());
        Console.Write("Enter the fuel consumption: ");
        double fuelConsumption = double.Parse(Console.ReadLine());
        Console.Write("Enter the Distance: ");
        int distance = int.Parse(Console.ReadLine());

        Aircraft aircraft = null;

        switch (type)
        {
            case "1":
                Console.Write("Enter Number of Passengers: ");
                int numberOfPassengers = int.Parse(Console.ReadLine());
                aircraft = new CommercialAircraft(id, speed, fuelCapacity, fuelConsumption, distance, numberOfPassengers);
                break;

            case "2":
                Console.Write("Enter Owner Name: ");
                string owner = Console.ReadLine();
                aircraft = new PrivateAircraft(id, speed, fuelCapacity, fuelConsumption, distance, owner);
                break;

            case "3":
                Console.Write("Enter Maximum Load (kg): ");
                double maximumLoad = double.Parse(Console.ReadLine());
                aircraft = new CargoAircraft(id, speed, fuelCapacity, fuelConsumption, distance, maximumLoad);
                break;

            default:
                Console.WriteLine("Invalid option. Returning to menu.");
                Console.ReadKey();
                return;
       }


      
    }


        
        
    }
}
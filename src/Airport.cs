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

            Console.WriteLine("\n Advancing Simulation: ");

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


        
        
    }
}
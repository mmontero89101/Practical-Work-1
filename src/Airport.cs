using System;

namespace PracticalWork
{
    public class Airport
    {
        public List<Runway> Runways {get;set;}= new();
        public List<Aircraft> Aircrafts {get;set;} = new();

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
                case AircraftStatus.InFlight:
                    if (aircraft.Distance > 0)
                    {
                        double distanceTravelled = aircraft.Speed / 4.0; 
                        aircraft.Distance = Math.Max(0, aircraft.Distance - distanceTravelled);
                        aircraft.CurrentFuel -= distanceTravelled * aircraft.FuelConsumption;

                        if (aircraft.Distance == 0)
                        {
                            aircraft.Status = AircraftStatus.Waiting;
                        }
                    }
                    break;

                case AircraftStatus.Waiting:
                    var freeRunway = Runways.Find(r => r.Status == RunwayStatus.Free);
                    if (freeRunway != null)
                    {
                        freeRunway.RequestRunway(aircraft);
                        aircraft.Status = AircraftStatus.Landing;
                    }
                    break;

                case AircraftStatus.Landing:
                    
                    break;

                case AircraftStatus.OnGround:
                    
                    break;
            }
           }

        }


        
        
    }
}
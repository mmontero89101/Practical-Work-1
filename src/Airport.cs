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

            }
        }

        

        public void AdvanceTick()
        {

        }


        //hola.
        
    }
}
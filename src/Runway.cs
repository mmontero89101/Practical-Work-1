using System;

namespace PracticalWork
{
    public class Runway
    {
        public string ID {get; set;}
        public AircraftStatus Status {get; set;}

        public Aircraft CurrentAircraft {get; set;}

        public int TicksAvailability {get; set;} = 3;
    }
}
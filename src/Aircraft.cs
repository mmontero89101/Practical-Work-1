using System;

namespace PracticalWork
{
    public abstract class Aircraft
    {

        public enum AircraftStatus{InFlight,Waiting,Landing,OnGround}
        public string ID {get; set;}
        public AircraftStatus Status {get; set;}
        public int Distance {get; set;}
        public int Speed {get; set;}
        public double FuelCapacity {get; set;}
        public double FuelConsumption {get; set;}
        public double CurrentFuel {get; set;}

        public virtual void UpdateOfPositionAndFuel()
        {
            if(Status == AircraftStatus.InFlight)
            {
                int distanceToTravel = Speed / 4;
                int actualTravel = Math.Min(distanceToTravel, Distance);
                Distance -= actualTravel;
                CurrentFuel -= actualTravel * FuelConsumption;
                if(Distance <= 0)
                {
                    Distance = 0;
                    Status = AircraftStatus.Waiting;
                }
            }
        }
        
            
        
    }

    

    

    


    
}

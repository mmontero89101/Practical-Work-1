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

        public Aircraft(string id, int speed, double fuelCapacity, double fuelConsumption, int distance)
        {


            ID = id;
            Speed = speed;
            FuelCapacity = fuelCapacity;
            FuelConsumption = fuelConsumption;
            CurrentFuel = fuelCapacity; 
            Distance = distance;
            Status = AircraftStatus.InFlight;

        }

        

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

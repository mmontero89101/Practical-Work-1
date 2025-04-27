using System;


namespace PracticalWork
{
    public class CommercialAircraft : Aircraft
    {
        public int NumberOfPassengers { get; set; }

        public CommercialAircraft(string id, int speed, double fuelCapacity, double fuelConsumption, int distance, int numberOfPassengers) : base(id, speed, fuelCapacity, fuelConsumption, distance)
        {
            NumberOfPassengers = numberOfPassengers;
        }

        public override void UpdateOfPositionAndFuel()
        {
           base.UpdateOfPositionAndFuel();
;       }
    }
}

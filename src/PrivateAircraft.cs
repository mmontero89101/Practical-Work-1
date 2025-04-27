using System;

namespace PracticalWork
{
    public class PrivateAircraft : Aircraft
    {
        public string Owner {get; set;}

        public PrivateAircraft(string id, int speed, double fuelCapacity, double fuelConsumption, int distance, string owner) : base (id, speed, fuelCapacity, fuelConsumption, distance)
        {
            Owner = owner;
        }

        public override void UpdateOfPositionAndFuel()
        {
            base.UpdateOfPositionAndFuel();
        }
    }
}
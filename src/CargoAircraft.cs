using System;

namespace PracticalWork
{
    public class CargoAircraft : Aircraft
    {
        public double MaximumLoad {get; set;}

        public CargoAircraft(string id, int speed, double fuelCapacity, double fuelConsumption, int distance, double maximumLoad) : base(id, speed, fuelCapacity, fuelConsumption, distance)
        {
            MaximumLoad = maximumLoad;
        }





        public override void UpdateOfPositionAndFuel()
        {
            base.UpdateOfPositionAndFuel();
        }
    }
}
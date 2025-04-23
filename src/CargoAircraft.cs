using System;

namespace PracticalWork
{
    public class CargoAircraft : Aircraft
    {
        public double MaximumLoad { get; set; }

        public override void UpdateOfPositionAndFuel()
        {
            Console.WriteLine($"[Carga] ID: {ID}, Carga Máxima: {MaximumLoad}kg, Estado: {Status}");
        }
    }
}
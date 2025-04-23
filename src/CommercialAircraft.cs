using System;


namespace PracticalWork
{
    public class CommercialAircraft : Aircraft
    {
        public int NumberOfPassengers { get; set; }

        public override void UpdateOfPositionAndFuel()
        {
            Console.WriteLine($"[Comercial] ID: {ID}, Pasajeros: {NumberOfPassengers}, Estado: {Status}");
        }
    }
}

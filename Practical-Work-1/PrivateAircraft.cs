using System;

namespace PracticalWork
{
    public class PrivateAircraft : Aircraft
    {
        public string Owner { get; set; }

        public override void Infoavion()
        {
            Console.WriteLine($"[Privado] ID: {ID}, Propietario: {Owner}, Estado: {Status}");
        }
    }
}
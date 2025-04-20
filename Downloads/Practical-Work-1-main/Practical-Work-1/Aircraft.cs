using System;

namespace PracticalWork
{
    public abstract class Aircraft
    {
        public string ID { get; set; }
        public string Status { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
        public double FuelCapacity { get; set; }
        public double FuelConsumption { get; set; }
        public double CurrentFuel { get; set; }

        public abstract void Infoavion(); //Cambiar el nombre de esto, asi esta muy feo
    }

    public class CommercialAircraft : Aircraft
    {
        public int NumberOfPassengers { get; set; }

        public override void Infoavion()
        {
            Console.WriteLine($"[Comercial] ID: {ID}, Pasajeros: {NumberOfPassengers}, Estado: {Status}");
        }
    }

    public class CargoAircraft : Aircraft
    {
        public double MaximumLoad { get; set; }

        public override void Infoavion()
        {
            Console.WriteLine($"[Carga] ID: {ID}, Carga Máxima: {MaximumLoad}kg, Estado: {Status}");
        }
    }

    public class PrivateAircraft : Aircraft
    {
        public string Owner { get; set; }

        public override void Infoavion()
        {
            Console.WriteLine($"[Privado] ID: {ID}, Propietario: {Owner}, Estado: {Status}");
        }
    }


    public static class Main()
    {
        
    }
}

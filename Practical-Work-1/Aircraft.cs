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

    

    

    


    
}

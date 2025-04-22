using System;
namespace PracticalWork
{
    public class Runway
    {
        public string ID{get;set;}
        public string RunwayStatus{get;set;}
        public Aircraft CurrentAircraft{get;set;}
        public int TicksAvailability{get;set;}=3;
        public Runway(string id)
        {
            ID=id;
            RunwayStatus="Free";
            CurrentAircraft=null;
        }
        public bool RequestRunway(Aircraft aircraft){

            if(RunwayStatus == "Free"){
                RunwayStatus ="Occupied";
                CurrentAircraft = aircraft;
                return true;
            }
            return false;
        }
        public void ReleaseRunway()
        {
            if(RunwayStatus=="Occupied"&&CurrentAircraft!=null){
                CurrentAircraft=null;
                TicksAvailability=3;
                RunwayStatus="Free";
            }
        }
    }
}
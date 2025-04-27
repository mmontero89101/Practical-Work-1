using System;
namespace PracticalWork
{
    public class Runway
    {

        public enum RunwayStatus{Free, Occupied}
        public string ID{get;set;}
        public RunwayStatus Status {get;set;} = RunwayStatus.Free;
        public Aircraft CurrentAircraft{get;set;}
        public int TicksAvailability{get;set;}=3;
        public Runway(string id)
        {
            ID=id;
            Status = RunwayStatus.Free;
            CurrentAircraft=null;
            TicksAvailability = 0;
        }
        public bool RequestRunway(Aircraft aircraft){

            if( Status == RunwayStatus.Free){
                 Status = RunwayStatus.Occupied;
                CurrentAircraft = aircraft;
                return true;
            }
            return false;
        }
        public void ReleaseRunway()
        {
            if(Status == RunwayStatus.Occupied && CurrentAircraft!=null){
                CurrentAircraft=null;
                TicksAvailability=0;
                Status = RunwayStatus.Free;
            }
        }

        public bool IsFree()
        {
            return Status == RunwayStatus.Free;
        }

        public int GetRemainingTicks()
        {
        
            return TicksAvailability;
        }


    }
}
using ElevatorProj.Business.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProj.Business.Entities.BuildingEntity; 
namespace ElevatorProj.Business.Entities
{
    public class Building
    {
        private List<IElevator> elevators;
        private List<IFloor> floor;
        private List<ITimeForEachElevator> timeForEachElevators;
        public List<IElevator> Elevators { get => elevators; set => elevators = value; }
        public List<IFloor> Floor { get => floor; set => floor = value; }
        public List<ITimeForEachElevator> TimeForEachElevators { get => timeForEachElevators; set => timeForEachElevators = value; }
        public Building()
        {

        }
        public string FindBestLift(ElevatorOutsideRequest currentRequest )
        {
            try
            {
                return new ElevationManager(this.timeForEachElevators).FindBestLift(this.elevators, currentRequest);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

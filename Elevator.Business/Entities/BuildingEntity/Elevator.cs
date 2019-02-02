using ElevatorProj.Business.Request;
using System;
using System.Collections.Generic;


namespace ElevatorProj.Business.Entities.BuildingEntity
{
    public class Elevator :IElevator
    {
        private Floor currentFloor;
        public string ElevatorName { get; set; }
        public Floor CurrentFloor
        {
            get { return currentFloor; }
            set
            {
                if (currentFloor == null)
                    currentFloor = new Floor();
            }
        }
            
        public Direction CurrentDirection { get; set; }
        public List<IRequest> PendingRequestsInside { get; set; }
        public List<IRequest> PendingRequestsOutside { get; set; }
        public Guid ID { get; set; }

        public void MoveUp()
        {
            this.CurrentFloor.FloorNumber  += 1;
        }
        public void MoveDown()
        {
            this.CurrentFloor.FloorNumber -= 1;
        }

     }
}

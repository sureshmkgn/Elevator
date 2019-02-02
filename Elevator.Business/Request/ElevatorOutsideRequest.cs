
using ElevatorProj.Business.Entities.BuildingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProj.Business.Request
{
    public class ElevatorOutsideRequest : IRequest
    {
        public IFloor CurrentFloor { get; set; }
        public Direction MoveDirection { get; set; }
   
        public ElevatorOutsideRequest(IFloor CurrentFloor, Direction movedirection)
        {
            this.CurrentFloor = CurrentFloor;
            this.MoveDirection = movedirection;
        }

      
    }
}

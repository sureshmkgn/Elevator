using ElevatorProj.Business.Entities.BuildingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProj.Business.Request
{
   public class ElevatorInsideRequest : IRequest
    {
        public  Direction MoveDirection { get;  }
        public IFloor DestinationFloor { get; }
        public ElevatorInsideRequest(IFloor DestinationFloor, Direction direction )
        {
            this.MoveDirection = direction;
            this.DestinationFloor = DestinationFloor;
           
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProj.Business.Entities.BuildingEntity;
using ElevatorProj.Business.Request;

namespace ElevatorProj.Business.Factories
{
    public class BuildingEntityFactory : AbstractBuildingEntityFactory
    {
        public override IElevator CreateElevator()
        {
            return new Elevator { CurrentDirection = Direction.Idle,CurrentFloor = new Floor(), PendingRequestsInside = new List<IRequest>(), PendingRequestsOutside = new List<IRequest>() }; 
        }

        public override IFloor CreateFloor()
        {
            return new Floor { FloorNumber = 0, Skippable = false }; 
        }
    }
}

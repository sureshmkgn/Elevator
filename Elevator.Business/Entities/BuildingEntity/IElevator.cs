using ElevatorProj.Business.Request;
using System.Collections.Generic;

namespace ElevatorProj.Business.Entities.BuildingEntity
{
    public interface IElevator
    {
         string ElevatorName { get; set; }
        Floor CurrentFloor { get; set; }
        Direction CurrentDirection { get; set; }
        List<IRequest> PendingRequestsInside { get; set; }
        List<IRequest> PendingRequestsOutside { get; set; }
    }
}
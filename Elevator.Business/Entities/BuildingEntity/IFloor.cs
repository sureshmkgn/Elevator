using System;

namespace ElevatorProj.Business.Entities.BuildingEntity
{
    public interface IFloor
    {
        int FloorNumber { get; set; }
        Boolean Skippable { get; set; }
        int Halttime { get; set; }
    }
}
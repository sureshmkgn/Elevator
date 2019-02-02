using ElevatorProj.Business.Entities.BuildingEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorProj.Business.Factories
{
    public abstract class AbstractBuildingEntityFactory
    {
        public abstract IFloor CreateFloor();
        public abstract IElevator CreateElevator();

    }
}

using ElevatorProj.Business.Entities;
using ElevatorProj.Business.Entities.BuildingEntity;
using ElevatorProj.Business.Factories;
using ElevatorProj.Business.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorProj.Business
{
    public class BuildingDataMock
    {
        public Building CreateBuildingWithElivatorsAndFloors(int elivators, int Floors )
        {
            Building building = InitFacilities(elivators, Floors);
            building.TimeForEachElevators = new List<ITimeForEachElevator>();
            return building;
        }

        public static ElevatorOutsideRequest CreateMockPendingRequestOutSide( int fromFloorNumber,int toFloorNumber)
        {
            Direction direction = Direction.Idle;
            if (fromFloorNumber < toFloorNumber)
                direction = Direction.Up;
            else
                direction = Direction.Down;
            return new ElevatorOutsideRequest(new Floor { FloorNumber = fromFloorNumber, Skippable = false },  direction);
          
        }

        public static ElevatorInsideRequest CreateMockPendingRequestInSide(int currentFloor,Direction direction)
        {
            return new ElevatorInsideRequest(new Floor { FloorNumber = currentFloor, Skippable = false }, direction);
        }

        
        private Building InitFacilities(int numberOfElevators, int numberOfFloors)
        {
            Building building = new Building();   //TODO list init
            BuildingEntityFactory buildingEntityFactory = new BuildingEntityFactory();
            building.TimeForEachElevators = new List<ITimeForEachElevator>();

            building.Elevators = new List<IElevator>();
            building.Floor = new List<IFloor>();

            if (numberOfElevators <= 0 && numberOfFloors <= 0)
            {
                throw new Exception ("Invalid Inputs");
            }
            for (int elevatorCount = 1; elevatorCount <= numberOfElevators; elevatorCount++)
            {
                Elevator elevator = buildingEntityFactory.CreateElevator() as Elevator;
                building.Elevators.Add(elevator);
            }
            for (int FloorCount = 1; FloorCount <= numberOfFloors; FloorCount++)
            {
                Floor floor = buildingEntityFactory.CreateFloor() as Floor;
                floor.FloorNumber = FloorCount;
                building.Floor.Add(floor);
            }
            return building;
        }

    }
}

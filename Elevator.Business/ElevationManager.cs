using ElevatorProj.Business.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorProj.Business.Entities.BuildingEntity;

namespace ElevatorProj.Business
{
    public class ElevationManager
    {
        int stopageTimeforEachRequest = 10;
        int timeForPassingAFloor = 2;

        private List<ITimeForEachElevator>  elevatorTimeList;

        public ElevationManager(List<ITimeForEachElevator> elevatorTimeList)
        {
            if (elevatorTimeList != null && elevatorTimeList.Count!=0)
            {
                this.elevatorTimeList = elevatorTimeList;
            }
            else
            {
                throw new ArgumentException("Invalid Arguements");
            }
        }
        
        //Written the Nearest lifet based on the directions 
        
        public string FindBestLift(List<IElevator> elevators, ElevatorOutsideRequest currentRequest )
        {
            string liftName = "";
        //    List<TimeForEachElevator> elevatorTimeList = new List<TimeForEachElevator>();
            switch (currentRequest.MoveDirection)
            {
                case Direction.Down:
                    {
                        liftName = FindNearestLiftToGoDown(elevators, currentRequest);
                        break;
                    }
                case Direction.Up:
                    {
                        liftName = FindNearestLiftToGoUp(elevators, currentRequest);
                        break;
                    }
            }
            return liftName;

        }
        private string FindNearestLiftToGoUp(List<IElevator> elevators, IRequest currentRequest)
        {
            int noOfPendingRequest = 0;
            ElevatorOutsideRequest elevatorOutsideRequest = currentRequest as ElevatorOutsideRequest;
            try
            {
                foreach (Elevator el in elevators)
                {
                    if (el.CurrentDirection == Direction.Up && elevatorOutsideRequest.MoveDirection == Direction.Up)
                    {
                        if (el.CurrentFloor.FloorNumber < elevatorOutsideRequest.CurrentFloor.FloorNumber)
                        {
                            var numberOfFloors = elevatorOutsideRequest.CurrentFloor.FloorNumber - el.CurrentFloor.FloorNumber;
                            for (int i = 1; i < numberOfFloors; i++)
                            {
                                if (
                                    (el.PendingRequestsInside.ConvertAll(s=> s as ElevatorInsideRequest).Select(s => s.DestinationFloor.FloorNumber == (el.CurrentFloor.FloorNumber + i)).Count() == 1) ||
                                       ((el.PendingRequestsOutside.ConvertAll(s=>s as ElevatorOutsideRequest).Select(s => s.CurrentFloor.FloorNumber == (el.CurrentFloor.FloorNumber + i)).Count() == 1) &&
                                       (el.PendingRequestsOutside.Select(s => s.MoveDirection == el.CurrentDirection).Count() == 1))
                                       )
                                {
                                    noOfPendingRequest++;
                                }
                            }

                        }

                        var totalTime = noOfPendingRequest * stopageTimeforEachRequest +
                            ((elevatorOutsideRequest.CurrentFloor.FloorNumber - el.CurrentFloor.FloorNumber) - noOfPendingRequest) * timeForPassingAFloor;
                        elevatorTimeList.Add(new TimeForEachElevator { ElevatorName = el.ElevatorName, Time = totalTime });

                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return pickLiftWithLowestTime(elevatorTimeList);
        }

        private string FindNearestLiftToGoDown(List<IElevator> elevators, ElevatorOutsideRequest currentRequest)
        {
            int noOfPendingRequest = 0;
            ElevatorOutsideRequest elevatorOutsideRequest = currentRequest as ElevatorOutsideRequest;
            try
            {
                foreach (Elevator el in elevators)
                {
                    if (el.CurrentDirection == Direction.Down && elevatorOutsideRequest.MoveDirection == Direction.Down)
                    {
                        if (el.CurrentFloor.FloorNumber > elevatorOutsideRequest.CurrentFloor.FloorNumber)
                        {
                            var numberOfFloors = el.CurrentFloor.FloorNumber - elevatorOutsideRequest.CurrentFloor.FloorNumber;
                            for (int i = 1; i < numberOfFloors; i++)
                            {
                                if (
                                    (el.PendingRequestsInside.ConvertAll(s=>s as ElevatorInsideRequest).Select(s => s.DestinationFloor.FloorNumber == (el.CurrentFloor.FloorNumber - i)).Count() == 1) ||
                                       ((el.PendingRequestsOutside.ConvertAll(s=>s as ElevatorOutsideRequest).Select(s => s.CurrentFloor.FloorNumber == (el.CurrentFloor.FloorNumber - i)).Count() == 1) &&
                                       (el.PendingRequestsOutside.Select(s => s.MoveDirection == el.CurrentDirection).Count() == 1))
                                       )
                                {
                                    noOfPendingRequest++;
                                }
                            }

                        }

                        var totalTime = noOfPendingRequest * stopageTimeforEachRequest +
                            ((el.CurrentFloor.FloorNumber - elevatorOutsideRequest.CurrentFloor.FloorNumber) - noOfPendingRequest) * timeForPassingAFloor;
                        elevatorTimeList.Add(new TimeForEachElevator { ElevatorName = el.ElevatorName, Time = totalTime });

                    }
                }
            }
            catch(Exception ex)
            {

                throw ex;
            }
            return pickLiftWithLowestTime(elevatorTimeList);
        }

        private string pickLiftWithLowestTime(List<ITimeForEachElevator> elevatorTimeList)
        {
            int LowestliftTime = 10000000;
            if (elevatorTimeList.Count > 0)
            {
                foreach (var liftTime in elevatorTimeList)
                {
                    if (liftTime.Time < LowestliftTime)
                    {
                        LowestliftTime = liftTime.Time;
                    }
                }
            }
            return elevatorTimeList.FirstOrDefault(s => s.Time == LowestliftTime).ElevatorName;
        }


    }
}

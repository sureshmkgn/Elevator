using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorProj.Business
{
   public class TimeForEachElevator : ITimeForEachElevator
    {
        public string ElevatorName { get; set; }
        public int Time { get; set; }
    }
}

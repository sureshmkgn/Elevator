using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProj.Business
{
    public enum Direction
    {
        Up,Down,Wait,Idle 
    }

    //public enum FloorLocation
    //{
    //    LowerBasement =-2 , Basement =-1 , GroundFloor= 0, First =1
    //}

    public enum BuildingEntityType
    {
        Elevator,Floor 
    }
}

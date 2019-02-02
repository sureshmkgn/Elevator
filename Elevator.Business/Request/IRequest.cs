using ElevatorProj.Business.Entities.BuildingEntity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProj.Business.Request
{
    public interface IRequest
    {
         Direction MoveDirection { get; }
      
    }
}

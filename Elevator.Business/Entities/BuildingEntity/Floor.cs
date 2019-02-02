using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProj.Business.Entities.BuildingEntity
{
    public class Floor : IFloor
    {
        public int FloorNumber { get; set; }
        public Boolean Skippable  { get; set; }
        public int Halttime { get; set; }

        public Guid ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

using ApplicationCore.Common;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Vehicle : BaseEntity
    {

        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }

        public List<Container> Containers { get; set; }

    }
}

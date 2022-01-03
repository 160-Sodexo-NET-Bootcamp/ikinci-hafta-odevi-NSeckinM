using ApplicationCore.Common;
using System;

namespace ApplicationCore.Entities
{
    public class Container : BaseEntity
    {

        public string ContainerName { get; set; }

        public Decimal Latitude { get; set; }

        public Decimal Longitude { get; set; }


        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}

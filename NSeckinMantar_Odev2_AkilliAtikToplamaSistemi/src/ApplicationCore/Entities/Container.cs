using ApplicationCore.Common;
using System;

namespace ApplicationCore.Entities
{
    public class Container : BaseEntity
    {

        public string ContainerName { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }


        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}

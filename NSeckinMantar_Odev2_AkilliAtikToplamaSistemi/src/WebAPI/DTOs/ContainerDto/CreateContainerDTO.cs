using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs.ContainerDto
{
    public class CreateContainerDTO
    {
        public string ContainerName { get; set; }

        public Decimal Latitude { get; set; }

        public Decimal Longitude { get; set; }


        public int? VehicleId { get; set; }
    }
}

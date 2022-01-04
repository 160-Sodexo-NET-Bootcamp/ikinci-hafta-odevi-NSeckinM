using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs.VehicleDto
{
    public class UpdateVehicleDTO
    {
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }
    }
}

using ApplicationCore.Entities;
using ApplicationCore.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.VehicleDto;

namespace WebAPI.Controllers
{
    [Route("api/v1/Vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //You can use the HttpGet request to take all vehicle list
        //Request URL = https://localhost:44341/api/v1/Vehicles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Vehicles.GetAllAsync());
        }

        //You can use this HttpGet request with id  to get just one vehicle object.
        //Request URL = https://localhost:44341/api/v1/Vehicles/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            Vehicle vehicle = await _unitOfWork.Vehicles.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return await Task.FromResult(Ok(vehicle));
        }


        //You can use this HttpGet request with id parameter to get just one vehicle object with its own Containers.
        //Request URL = https://localhost:44341/api/v1/Vehicles/VehicleWithContainers?id=1
        [Route("VehicleWithContainers")]
        [HttpGet]
        public async Task<IActionResult> GetVehicleWithContainers(int id)
        {
            Vehicle vehicle = await _unitOfWork.Vehicles.GetVehicleWithContainers(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        //You can use this HttpPost request to create new vehicle's object.
        //Request URL =  https://localhost:44341/api/v1/Vehicles
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDTO vehicleCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            //Mapping
            Vehicle vehc = new()
            {
                VehicleName = vehicleCreateDto.VehicleName,
                VehiclePlate = vehicleCreateDto.VehiclePlate
            };

            await _unitOfWork.Vehicles.AddAsync(vehc);
            _unitOfWork.Complete();

            return CreatedAtAction("GetVehicle", new { Id = vehc.Id }, vehicleCreateDto);
        }

        //You can use this HttpPut request to update vehicle's object already have with using unique id.
        //Request URL =  https://localhost:44341/api/v1/Vehicles/3
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle([FromRoute] int id, [FromBody] UpdateVehicleDTO vehicleUpdateDto)
        {

            if (ModelState.IsValid)
            {
                Vehicle vehicle = new()
                {
                    Id = vehicleUpdateDto.Id,
                    VehicleName = vehicleUpdateDto.VehicleName,
                    VehiclePlate = vehicleUpdateDto.VehiclePlate
                };

                if (id != vehicle.Id)
                {
                    return BadRequest("Id information is not confirmed");
                }

                await _unitOfWork.Vehicles.UpdateAsync(vehicle);
                _unitOfWork.Complete();
                return Ok("Vehicle Updated");
            }
            return BadRequest(ModelState);

        }

        //You can use this HttpDelete request to delete vehicle's object already have with using unique id.
        //Request URL =  https://localhost:44341/api/v1/Vehicles/4
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            Vehicle vehicle = await _unitOfWork.Vehicles.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            await _unitOfWork.Vehicles.DeleteAsync(vehicle);
            _unitOfWork.Complete();
            return NoContent();
        }

    }
}

using ApplicationCore.Entities;
using ApplicationCore.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.ContainerDto;

namespace WebAPI.Controllers
{
    [Route("api/v1/Containers")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContainerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //You can use the HttpGet request to take all Container list
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Containers.GetAllAsync());
        }

        //You can use this HttpGet request with id  to get just one Container object.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContainer(int id)
        {
            Container container = await _unitOfWork.Containers.GetByIdAsync(id);
            if (container == null)
            {
                return NotFound();
            }
            return Ok(container);
        }

        //You can use this HttpPost request to create new container's object.
        [HttpPost]
        public async Task<IActionResult> CreateContainer([FromBody] CreateContainerDTO containerDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            //if (await _unitOfWork.Vehicles.GetByIdAsync(containerDto.VehicleId) == null )
            //{
            //    return BadRequest("Yo");
            //}
            Container container = new()
            {
                ContainerName = containerDto.ContainerName,
                Latitude = containerDto.Latitude,
                Longitude = containerDto.Longitude,
                VehicleId = containerDto.VehicleId,
            };
            await _unitOfWork.Containers.AddAsync(container);
            _unitOfWork.Complete();

            return CreatedAtAction("GetContainer", new { Id = container.Id }, containerDto);
        }

        //You can use this HttpPut request to update container's object already have with using unique id.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContainer([FromRoute] int id, [FromBody] UpdateContainerDTO updateContainerDto)
        {
            Container container = new();
            if (ModelState.IsValid)
            {
                if (id != updateContainerDto.Id)
                {
                    return BadRequest("Id information is not confirmed");
                }

                container = await _unitOfWork.Containers.GetByIdAsync(id);
                container.Id = updateContainerDto.Id;
                container.ContainerName = updateContainerDto.ContainerName;
                container.Latitude = updateContainerDto.Latitude;
                container.Longitude = updateContainerDto.Longitude;



                 _unitOfWork.Containers.UpdateAsync(container);
                _unitOfWork.Complete();
                return Ok("Container Updated");
            }
            return BadRequest(ModelState);

        }

        //You can use this HttpDelete request to delete container's object already have with using unique id.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            Container container = await _unitOfWork.Containers.GetByIdAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            await _unitOfWork.Containers.DeleteAsync(container);
            _unitOfWork.Complete();
            return NoContent();
        }

    }
}

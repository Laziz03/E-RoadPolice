using ERoadPolice.Application.Services;
using ERoadPolice.Domain.Entities;
using ERoadPolice.Domain.Models;
using ERoadPolice.Domain.Models.DriverDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;

namespace E_RoadPolice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class DriverController : ControllerBase
{/*
    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Driver> drivers = await _driverService.GetAllAsync();
        return Ok(drivers);
    }

    [HttpGet]
    public async Task<Response<DriverGetDTO>> GetById(int id)
    {
        Driver driverEntity = await _driverService.GetByIdAsync(id);

        if (driverEntity == null)
        {
            return new Response<DriverGetDTO>("Driver not found.", HttpStatusCode.NotFound);
        }

        var driverDto = new DriverGetDTO
        {
            DriverId = driverEntity.DriverId,
            FullName = driverEntity.FullName,
            LicenseNumber = driverEntity.LicenseNumber,
            Incidents = driverEntity.Incidents?.Select(i => new IncidentDTO
            {
                IncidentId = i.IncidentId,
                Description = i.Description,
                DateTime = i.DateTime,
                Address = i.Address
            }).ToList()
        };

        return new Response<DriverGetDTO>(driverDto);
    }

    [HttpPost]
    public async Task<Response<DriverGetDTO>> Create(DriverCreateDTO driverCreateDto)
    {
        // Map DTO to entity
        var mappedDriver = new Driver
        {
            FullName = driverCreateDto.FullName,
            LicenseNumber = driverCreateDto.LicenseNumber,
            // Map other properties
        };

        Driver driverEntity = await _driverService.CreateAsync(mappedDriver);

        var driverDto = new DriverGetDTO
        {
            DriverId = driverEntity.DriverId,
            FullName = driverEntity.FullName,
            LicenseNumber = driverEntity.LicenseNumber,
            // Map other properties
        };

        return new Response<DriverGetDTO>(driverDto);
    }

    [HttpDelete]
    public async Task<Response<bool>> DeleteAsync(int id)
    {
        bool resultDelete = await _driverService.DeleteAsync(id);
        return new Response<bool>(resultDelete);
    }

    [HttpPut("{id}")]
    public async Task<Response<DriverGetDTO>> Update(int id, [FromBody] DriverUpdateDTO driverUpdateDto)
    {
        Driver existingDriver = await _driverService.GetByIdAsync(id);

        if (existingDriver == null)
        {
            return new Response<DriverGetDTO>("Driver not found.", HttpStatusCode.NotFound);
        }

        // Update existingDriver properties based on driverUpdateDto

        bool result = await _driverService.UpdateAsync(existingDriver);

        if (result)
        {
            var updatedDriverDto = new DriverGetDTO
            {
                DriverId = existingDriver.DriverId,
                FullName = existingDriver.FullName,
                LicenseNumber = existingDriver.LicenseNumber,
                // Map other properties
            };

            return new Response<DriverGetDTO>(updatedDriverDto, HttpStatusCode.OK);
        }
        else
        {
            return new Response<DriverGetDTO>("Driver data not updated.", HttpStatusCode.InternalServerError);
        }
    }*/
}


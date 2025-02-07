using System;
using Tracking.DTOs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Tracking.Services
{
    [AllowAnonymous]
    public class VehicleAppService : 
        CrudAppService<
            Vehicle,
            VehicleDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateVehicleDto,
            UpdateVehicleDto>,
        IVehicleAppService
    {
        public VehicleAppService(IRepository<Vehicle, Guid> repository)
            : base(repository)
        {
            GetPolicyName = null;
            GetListPolicyName = null;
            CreatePolicyName = null;
            UpdatePolicyName = null;
            DeletePolicyName = null;
        }

        protected override Vehicle MapToEntity(CreateVehicleDto createInput)
        {
            var entity = new Vehicle
            {
                Name = createInput.Name,
                Location = new Tracking.ValueObjects.Location
                {
                    Latitude = createInput.Location.Latitude,
                    Longitude = createInput.Location.Longitude
                }
            };

            return entity;
        }

        protected override void MapToEntity(UpdateVehicleDto updateInput, Vehicle entity)
        {
            entity.Name = updateInput.Name;
            entity.Location = new ValueObjects.Location
            {
                Latitude = updateInput.Location.Latitude,
                Longitude = updateInput.Location.Longitude
            };
        }
    }
} 
using System;
using Tracking.DTOs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tracking.Services
{
    public interface IVehicleAppService : 
        ICrudAppService<
            VehicleDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateVehicleDto,
            UpdateVehicleDto>
    {
    }
} 
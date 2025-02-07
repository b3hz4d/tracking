using System;
using Volo.Abp.Application.Dtos;

namespace Tracking.DTOs
{
    public class VehicleDto : AuditedEntityDto<Guid>
    {
        public required string Name { get; set; }
        public required LocationDto Location { get; set; }
    }

    public class CreateVehicleDto
    {
        public required string Name { get; set; }
        public required LocationDto Location { get; set; }
    }

    public class UpdateVehicleDto
    {
        public required string Name { get; set; }
        public required LocationDto Location { get; set; }
    }
} 
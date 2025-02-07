using System;
using Volo.Abp.Application.Dtos;

namespace Tracking.DTOs
{
    public class PersonDto : AuditedEntityDto<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required LocationDto Location { get; set; }
    }

    public class CreatePersonDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required LocationDto Location { get; set; }
    }

    public class UpdatePersonDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required LocationDto Location { get; set; }
    }
} 
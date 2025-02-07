using System;
using Volo.Abp.Application.Dtos;

namespace Tracking.DTOs
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public required string Name { get; set; }
        public required string ProductCode { get; set; }
        public required LocationDto Location { get; set; }
    }

    public class CreateProductDto
    {
        public required string Name { get; set; }
        public required string ProductCode { get; set; }
        public required LocationDto Location { get; set; }
    }

    public class UpdateProductDto
    {
        public required string Name { get; set; }
        public required string ProductCode { get; set; }
        public required LocationDto Location { get; set; }
    }
} 
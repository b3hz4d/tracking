using System;
using Tracking.DTOs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tracking.Services
{
    public class ProductAppService : 
        CrudAppService<
            Product,
            ProductDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateProductDto,
            UpdateProductDto>,
        IProductAppService
    {
        public ProductAppService(IRepository<Product, Guid> repository)
            : base(repository)
        {
        }

        protected override Product MapToEntity(CreateProductDto createInput)
        {
            var entity = new Product
            {
                Name = createInput.Name,
                ProductCode = createInput.ProductCode,
                Location = new ValueObjects.Location
                {
                    Latitude = createInput.Location.Latitude,
                    Longitude = createInput.Location.Longitude
                }
            };

            return entity;
        }

        protected override void MapToEntity(UpdateProductDto updateInput, Product entity)
        {
            entity.Name = updateInput.Name;
            entity.ProductCode = updateInput.ProductCode;
            entity.Location = new ValueObjects.Location
            {
                Latitude = updateInput.Location.Latitude,
                Longitude = updateInput.Location.Longitude
            };
        }
    }
} 
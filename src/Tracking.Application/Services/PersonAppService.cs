using System;
using Tracking.DTOs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tracking.Services
{
    public class PersonAppService : 
        CrudAppService<
            Person,
            PersonDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreatePersonDto,
            UpdatePersonDto>,
        IPersonAppService
    {
        public PersonAppService(IRepository<Person, Guid> repository)
            : base(repository)
        {
        }

        protected override Person MapToEntity(CreatePersonDto createInput)
        {
            var entity = new Person
            {
                FirstName = createInput.FirstName,
                LastName = createInput.LastName,
                Location = new ValueObejcts.Location
                {
                    Latitude = createInput.Location.Latitude,
                    Longitude = createInput.Location.Longitude
                }
            };

            return entity;
        }

        protected override void MapToEntity(UpdatePersonDto updateInput, Person entity)
        {
            entity.FirstName = updateInput.FirstName;
            entity.LastName = updateInput.LastName;
            entity.Location = new ValueObejcts.Location
            {
                Latitude = updateInput.Location.Latitude,
                Longitude = updateInput.Location.Longitude
            };
        }
    }
} 
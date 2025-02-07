using System;
using Tracking.DTOs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tracking.Services
{
    public interface IPersonAppService : 
        ICrudAppService<
            PersonDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreatePersonDto,
            UpdatePersonDto>
    {
    }
} 
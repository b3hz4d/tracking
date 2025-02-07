using AutoMapper;
using Tracking.DTOs;
using Tracking.ValueObjects;

namespace Tracking;

public class TrackingApplicationAutoMapperProfile : Profile
{
    public TrackingApplicationAutoMapperProfile()
    {
        CreateMap<Location, LocationDto>();
        CreateMap<LocationDto, Location>();

        CreateMap<Vehicle, VehicleDto>();
        CreateMap<CreateVehicleDto, Vehicle>();
        CreateMap<UpdateVehicleDto, Vehicle>();

        CreateMap<Person, PersonDto>();
        CreateMap<CreatePersonDto, Person>();
        CreateMap<UpdatePersonDto, Person>();

        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
    }
}

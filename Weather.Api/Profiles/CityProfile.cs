using AutoMapper;
using Weather.Api.DTOs;
using Weather.Domain.Entities;

namespace Weather.Api.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
        }
    }

}

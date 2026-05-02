using AutoMapper;
using Weather.Api.DTOs;
using Weather.Domain.Entities;

namespace Weather.Api.Profiles
{
    public class WeatherDataDtoProfile : Profile
    {
        public WeatherDataDtoProfile()
        {
             CreateMap<WeatherDataDto, WeatherData>();
            CreateMap<WeatherDataDto, WeatherData>().ReverseMap();
        }
    }
}

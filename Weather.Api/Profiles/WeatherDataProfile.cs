using AutoMapper;
using Weather.Api.DTOs;
using Weather.Domain.Entities;

namespace Weather.Api.Profiles
{
    public class WeatherDataProfile : Profile
    {
        public WeatherDataProfile()
        {
            CreateMap<WeatherData, WeatherDataDto>();
        }
    }

}

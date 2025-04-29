using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Weather.Api.DTOs;
using Weather.DataAccessLayer.Repositories;

namespace Weather.Api.Features.Weather.Queries
{
    public class GetHourlyWeatherDataQuery : IRequest<WeatherDataDto>
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int unixtime { get; set; }
    }

    public class GetHourlyWeatherDataHandler : IRequestHandler<GetHourlyWeatherDataQuery, WeatherDataDto>
    {
        private readonly IMemoryCache _chache;
        private readonly IWeatherDataRepository _repository;
        private readonly IMapper _mapper;
        public GetHourlyWeatherDataHandler(IWeatherDataRepository repository, IMemoryCache cache, IMapper mapper)
        {
            _chache = cache;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<WeatherDataDto> Handle(GetHourlyWeatherDataQuery request, CancellationToken cancellationToken)
        {
            var weatherData = await _repository.GetHourlyByCoordinates(request.latitude, request.longitude, request.unixtime);
            Console.Write(weatherData);
            return _mapper.Map<WeatherDataDto>(weatherData);

        }
    }
}

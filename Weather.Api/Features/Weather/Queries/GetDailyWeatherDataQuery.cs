using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Weather.Api.DTOs;
using Weather.DataAccessLayer.Repositories;

namespace Weather.Api.Features.Weather.Queries
{
    public class GetDailyWeatherDataQuery : IRequest<WeatherDataDto>
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int unixtime { get; set; }

    }
    public class GetDailyWeatherDataHandler : IRequestHandler<GetDailyWeatherDataQuery, WeatherDataDto>
    {
        private readonly IMemoryCache _chache;
        private readonly IWeatherDataRepository _repository;
        private readonly IMapper _mapper;
        public GetDailyWeatherDataHandler(IWeatherDataRepository repository, IMemoryCache cache, IMapper mapper)
        {
            _chache = cache;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<WeatherDataDto> Handle(GetDailyWeatherDataQuery request, CancellationToken cancellationToken)
        {
            var weatherData = await _repository.GetDailyByCoordinates(request.latitude, request.longitude, request.unixtime);
            Console.Write(weatherData);
            return _mapper.Map<WeatherDataDto>(weatherData);
        }
    }

}

using AutoMapper;
using MediatR;
using Weather.Api.DTOs;
using Weather.DataAccessLayer.Repositories;
using Weather.Domain.Entities;

namespace Weather.Api.Features.Weather.Commands
{
    public class CreateWeatherDataCommand : IRequest
    {
        public WeatherDataDto WeatherDataDto { get; set; }
    }

    public class CreateWeatherDataHandler : IRequestHandler<CreateWeatherDataCommand>
    {
        private readonly IWeatherDataRepository _repository;
        private readonly IMapper _mapper;
        public CreateWeatherDataHandler(IWeatherDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateWeatherDataCommand request, CancellationToken cancellationToken)
        {
            var weatherData = _mapper.Map<WeatherData>(request.WeatherDataDto);
            await _repository.AddWeatherDataAsync(weatherData);
            return Unit.Value;
        }
    }

}

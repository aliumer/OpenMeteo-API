using AutoMapper;
using MediatR;
using Weather.Api.DTOs;
using Weather.DataAccessLayer.Repositories;
using Weather.Domain.Entities;
namespace Weather.Api.Features.Cities.Commands
{
    public class CreateCityCommand : IRequest<List<CityDto>>
    {
        public List<City> Cities { get; set; } = new List<City>();
    }

    public class CreateCityHandler : IRequestHandler<CreateCityCommand, List<CityDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CreateCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.AddAsync(request.Cities);
            return _mapper.Map<List<CityDto>>(cities);
        }
    }
}

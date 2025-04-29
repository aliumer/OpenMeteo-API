using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Weather.DataAccessLayer.Repositories;
using Weather.Domain.Entities;

namespace Weather.Api.Features.Cities.Queries
{
    public class GetCityByNameQuery : IRequest<List<City>>
    {
        public string CityName { get; set; } = string.Empty;
    }

    public class GetCityByNameHandler : IRequestHandler<GetCityByNameQuery, List<City>>
    {
        private readonly IMemoryCache _chache;
        private readonly ICityRepository _cityRepository;
        public GetCityByNameHandler(IMemoryCache cache, ICityRepository cityRepository)
        {
            _chache = cache;
            _cityRepository = cityRepository;
        }
        public async Task<List<City>> Handle(GetCityByNameQuery request, CancellationToken cancellationToken)
        {

            // First, check the cache.
            if (_chache.TryGetValue(request.CityName, out List<City>? citiesFromCache) && citiesFromCache != null)
            {
                // return from cache.
                return await Task.FromResult(citiesFromCache);
            }

            // check if city exists in database
            if (await _cityRepository.RecordExists(request.CityName))
            {
                // get from database.
                var cities = await _cityRepository.GetByCityName(request.CityName);

                // add city in cache.
                _chache.Set(request.CityName, cities, TimeSpan.FromMinutes(10));
                return cities;
            }

            // not found in DB and Cache. return null
            // controller will get it from open meteo and add it to database 
            // then it will return it from database and add it to cache for 10 minutes.
            return null;

        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Weather.Domain.Entities;

namespace Weather.DataAccessLayer.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly WeatherDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(WeatherDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<City>> AddAsync(List<City> cities)
        {
            _context.Cities.AddRange(cities);
            await _context.SaveChangesAsync();
            return cities;
        }

        public async Task<List<City>> GetByCityName(string cityName)
        {
            var cities = await _context.Cities
               .Where(c => c.Name.ToLower() == cityName.ToLower()).ToListAsync();

            return _mapper.Map<List<City>>(cities);
        }

        public async Task<bool> RecordExists(string cityName)
        {
            var exists = await _context.Cities
                .AnyAsync(c => c.Name.ToLower() == cityName.ToLower());
            
            return await Task.FromResult(exists);
        }
    }
}

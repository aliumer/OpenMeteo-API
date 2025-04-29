using Microsoft.EntityFrameworkCore;
using Weather.Domain.Entities;

namespace Weather.DataAccessLayer.Repositories
{
    public class WeatherDataRepository : IWeatherDataRepository
    {
        private readonly WeatherDbContext _context;

        public WeatherDataRepository(WeatherDbContext context)
        {
            _context = context;
        }
        public async Task AddWeatherDataAsync(WeatherData weatherData)
        {
            _context.WeatherData.Add(weatherData);
            await _context.SaveChangesAsync();
        }

        public async Task<WeatherData> GetDailyByCoordinates(double latitude, double longitude, int unixtime)
        {
            var query = await _context.WeatherData
            .Include(w => w.daily_units)
            .Include(w => w.daily)
            .Where(w => w.latitude == latitude && w.longitude == longitude)
            .ToListAsync();

            var data = query.FirstOrDefault(w => w.daily.time.Contains(unixtime));

            return data != null ? data : null;
        }

        public async Task<WeatherData> GetHourlyByCoordinates(double latitude, double longitude, int unixtime)
        {
            var query = await _context.WeatherData
                .Include(w => w.hourly_units)
                .Include(w => w.hourly)
                .Where(w => w.latitude == latitude
                    && w.longitude == longitude)
                .ToListAsync();
                      
            var data = query.FirstOrDefault(w => w.hourly.time.Contains(unixtime));

            return data != null ? data : null;
        }
    }
}

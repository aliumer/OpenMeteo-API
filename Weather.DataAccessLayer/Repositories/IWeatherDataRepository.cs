using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;

namespace Weather.DataAccessLayer.Repositories
{
    public interface IWeatherDataRepository
    {
        Task<WeatherData> GetHourlyByCoordinates(double latitude, double longitude, int unixtime);
        Task<WeatherData> GetDailyByCoordinates(double latitude, double longitude, int unixtime);
        Task AddWeatherDataAsync(WeatherData weatherData);
    }
}

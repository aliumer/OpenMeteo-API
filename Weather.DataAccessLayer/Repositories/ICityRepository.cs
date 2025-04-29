using Weather.Domain.Entities;

namespace Weather.DataAccessLayer.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetByCityName(string cityName);
        Task<List<City>> AddAsync(List<City> cities);
        Task<bool> RecordExists(string cityName);
    }
}

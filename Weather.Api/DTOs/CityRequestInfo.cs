using Weather.Domain.Entities;

namespace Weather.Api.DTOs
{
    public class CityRequestInfo
    {
        public List<City> results { get; set; }
        public float generationtime_ms { get; set; }
    }
}

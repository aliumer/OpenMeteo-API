using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Weather.Domain.Entities
{
    public class WeatherData
    {
        public int Id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; } = string.Empty;
        public string timezone_abbreviation { get; set; } = string.Empty;
        public double elevation { get; set; }
        public Hourly? hourly { get; set; }
        public HourlyUnits? hourly_units { get; set; }
        public Daily? daily { get; set; }
        public DailyUnits? daily_units { get; set; }
    }
    public class HourlyUnits
    {
        public int Id { get; set; }
        public int weatherId { get; set; }
        public string time { get; set; } = string.Empty;
        public string rain { get; set; } = string.Empty;
        public string weather_code { get; set; } = string.Empty;
        public string wind_speed_180m { get; set; } = string.Empty;
        public string temperature_180m { get; set; } = string.Empty;
        public WeatherData WeatherData { get; set; } = null!;

    }

    public class Hourly
    {
        public int Id { get; set; }
        public int weatherId { get; set; }
        public List<int> time { get; set; } = new List<int>();
        public List<double> rain { get; set; } = new List<double>();
        public List<int> weather_code { get; set; } = new List<int>();
        public List<double> wind_speed_180m { get; set; } = new List<double>();
        public List<double> temperature_180m { get; set; } = new List<double>();
        public WeatherData WeatherData { get; set; } = null!;
    }
    public class DailyUnits
    {
        public int Id { get; set; }
        public int weatherId { get; set; }
        public WeatherData WeatherData { get; set; } = null!;
        public string time { get; set; } = string.Empty;
        public string weather_code { get; set; } = string.Empty;
        public string temperature_2m_max { get; set; } = string.Empty;
        public string temperature_2m_min { get; set; } = string.Empty;
        public string rain_sum { get; set; } = string.Empty;
        public string wind_speed_10m_max { get; set; } = string.Empty;

    }
    public class Daily
    {
        public int Id { get; set; }
        public int weatherId { get; set; }
        public WeatherData WeatherData { get; set; } = null!;
        public List<int> time { get; set; } = new List<int>();
        public List<double> rain_sum { get; set; } = new List<double>();
        public List<int> weather_code { get; set; } = new List<int>();
        public List<double> temperature_2m_max { get; set; } = new List<double>();
        public List<double> temperature_2m_min { get; set; } = new List<double>();
        public List<double> wind_speed_10m_max { get; set; } = new List<double>();

    }
}

using Weather.Domain.Entities;

namespace Weather.Api.DTOs
{
    public class WeatherDataDto
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; } = string.Empty;
        public string timezone_abbreviation { get; set; } = string.Empty;
        public double elevation { get; set; }
        public Hourly? hourly { get; set; }
        public HourlyUnits? hourly_units { get; set; }
        public DailyUnits? daily_units { get; set; }
        public Daily? daily { get; set; }
    }

    //public class HourlyUnitsDto
    //{
    //    public string time { get; set; } = string.Empty;
    //    public string rain { get; set; } = string.Empty;
    //    public string weather_code { get; set; } = string.Empty;
    //    public string wind_speed_180m { get; set; } = string.Empty;
    //    public string temperature_180m { get; set; } = string.Empty;
    //}
    //public class HourlyDto
    //{
    //    public List<int> time { get; set; } = new List<int>();
    //    public List<double> rain { get; set; } = new List<double>();
    //    public List<int> weather_code { get; set; } = new List<int>();
    //    public List<double> wind_speed_180m { get; set; } = new List<double>();
    //    public List<double> temperature_180m { get; set; } = new List<double>();
    //}
    //public class DailyDto
    //{
    //    public List<int> time { get; set; } = new List<int>();
    //    public List<int> weather_code { get; set; } = new List<int>();
    //    public List<double> temperature_2m_max { get; set; } = new List<double>();
    //    public List<double> temperature_2m_min { get; set; } = new List<double>();
    //    public List<double> rain_sum { get; set; } = new List<double>();
    //    public List<double> wind_speed_10m_max { get; set; } = new List<double>();
    //}

    //public class DailyUnitsDto
    //{
    //    public string? time { get; set; }
    //    public string? weather_code { get; set; }
    //    public string? temperature_2m_max { get; set; }
    //    public string? temperature_2m_min { get; set; }
    //    public string? rain_sum { get; set; }
    //    public string? wind_speed_10m_max { get; set; }
    //}

}

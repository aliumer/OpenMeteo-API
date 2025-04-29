using MediatR;
using System.Text;
using Weather.Api.DTOs;
using Weather.ExternalServices.Wrapper;

namespace Weather.Api.Features.Weather.Queries
{
    public class GetHourlyWeatherDataFromOpenMeteoQuery : IRequest<WeatherDataDto>
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string hourly { get; set; } = string.Empty;
        public string wind_speed_unit { get; set; } = string.Empty;
        public string timeformat { get; set; } = string.Empty;
        public int forecast_days { get; set; }

    }

    public class GetHourlyWeatherDataFromOpenMeteoHandler : IRequestHandler<GetHourlyWeatherDataFromOpenMeteoQuery, WeatherDataDto>
    {
        private readonly IWrapperApiService _wrapperApiService;
        public GetHourlyWeatherDataFromOpenMeteoHandler(IWrapperApiService wrapperApiService)
        {
            _wrapperApiService = wrapperApiService;
        }
        public async Task<WeatherDataDto> Handle(GetHourlyWeatherDataFromOpenMeteoQuery request, CancellationToken cancellationToken)
        {
            var url = new StringBuilder();
            url.AppendFormat("?latitude={0}", request.latitude);
            url.AppendFormat("&longitude={0}", request.longitude);
            url.AppendFormat("&hourly={0}", request.hourly);
            url.AppendFormat("&wind_speed_unit={0}", request.wind_speed_unit);
            url.AppendFormat("&timeformat={0}", request.timeformat);
            url.AppendFormat("&forecast_days={0}", request.forecast_days);
            var weather = await _wrapperApiService.GetAsync<WeatherDataDto>("WeatherApi", url.ToString());
            return weather;
        }
    }
}

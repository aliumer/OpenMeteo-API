using MediatR;
using System.Text;
using Weather.Api.DTOs;
using Weather.ExternalServices.Wrapper;

namespace Weather.Api.Features.Weather.Queries
{
    public class GetDailyWeatherDataFormOpenMeteoQuery : IRequest<WeatherDataDto>
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string daily { get; set; } = string.Empty;
        public string timeformat { get; set; } = string.Empty;
        public int forecast_days { get; set; }
    }

    public class GetDailyWeatherDataFormOpenMeteoHandler : IRequestHandler<GetDailyWeatherDataFormOpenMeteoQuery, WeatherDataDto>
    {
        private readonly IWrapperApiService _wrapperApiService;
        public GetDailyWeatherDataFormOpenMeteoHandler(IWrapperApiService wrapperApiService)
        {
            _wrapperApiService = wrapperApiService;
        }
        public async Task<WeatherDataDto> Handle(GetDailyWeatherDataFormOpenMeteoQuery request, CancellationToken cancellationToken)
        {
            var url = new StringBuilder();
            url.AppendFormat("?latitude={0}", request.latitude);
            url.AppendFormat("&longitude={0}", request.longitude);
            url.AppendFormat("&daily={0}", request.daily);
            url.AppendFormat("&timeformat={0}", request.timeformat);
            url.AppendFormat("&forecast_days={0}", request.forecast_days);
            var weather = await _wrapperApiService.GetAsync<WeatherDataDto>("WeatherApi", url.ToString());
            return weather;

        }
    }
}

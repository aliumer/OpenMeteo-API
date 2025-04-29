using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.Api.DTOs;
using Weather.Api.Features.Weather.Commands;
using Weather.Api.Features.Weather.Queries;

namespace Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("hourly")]
        public async Task<ActionResult<WeatherDataDto>> GetHourlyWeather([FromQuery]double latitude, [FromQuery]double longitude, [FromQuery] int unixtime)
        {
            try
            {

                Console.WriteLine("Getting Hourly Data from DB");
                var weatherData = await _mediator.Send(new GetHourlyWeatherDataQuery { latitude = latitude, longitude = longitude, unixtime = unixtime });

                if (weatherData == null)
                {
                    weatherData = await _mediator.Send(new GetHourlyWeatherDataFromOpenMeteoQuery
                    {
                        latitude = latitude,
                        longitude = longitude,
                        hourly = "rain,weather_code,wind_speed_180m,temperature_180m",
                        wind_speed_unit = "mph",
                        timeformat = "unixtime",
                        forecast_days = 7,
                    });


                    // we can save the weather data in the database 
                    //await _mediator.Send(new CreateWeatherDataCommand { WeatherDataDto = weatherData });

                    //now get the weather data from database.
                    //weatherData = await _mediator.Send(new GetHourlyWeatherDataQuery { latitude = latitude, longitude = longitude, unixtime = unixtime });
                }


                return Ok(weatherData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("daily")]
        public async Task<ActionResult<WeatherDataDto>> GetDailyWeather([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] int unixtime)
        {
            try
            {

                Console.WriteLine("Getting Daily Data from DB");
                var weatherData = await _mediator.Send(new GetDailyWeatherDataQuery { latitude = latitude, longitude = longitude, unixtime = unixtime });

                if (weatherData == null)
                {
                    weatherData = await _mediator.Send(new GetDailyWeatherDataFormOpenMeteoQuery
                    {
                        latitude = latitude,
                        longitude = longitude,
                        daily = "weather_code,temperature_2m_max,temperature_2m_min,rain_sum,wind_speed_10m_max",
                        timeformat = "unixtime",
                        forecast_days = 7,
                    });

                    //await _mediator.Send(new CreateWeatherDataCommand { WeatherDataDto = weatherData });

                    //now get the weather data from database.
                    //weatherData = await _mediator.Send(new GetDailyWeatherDataQuery { latitude = latitude, longitude = longitude, unixtime = unixtime });
                }


                return Ok(weatherData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

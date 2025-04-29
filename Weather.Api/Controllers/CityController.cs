using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.Api.DTOs;
using Weather.Api.Features.Cities.Commands;
using Weather.Api.Features.Cities.Queries;

namespace Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator mediator;

        public CityController(IMediator _mediator)
        {
            mediator = _mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<CityDto>>> GetByName([FromQuery]string name)
        {

            try
            {
                var cities = await mediator.Send(new GetCityByNameQuery { CityName = name });

                if (cities == null)
                {
                    // call API get all the cities based on cityName
                    var citiesFromExternalApi = await mediator.Send(new GetCityDataFromOpenMeteoQuery { CityName = name });

                    // save them to database
                    await mediator.Send(new CreateCityCommand { Cities = citiesFromExternalApi });

                    // get it from database
                    cities = await mediator.Send(new GetCityByNameQuery { CityName = name });
                }


                return Ok(cities);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

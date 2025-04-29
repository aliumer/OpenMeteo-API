using MediatR;
using System;
using Weather.Api.DTOs;
using Weather.Domain.Entities;
using Weather.ExternalServices.Wrapper;

namespace Weather.Api.Features.Cities.Queries
{
    public class GetCityDataFromOpenMeteoQuery : IRequest<List<City>>
    {
        public string CityName { get; set; } = string.Empty;
    }

    public class GetCityDataFromOpenMeteoHandler : IRequestHandler<GetCityDataFromOpenMeteoQuery, List<City>>
    {
        private readonly IWrapperApiService _wrapperApiService;
        public GetCityDataFromOpenMeteoHandler(IWrapperApiService wrapperApiService)
        {
            _wrapperApiService = wrapperApiService;
        }
        public async Task<List<City>> Handle(GetCityDataFromOpenMeteoQuery request, CancellationToken cancellationToken)
        {
            string url = $"?name={request.CityName}&count=3&language=en&format=json";
            var cityRequestInfo =  await _wrapperApiService.GetAsync<CityRequestInfo>("CityApi", url);
            return cityRequestInfo.results.ToList();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Constants;
using PhoneBook.Application.Domain.City.Requests.GetAll;
using PhoneBook.Application.Domain.City.Requests.GetAllCities;
using PhoneBook.Application.Domain.City.Requests.GetById;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    public class CityController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery(Name = QueryParameterNames.PageNumber)] int pageN, 
            [FromQuery(Name = QueryParameterNames.Records)] int? records, 
            string searchTerm)
        {
            return await ExecuteAsync<AppPageResult<GetAllCitiesResp>>(new GetAllCitiesReq(searchTerm));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteAsync<GetCityByIdResp>(new GetCityByIdReq(id));
        }
    }
}

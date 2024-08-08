using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Constants;
using PhoneBook.Api.DTO;
using PhoneBook.Api.Extensions;
using PhoneBook.Application.Common.Models;
using PhoneBook.Application.Domain.Person.Requests.Create;
using PhoneBook.Application.Domain.Person.Requests.GetAll;
using PhoneBook.Application.Domain.Person.Requests.GetById;
using PhoneBook.Application.Domain.Person.Requests.Update;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> SearchPerson(
              [FromQuery(Name = QueryParameterNames.PageNumber)] int pageN,
              [FromQuery(Name = QueryParameterNames.Records)] int? records,
              string searchTerm
            )
        {
            return await ExecuteAsync<AppPageResult<GetAllPersonResp>>(new GetAllPersonReq(searchTerm));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            return await ExecuteAsync<GetPersonByIdResp>(new GetPersonByIdReq(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromForm] CreatePersonDto dto)
        {
            var photoBytes = await dto.Photo?.GetFileBytesAsync();

            var data = new CreatePersonReqBody(
                dto.FirstName,
                dto.LastName,
                dto.Gender,
                dto.PersonalNumber,
                dto.CityId,
                new FileModel(dto.Photo.FileName, dto.Photo.ContentType, photoBytes)
            );

            return await ExecuteAsync(new CreatePersonReq(data));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonReqBody data)
        {
            return await ExecuteAsync(new UpdatePersonReq(data));
        }
    }
}

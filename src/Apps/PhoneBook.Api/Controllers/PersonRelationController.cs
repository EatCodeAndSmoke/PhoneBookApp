using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Domain.PersonRelation.Requests.Create;
using PhoneBook.Application.Domain.PersonRelation.Requests.Remove;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonRelationController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPersonRelationReqBody data)
        {
            return await ExecuteAsync(new AddPersonRelationReq(data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return await ExecuteAsync(new RemovePersonRelationReq(id));
        }
    }
}

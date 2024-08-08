using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Domain.PhoneNumber.Requests.Create;
using PhoneBook.Application.Domain.PhoneNumber.Requests.Remove;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    public class PhoneNumberController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(AddPhoneNumberReqBody data)
        {
            return await ExecuteAsync(new AddPhoneNumberReq(data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return await ExecuteAsync(new RemovePhoneNumberReq(id));
        }
    }
}

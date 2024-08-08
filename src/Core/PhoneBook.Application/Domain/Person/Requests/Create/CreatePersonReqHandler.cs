using Microsoft.Extensions.Hosting;
using PhoneBook.Application.Common.Models;
using PhoneBook.Application.Domain.Person.Constants;
using PhoneBook.Core;
using PhoneBook.Core.RequestBus;

namespace PhoneBook.Application.Domain.Person.Requests.Create
{
    public class CreatePersonReqHandler : AppRequestHandler<CreatePersonReq>
    {
        private readonly IPersonRepository _personRepo;
        private readonly IHostEnvironment _enviroment;

        public CreatePersonReqHandler(IServiceProvider services, IPersonRepository personRepo, IHostEnvironment enviroment) : base(services)
        {
            _personRepo = personRepo;
            _enviroment = enviroment;
        }

        public override async ValueTask<AppOutput> HandleAsync(CreatePersonReq input, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if(await _personRepo.ExistsByPersonalIdAsync(input.Body.PersonalNumber))
                return BadRequest(PersonErrorCodes.AlreadyExists);

            var filePath = await UploadFileAsync(input.Body.File, cancellationToken);
            var entity = GetPersonEntity(input, filePath);
            await UnitOfWork.AddAsync(entity, cancellationToken);
            return Ok();
        }

        private async Task<string> UploadFileAsync(FileModel file, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var path = Path.Combine(_enviroment.ContentRootPath, "wwwroot", "PersonPhotoes", $"{Guid.NewGuid()}-{file.FileName}");
            await File.WriteAllBytesAsync(path, file.FileBytes, cancellationToken);
            return path;
        }

        private static PersonEntity GetPersonEntity(CreatePersonReq input, string photoUrl)
        {
            return new PersonEntity
            {
                FirstName = input.Body.FirstName,
                LastName = input.Body.LastName,
                Gender = input.Body.Gender,
                PersonalNumber = input.Body.PersonalNumber,
                PhotoUrl = photoUrl,
                CityId = input.Body.CityId,
                CreatedAt = DateTimeOffset.UtcNow,
                SearchTerm = $"{input.Body.FirstName} {input.Body.LastName} {input.Body.PersonalNumber}",
                CorrelationId = input.CorrelationId,
            };
        }
    }
}

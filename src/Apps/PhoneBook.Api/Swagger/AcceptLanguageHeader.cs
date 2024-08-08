using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using PhoneBook.Api.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PhoneBook.Api.Swagger
{
    public class AcceptLanguageHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= [];

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = HeaderNames.AcceptLanguage,
                In = ParameterLocation.Header,
                Required = false
            });
        }
    }
}

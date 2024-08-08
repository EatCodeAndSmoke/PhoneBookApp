using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using PhoneBook.Api.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PhoneBook.Api.Swagger
{
    public class CorrelationIdHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= [];

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = HttpHeaderNames.CorrelationId,
                In = ParameterLocation.Header,
                Required = false
            });
        }
    }
}

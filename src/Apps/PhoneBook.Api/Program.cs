using Microsoft.Extensions.Options;
using PhoneBook.Api.Middlewares;
using PhoneBook.Api.Swagger;
using PhoneBook.DependencyInjection.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.OperationFilter<AcceptLanguageHeader>();
    x.OperationFilter<CorrelationIdHeader>();
    x.SchemaFilter<EnumFilter>();
});

builder.Services.AddPhoneBook(x => x.AddDefaultServices(builder.Configuration));


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseMiddleware<HttpHeaderMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();

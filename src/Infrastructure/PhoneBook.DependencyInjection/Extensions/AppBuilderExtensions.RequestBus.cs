using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Domain.City;
using PhoneBook.Core.RequestBus;
using PhoneBook.Core.RequestBus.Pipelines;

namespace PhoneBook.DependencyInjection.Extensions
{
    public static partial class AppBuilderExtensions
    {
        public static PhoneBookAppBuilder AddRequestBus(this PhoneBookAppBuilder builder)
        {
            builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CityEntity).Assembly));
            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AppLocalizationPipe<,>));
            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AppErrorHandlerPipe<,>));
            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AppValidationPipe<,>));
            builder.Services.AddScoped<IAppRequestBus, AppRequestBus>();
            return builder;
        }
    }
}

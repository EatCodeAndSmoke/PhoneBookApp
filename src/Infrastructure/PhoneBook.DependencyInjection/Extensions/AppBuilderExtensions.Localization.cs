using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Localization;
using PhoneBook.Infrastructure.Localization;

namespace PhoneBook.DependencyInjection.Extensions
{
    public static partial class AppBuilderExtensions
    {
        public static PhoneBookAppBuilder AddLocalization(this PhoneBookAppBuilder appBuilder)
        {
            appBuilder.Services.AddScoped<IAppTranslator, AppTranslator>();
            return appBuilder;
        }
    }
}

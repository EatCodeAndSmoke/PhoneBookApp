using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Cacheing;
using PhoneBook.Infrastructure.Cacheing;

namespace PhoneBook.DependencyInjection.Extensions
{
    public static partial class AppBuilderExtensions
    {
        public static PhoneBookAppBuilder AddCacheing(this PhoneBookAppBuilder appBuilder)
        {
            appBuilder.Services.AddMemoryCache();
            appBuilder.Services.AddSingleton<IAppCache, AppCache>();
            return appBuilder;
        }
    }
}

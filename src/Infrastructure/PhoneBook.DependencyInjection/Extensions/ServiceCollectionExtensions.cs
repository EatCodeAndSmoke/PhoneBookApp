using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPhoneBook(this IServiceCollection services, Action<PhoneBookAppBuilder> action)
        {
            ArgumentNullException.ThrowIfNull(nameof(action));
            var appBuilder = new PhoneBookAppBuilder(services);
            action(appBuilder);
            return services;
        }
    }
}

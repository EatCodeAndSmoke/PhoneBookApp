using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DependencyInjection.Extensions
{
    public static partial class AppBuilderExtensions
    {
        public static PhoneBookAppBuilder AddDefaultServices(this PhoneBookAppBuilder appBuilder, IConfiguration config)
        {
            appBuilder.AddDAL(config)
                      .AddRequestBus()
                      .AddCacheing()
                      .AddLocalization();

            return appBuilder;
        }
    }
}

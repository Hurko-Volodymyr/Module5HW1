using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module5HW1.Config;
using Module5HW1.Services;
using Module5HW1.Services.Abstractions;

namespace Module5HW1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                         .AddJsonFile("config.json")
                         .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            await app!.Start();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddHttpClient()
                .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IResourceService, ResourceService>()
                .AddTransient<IAutorizeService, AutorizeService>()
                .AddTransient<App>();
        }
    }
}
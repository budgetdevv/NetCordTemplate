using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NetCordTemplate.HostedServices
{
    public interface ICustomHostedService: IHostedService
    {
        public static abstract ValueTask Register(IServiceCollection services);

        public static async Task RegisterServices(IServiceCollection collection)
        {
            var type = typeof(ICustomHostedService);

            var services = type.Assembly
                .GetTypes()
                .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && x != type);

            const BindingFlags FLAGS = BindingFlags.Public | BindingFlags.Static;
            
            foreach (var service in services)
            {
                Console.WriteLine($"Registering {service.Name}");

                var method = service.GetMethod(nameof(Register), FLAGS)!;

                await method.CreateDelegate<Func<IServiceCollection, ValueTask>>()(collection);
            }
        }
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace NetCordTemplate.HostedServices
{
    public sealed class SampleHostedService2: ICustomHostedService
    {
        public static ValueTask Register(IServiceCollection services)
        {
            services.AddSingleton<SampleHostedService2>();
            return ValueTask.CompletedTask;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine(nameof(SampleHostedService2));
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

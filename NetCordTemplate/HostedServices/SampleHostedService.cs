using Microsoft.Extensions.DependencyInjection;

namespace NetCordTemplate.HostedServices
{
    public sealed class SampleHostedService: ICustomHostedService
    {
        public static ValueTask Register(IServiceCollection services)
        {
            services.AddSingleton<SampleHostedService>();
            return ValueTask.CompletedTask;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine(nameof(SampleHostedService));
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

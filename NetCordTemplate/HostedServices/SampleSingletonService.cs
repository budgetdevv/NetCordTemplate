using Microsoft.Extensions.DependencyInjection;

namespace NetCordTemplate.HostedServices
{
    public sealed class SampleSingletonService: ICustomService
    {
        public static ValueTask Register(IServiceCollection services)
        {
            services.AddSingleton<SampleSingletonService>();
            return ValueTask.CompletedTask;
        }
    }
}

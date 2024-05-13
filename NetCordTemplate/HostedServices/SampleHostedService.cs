using Microsoft.Extensions.Hosting;

namespace NetCordTemplate.HostedServices
{
    public class SampleHostedService: IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello world!");
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

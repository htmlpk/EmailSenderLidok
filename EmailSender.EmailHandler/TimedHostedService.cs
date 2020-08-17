using EmailSender.BLL.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmailSender.EmailHandler
{
    public class ConsumeScopedServiceHostedService : BackgroundService
    {

        public ConsumeScopedServiceHostedService(IServiceProvider services)
        {
            Services = services;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IEmailService>();

                await scopedProcessingService.ResetFailedEmails();
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = Services.CreateScope())
                {
                    IServiceProvider serviceProvider = scope.ServiceProvider;
                    var service = serviceProvider.GetRequiredService<IScopedProcessingService>();
                    await service.DoWork(stoppingToken);
                }
                //Add a delay between executions.
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }
    }
}



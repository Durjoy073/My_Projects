using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1
{
    internal class Userservices : BackgroundService
    {
        private readonly ILogger<Userservices> logger;
        public Userservices(ILogger<Userservices> _logger)
        { 
        this.logger = _logger;
        
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while(!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Execution Started");
                try
                {
                    Console.WriteLine("Service running");
                }
                catch(Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                }
                await Task.Delay(1000, stoppingToken);
            }


        }


        public override Task StartAsync(CancellationToken cancellationToken)
        { 
            logger.LogInformation("Service Started");
            return base.StartAsync(cancellationToken);
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Service Stopped");
            return base.StopAsync(cancellationToken);
        }



    }
}

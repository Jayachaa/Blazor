namespace ExploreHttpContext
{
    public class HostedService: IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HostedService - app started: time - " + DateTime.Now);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HostedService - app stopped: time - " + DateTime.Now);

            return Task.CompletedTask;
        }
    }

    public class HostLifetimeService : IHostLifetime
    {
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HostLifetimeService - app started: time - " + DateTime.Now);
            return Task.CompletedTask;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HostLifetimeService - app stopped: time - " + DateTime.Now);

            return Task.CompletedTask;
        }
    }
}

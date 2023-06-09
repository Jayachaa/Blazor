namespace ExploreHttpContext;

public class HostLifetimeService : IHostLifetime
{
	#region Publics
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
	#endregion
}
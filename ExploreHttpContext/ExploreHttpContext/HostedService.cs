namespace ExploreHttpContext
{
	public class HostedService : IHostedService
	{
		#region Publics
		public Task StartAsync(CancellationToken cancellationToken)
		{
			Console.WriteLine("HostedService - app started: time - " + DateTime.Now);

			WaitHostToStart();

			Console.WriteLine("HostedService - app started: waited time - " + DateTime.Now);
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			Console.WriteLine("HostedService - app stopped: time - " + DateTime.Now);

			return Task.CompletedTask;
		}
		#endregion

		#region Privates
		private static void WaitHostToStart()
		{
			Thread.Sleep(5000);
		}
		#endregion
	}
}
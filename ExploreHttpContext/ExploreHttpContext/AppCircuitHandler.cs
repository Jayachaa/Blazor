using Microsoft.AspNetCore.Components.Server.Circuits;

namespace ExploreHttpContext
{
	public class AppCircuitHandler : CircuitHandler
	{
		#region Publics
		public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
		{
			SessionStart();

			return base.OnConnectionUpAsync(circuit, cancellationToken);
		}

		public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
		{
			SessionEnd();

			return base.OnConnectionDownAsync(circuit, cancellationToken);
		}
		#endregion

		#region Privates
		private void SessionStart()
		{
			Console.WriteLine("AppCircuitHandler - Circuit started: time - " + DateTime.Now);
			//HttpApplication.Session_Start();
		}

		private void SessionEnd()
		{
			Console.WriteLine("AppCircuitHandler - Circuit closed: time - " + DateTime.Now);
			//HttpApplication.Session_End();
		}
		#endregion
	}
}
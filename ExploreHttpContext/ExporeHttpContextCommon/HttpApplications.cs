namespace ExploreHttpContextCommon
{
	public class HttpApplications
	{
		#region Publics
		public static void Application_Start()
		{
			Console.WriteLine("App (app.Lifetime) started: time - " + DateTime.Now);
		}

		public static void Application_End()
		{
			Console.WriteLine("App (app.Lifetime) Ended: time - " + DateTime.Now);
		}
		#endregion
	}
}
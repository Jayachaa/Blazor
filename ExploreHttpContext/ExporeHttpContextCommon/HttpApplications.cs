namespace ExploreHttpContextCommon
{
	public class HttpApplications
	{
		#region Publics
		public static void Application_Start()
		{
			Console.WriteLine("App started: time - " + DateTime.Now);
		}

		public static void Application_End()
		{
			Console.WriteLine("App Ended: time - " + DateTime.Now);
		}
		#endregion
	}
}
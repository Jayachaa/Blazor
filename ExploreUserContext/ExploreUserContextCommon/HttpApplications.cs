using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreUserContextCommon
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

        public static void Session_Start()
        {
            Console.WriteLine("Session started: time - " + DateTime.Now);
        }

        public static void Session_End()
        {
            Console.WriteLine("Session Ended: time - " + DateTime.Now);
        }
        #endregion
    }
}

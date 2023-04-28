using Microsoft.AspNetCore.Http;

namespace ExploreUserContextCommon
{
    public class HttpContextAccessors
    {
        private static HttpContext? s_current;

        #region Properties
        public static HttpContext? Current
        {
            get => s_current;
            set => s_current = value;
        }
        #endregion
    }
}
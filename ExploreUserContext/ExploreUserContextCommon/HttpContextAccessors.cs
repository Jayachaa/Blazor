using Microsoft.AspNetCore.Http;

namespace ExploreUserContextCommon
{
    public class HttpContextAccessors
    {
        #region Properties
        public static HttpContext? Current { get; set; }
        #endregion
    }
}
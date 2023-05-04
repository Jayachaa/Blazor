// https://www.strathweb.com/2016/12/accessing-httpcontext-outside-of-framework-components-in-asp-net-core/

using Microsoft.AspNetCore.Http;

namespace ExploreUserContextCommon
{
    public class HttpContextAccessors
    {
        #region Fields
        private static IHttpContextAccessor? _contextAccessor;
        #endregion

        #region Properties
        public static HttpContext? Current => _contextAccessor?.HttpContext;
        #endregion

        #region Publics
        public static void Configure(IHttpContextAccessor? contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        #endregion
    }
}
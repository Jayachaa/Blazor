using ExploreHttpContextCommon;

namespace ExploreHttpContext
{
	public class HttpContextMiddleware
	{
		#region Fields
		private readonly RequestDelegate _next;
        private readonly IHttpContextAccessorCommon _contextAccessor;

        #endregion

        #region Constructors
        public HttpContextMiddleware(RequestDelegate next, IHttpContextAccessorCommon contextAccessor)
		{
			_next = next;
            _contextAccessor= contextAccessor;

        }
		#endregion

		#region Publics
		public async Task Invoke(HttpContext? httpContext)
        {
            //HttpContextAccessorCommon httpContextAccessorCommon = new HttpContextAccessorCommon();
            //httpContextAccessorCommon.Current = httpContext;
            _contextAccessor.Current = httpContext;

            await _next(httpContext);
		}
		#endregion
	}

	public static class CustomHttpContextMiddlewareExtensions
	{
		#region Publics
		public static IApplicationBuilder UseHttpContextMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<HttpContextMiddleware>();
		}
		#endregion
	}
}
using Microsoft.AspNetCore.Http;

namespace ExploreHttpContextCommon
{
    public interface IHttpContextAccessorCommon
    {
        HttpContext Current { get; set; }
    }

    public class HttpContextAccessorCommon : IHttpContextAccessorCommon
    {
        #region Fields
        //private static HttpContext? _context;
        private HttpContext? _context;
        #endregion

        #region Properties
        public HttpContext Current
        {
            get
            {
                if(_context == null) throw new Exception("No context");

                return _context;
            }
            set => _context = value;
        }
        #endregion
    }
}
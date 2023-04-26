using Microsoft.AspNetCore.Http;

namespace ExploreHttpContextCommon
{
    public class UserContext
    {
        #region Constants
        public const string CALLCONTEXT_USER = "User";
        #endregion

        #region Fields
        private readonly IHttpContextAccessorCommon _httpContextAccessorCommon;
        #endregion

        #region Properties
        public User UserInfo
        {
            get
            {
                HttpContext context = _httpContextAccessorCommon.Current;
                User? userInfo = CallContext.GetData(CALLCONTEXT_USER) as User;

                if(context != null && userInfo == null)
                {
                    userInfo = context.Items[CALLCONTEXT_USER] as User;
                    if(userInfo != null)
                    {
                        CallContext.SetData(CALLCONTEXT_USER, userInfo);
                    }
                }

                return userInfo ?? new User();
            }
            set
            {
                if(value != null)
                {
                    CallContext.SetData(CALLCONTEXT_USER, value);
                }
                else
                {
                    CallContext.FreeNamedDataSlot(CALLCONTEXT_USER);
                }

                HttpContext context = _httpContextAccessorCommon.Current;
                if(context != null)
                {
                    context.Items[CALLCONTEXT_USER] = value;
                }
            }
        }
        #endregion

        #region Constructors
        public UserContext(IHttpContextAccessorCommon httpContextAccessorCommon)
        {
            _httpContextAccessorCommon = httpContextAccessorCommon;
        }
        #endregion
    }

    public class User
    {
        #region Properties
        public string Name { get; set; } = "A";
        public string FirstName { get; set; } = "B";
        #endregion
    }
}
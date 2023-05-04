using Microsoft.AspNetCore.Http;

namespace ExploreHttpContextCommon
{
    public interface IUserContext
    {
        User UserInfo { get; set; }
    }

    public class UserContext : IUserContext
    {
        #region Constants
        public const string CALLCONTEXT_USER = "User";
        #endregion

        #region Fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Properties
        public User UserInfo
        {
            get
            {
                HttpContext context = _httpContextAccessor.HttpContext;
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

                HttpContext context = _httpContextAccessor.HttpContext;
                if(context != null)
                {
                    context.Items[CALLCONTEXT_USER] = value;
                }
            }
        }
        #endregion

        #region Constructors
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
    }

    public class User
    {
        #region Properties
        public string Name { get; set; } = "";
        public string FirstName { get; set; } = "";
        #endregion
    }
}
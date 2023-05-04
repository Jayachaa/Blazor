using Microsoft.AspNetCore.Http;

namespace ExploreUserContextCommon
{
    public class UserContext
    {
        #region Constants
        public const string CALLCONTEXT_USER = "User";
        #endregion

        #region Properties
        public static User Current
        {
            get
            {
                HttpContext? context = HttpContextAccessors.Current;
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

                HttpContext? context = HttpContextAccessors.Current;
                if(context != null)
                {
                    context.Items[CALLCONTEXT_USER] = value;
                }
            }
        }
        #endregion
    }

    public class User
    {
        #region Properties
        public string Name { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string EMail { get; set; } = "A";
        public string Password { get; set; } = "";
        #endregion
    }
}
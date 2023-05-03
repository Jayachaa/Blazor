using ExploreHttpContextCommon;

namespace ExploreHttpContextLogic
{
    public class Authenticator: IAuthenticator
    {
        public string GetAuthenticationInfo(IUserContext userContext)
        {
            return string.IsNullOrEmpty(userContext.UserInfo.Name) ? 
                $"Hi, you are not authenticated!!!" : 
                $"Hi `{userContext.UserInfo.Name}`, you are authenticated!!!";
        }
    }
}
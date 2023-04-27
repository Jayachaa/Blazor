using ExploreHttpContextCommon;

namespace ExploreHttpContextLogic
{
    public class Authenticator: IAuthenticator
    {
        public string GetAuthenticationInfo(IUserContext userContext)
        {
            return $"Hi `{userContext.UserInfo.Name}`, you are authenticated!!!";
        }
    }
}
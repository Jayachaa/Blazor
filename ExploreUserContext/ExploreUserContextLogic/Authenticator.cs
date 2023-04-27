using ExploreUserContextCommon;

namespace ExploreUserContextLogic
{
    public class Authenticator : IAuthenticator
    {
        #region Publics
        public string GetAuthenticationInfo()
        {
            return $"Hi '{UserContext.Current.Name}', you are authenticated!!!";
        }
        #endregion
    }
}
namespace ExploreHttpContextCommon.Logic
{
    public interface IAuthenticator
    {
        string GetAuthenticationInfo(IUserContext userContext);
    }
}
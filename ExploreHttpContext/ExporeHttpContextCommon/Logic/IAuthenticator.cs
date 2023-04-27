namespace ExploreHttpContextCommon
{
    public interface IAuthenticator
    {
        string GetAuthenticationInfo(IUserContext userContext);
    }
}
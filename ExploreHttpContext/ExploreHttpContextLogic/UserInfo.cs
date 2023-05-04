using ExploreHttpContextCommon;

namespace ExploreHttpContextLogic
{
    public class UserInfo : IUserInfo
    {
        #region Fields
        private readonly IUserContext _user;
        #endregion

        #region Constructors
        public UserInfo(IUserContext user)
        {
            _user = user;
        }
        #endregion

        #region Publics
        public string GetUserFirstName()
        {
            return string.IsNullOrEmpty(_user.UserInfo.FirstName) ? "Hi, user context is not valid!!!" : $"User's first name: `{_user.UserInfo.FirstName}`.";
        }
        #endregion
    }
}
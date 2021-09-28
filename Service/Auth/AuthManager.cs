using Service.Auth.Token;
using System.Security.Principal;

namespace Service.Auth
{
    public class AuthManager<T> : IAuthManager
        where T : class, ITokenManager
    {
        protected ITokenManager _tokenManager;
        public AuthManager(T tokenService)
        {
            this._tokenManager = tokenService;
        }

        public string Login(string userid, string username = "", string deviceName = "", string deviceID = "", string certificateId = "")
        {
            var token = this._tokenManager.Generate(userid, username, deviceName, deviceID, certificateId);
            return token;
        }

        public IIdentity ValidateToken(string token, string deviceName = "", string deviceID = "")
        {
            var user = new SE.Auth.User();
            return this._tokenManager.Validate(out user, token, deviceName, deviceID);
        }
    }
}

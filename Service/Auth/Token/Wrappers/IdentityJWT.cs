using SE.Auth;
using System.Security.Principal;

namespace Service.Auth.Token.Wrappers
{
    public class IdentityJWT : IdentityWrapper<User>, IIdentity
    {
        public IdentityJWT(User user)
        {
            base.SetModel(user);
        }
        public override string AuthenticationType => typeof(JWT).Name;
        public override string Name => this.Model.UserID;
        public override string Token => this._token;
        protected string _token;
        public IdentityJWT SetToken(string token)
        {
            this._token = token;
            return this;
        }

    }
}
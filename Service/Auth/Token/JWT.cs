using Microsoft.EntityFrameworkCore;
using SE.Auth;
using SE.Auth.AuthMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Service.Auth.Token.Wrappers;

namespace Service.Auth.Token
{
    public class JWT : ITokenManager
    {
        protected const string ISSUER = "api.SaintEir.JWT";
        protected IAuthMethod _authMethod;

        public JWT()
        {
            this._authMethod = SE.Auth.TokenManager.Create(JWT.ISSUER);
        }

        public string Generate(
            string userid,
            string username,
            string deviceName = "",
            string deviceID = "",
            string certificateId = "")
        {
            var token = this._authMethod.GenerateToken(x => x
            .SetPayload(new User
            {
                UserID = userid,
                UserName = username
            })
            .SetAudience(deviceID)
            .SetExpiredDate(TimeSpan.FromHours(18)));
            return token;
        }

        public IIdentity Validate(
            out User user,
            string token,
            string deviceName = "",
            string deviceID = "")
        {
            //SE.Auth.User user2;
            var res = this._authMethod.ValidateToken(token, out user, x => x
                .ValidAudience(deviceID)
                .ValidIssuer(false)
                .ValidExpiredDate(false));

            if (res)
            {
                return new IdentityJWT(user)
                    .SetToken(token)
                    .SeIsAuthenticated(true);
            }
            else
            {
                return null;
            }
        }
    }
}

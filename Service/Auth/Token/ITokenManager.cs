using Microsoft.EntityFrameworkCore;
using SE.Auth;
using System.Security.Principal;

namespace Service.Auth.Token
{
    public interface ITokenManager
    {
        string Generate(
            string userid,
            string username,
            string deviceName = "",
            string deviceID = "",
            string certificateId = "");

        IIdentity Validate(
            out User user,
            string token,
            string deviceName = "",
            string deviceID = "");
    }
}
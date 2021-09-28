using System.Security.Principal;

namespace Service.Auth
{
    public interface IAuthManager
    {
        /// <summary>
        /// 簽發Token
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns>Token</returns>
        string Login(string userid, string username = "", string deviceName = "", string deviceID = "", string certificateId = "");

        /// <summary>
        /// 驗證Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        IIdentity ValidateToken(string token, string deviceName = "", string deviceID = "");
    }

}

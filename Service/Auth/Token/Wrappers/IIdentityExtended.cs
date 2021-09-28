using System.Security.Principal;

namespace Service.Auth.Token.Wrappers
{
    public interface IIdentityExtended : IIdentity
    {
        string Token { get; }
    }
}

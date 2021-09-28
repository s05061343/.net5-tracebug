using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Service.Auth.Token.Wrappers
{
    public interface IIdentityWrapper<T> : IIdentity
        where T : class, new()
    {
        IIdentityWrapper<T> SetModel(T model);
        IIdentityWrapper<T> SeIsAuthenticated(bool IsAuthenticated);
    }
}

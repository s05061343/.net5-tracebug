using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Service.Auth.Token.Wrappers
{
    public class Principal : IPrincipal
    {
        protected IIdentity _identity;
        public Principal(IIdentity identity)
        {
            _identity = identity;
        }
        public IIdentity Identity => _identity;
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Service.Auth.Token.Wrappers
{
    public abstract class IdentityWrapper<T> : IIdentityWrapper<T>, IIdentityExtended
        where T : class, new()
    {
        protected string _name;
        protected bool _isAuthenticated;
        protected T _model;
        public T Model => _model;
        public abstract string Name { get; }
        public abstract string AuthenticationType { get; }
        public abstract string Token { get; }
        public bool IsAuthenticated => _isAuthenticated;
        
        public IIdentityWrapper<T> SeIsAuthenticated(bool IsAuthenticated)
        {
            this._isAuthenticated = IsAuthenticated;
            return this;
        }
        public virtual IIdentityWrapper<T> SetModel(T model)
        {
            this._model = model;
            return this;
        }
    }



}
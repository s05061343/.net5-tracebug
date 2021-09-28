using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using Service.Auth;
using Service.Auth.Token.Wrappers;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Web.Filters
{
    [Flags]
    public enum TokenFrom
    {
        none = 0,
        Cookie = 1 << 0,
        JSON = 1 << 1,
        Form = 1 << 2,
        Header = 1 << 3,
        All = Cookie | JSON | Form | Header
    }

    public abstract class AuthorizationFilterBase : ActionFilterAttribute, IAuthorizationFilter
    {
        protected IAuthManager _authManager { get; set; }
        protected List<(Func<TokenFrom, bool> matchSource, Func<HttpContext, string> extrator)> _extrators;

        public AuthorizationFilterBase()
        {
            this._extrators = InitExtrators();
        }

        public List<(Func<TokenFrom, bool> tokenSource, Func<HttpContext, string> extrator)> InitExtrators() => new List<(Func<TokenFrom, bool> tokenSource, Func<HttpContext, string> extrator)>
        {
            (from => from.HasFlag(TokenFrom.Cookie),this.Cookie),
            (from => from.HasFlag(TokenFrom.Header),this.Header)
        };

        public TokenFrom AuthTokenFrom { get; set; }
        protected const string _KEY_TOKEN = "AuthToken";
        protected const string _KEY_AUTHORIZATION = "Authorization";
        protected IPrincipal BuildPrincipal(string token) => new Principal(this._authManager.ValidateToken(token));
        protected virtual string ExtractToken(HttpContext context, TokenFrom from = TokenFrom.All)
        {
            try
            {
                var token = this._extrators
                    .Where(x => x.matchSource(from))
                    .Select(x => this.ExtraIgnoreException(context, x.extrator))
                    .Where(x => !string.IsNullOrEmpty(x))
                    .First();
                return token;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
        }

        protected virtual string ExtraIgnoreException(HttpContext context, Func<HttpContext, string> expression)
        {
            try { return expression(context); }
            catch { return ""; }
        }

        protected virtual string Cookie(HttpContext context)
        {
            return context.Request.Cookies[AuthorizationFilter._KEY_TOKEN];
        }

        protected virtual string Header(HttpContext context)
        {
            var authorization = context.Request.Headers[AuthorizationFilter._KEY_AUTHORIZATION];
            var pattern = @"^(?<header>[a-zA-Z]{9})\s{1}(?<No>.*)$";
            var match = Regex.Match(authorization, pattern);
            var token = match.Groups["No"].ToString();
            return token;
        }

        public bool HasAllowAnonymous(AuthorizationFilterContext context) => context.Filters.Any(item => item is IAllowAnonymousFilter);

        public abstract void OnAuthorization(AuthorizationFilterContext context);
    }
}
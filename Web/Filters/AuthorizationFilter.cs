using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Auth;
using System;
using System.Security.Claims;

namespace Web.Filters
{
    public class AuthorizationFilter : AuthorizationFilterBase, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            if (this.HasAllowAnonymous(context))
            {
                return;
            }
            try
            {
                this._authManager = (context.HttpContext.RequestServices.GetService(typeof(IAuthManager))) as IAuthManager;
                var token = this.ExtractToken(context.HttpContext, this.AuthTokenFrom = TokenFrom.All);
                context.HttpContext.User = new ClaimsPrincipal(this.BuildPrincipal(token));
                return;
            }
            catch (InvalidOperationException)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            catch (Exception)
            {
                context.Result = new BadRequestResult();
                return;
            }
        }
    }
}

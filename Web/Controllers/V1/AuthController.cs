using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Auth;
using Web.ModelBinding.Auth;
using Web.ModelBinding.Attributes;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Web.Request;
using System.Linq;

namespace Web.Controllers.V1
{
    [ApiController]
    [Route("[controller]/v1/[action]")]
    public class AuthController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly string _version = typeof(AuthController).Namespace.Split('.').LastOrDefault();
        public AuthController(ILogger<AuthController> logger)
        {
            this._logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(
            [FromServices] DbContext dbContext,
            [FromServices] IAuthManager authService,
            [ModelBinder(typeof(RequestBodyBinding))] AuthLoginRequest request)
        {
            var token = authService.Login(request.userId);
            var vo = dbContext.Set<Model.Sqlite.LoginUser>().Find(request.userId);
            var roles = dbContext.Set<Model.Sqlite.RoleType>().ToList();
            if (vo != null)
            {
                Response.Cookies.Append("AuthToken", token);
                return this.Ok(new
                {
                    varsion = _version,
                    userId = vo.UserId,
                    password = vo.Password,
                    name = vo.Name,
                    roleNo = vo.RoleNo,
                    role = roles.Where(p => p.Id == vo.RoleNo).Any() ? roles.Where(p => p.Id == vo.RoleNo).FirstOrDefault().Name : string.Empty,
                    authToken = token
                });
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}

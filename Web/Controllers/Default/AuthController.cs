using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Auth;
using Web.ModelBinding.Auth;
using Web.Request;
using System.Linq;
using SainteirAPI.Validations;
using Web.Vaildations.Auth;
using Web.ModelBinding.Attributes;
using Microsoft.AspNetCore.Http;

namespace Web.Controllers.Default
{
    [ApiController]
    [Route("[controller]/default/[action]")]
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
            [FromServices] IAuthManager authService,
            [ModelBinder(typeof(RequestBodyBinding))] AuthLoginRequest request)
        {
            var token = authService.Login(request.userId);
            return this.Ok(new
            {
                varsion = _version,
                userId = request.userId,
                authToken = token
            });
        }

        [HttpPost]
        public IActionResult CookieLogin(
            [FromServices] IAuthManager authService,
            [FromServices] IHttpContextAccessor contextAccessor)
        {
            var user = contextAccessor.HttpContext.User;
            var token = authService.Login(user.Identity.Name);
            return this.Ok(new
            {
                identity = user.Identity,
                token = token
            });
        }

        [HttpPost]
        public IActionResult Query(
            [FromServices] DbContext dbContext,
            [ValidateRequest(Validator = typeof(IAuthRequestValidator))]
            [ModelBinder(typeof(AuthQuseryBinder))] AuthLoginRequest request)
        {
            var vo = dbContext.Set<Model.Sqlite.SQLiteContext>().Find(request.userId);
            return this.Ok(new
            {
                varsion = _version,
                request = request,
                vo = vo
            });
        }
    }
}

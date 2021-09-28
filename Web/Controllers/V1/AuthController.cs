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
            [FromServices] IAuthManager authService,
            [ModelBinder(typeof(RequestBodyBinding))] string userId,
            [ModelBinder(typeof(RequestBodyBinding))] string password,
            [ModelBinder(typeof(RequestBodyBinding))] List<IFormFile> imageset)
        {
            var token = authService.Login(userId);
            return this.Ok(new
            {
                varsion = _version,
                userId = userId,
                password = password,
                imageset = imageset,
                authToken = token
            });
        }

        [HttpPost]
        public IActionResult Query(
            [FromServices] DbContext dbContext,
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.TaskForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.ModelBinding.Attributes;

namespace Web.Controllers.V1
{
    [ApiController]
    [Route("[controller]/v1/[action]")]
    public class TaskController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly string _version = typeof(AuthController).Namespace.Split('.').LastOrDefault();
        public TaskController(ILogger<AuthController> logger)
        {
            this._logger = logger;
        }

        public class QueryRequest
        {
            [Required]
            public string userId { get; set; }
        }

        public class CTaskForm
        {
            public int Id { get; set; }
            public int Type { get; set; }
            public string TypeName { get; set; }
            public int BelongToProgress { get; set; }
            public string BelongToProgressName { get; set; }
            public string Name { get; set; }
            public string BelongToLoginUser { get; set; }
            public string BelongToLoginUserName { get; set; }
            public string Description { get; set; }
            public DateTime? CreateDate { get; set; }
            public string CreateBy { get; set; }
            public string CreateByName { get; set; }
            public DateTime? UpdateDate { get; set; }
            public string UpdateBy { get; set; }
            public string UpdateByName { get; set; }
        }

        [HttpPost]
        public IActionResult Query(
            [FromServices] ITaskFormService _service,
            [FromServices] DbContext _dbContext,
            [FromBody] QueryRequest request)
        {
            var plist = _dbContext.Set<Model.Sqlite.ProgressType>().ToList();
            var users = _dbContext.Set<Model.Sqlite.LoginUser>().ToList();
            var types = _dbContext.Set<Model.Sqlite.FormType>().ToList();

            _service.SetBelongUser(request.userId);
            _service.SetAsignUser(null);
            var belong = new List<CTaskForm>();
            _service.Query().ToList()
                .ForEach(p =>
                {
                    belong.Add(new CTaskForm
                    {
                        Id = p.Id,
                        Type = p.Type,
                        TypeName = types.Where(e => e.Id == p.Type).Any() ?
                        types.Where(e => e.Id == p.Type).FirstOrDefault().Name : "",
                        BelongToProgress = p.BelongToProgress,
                        BelongToProgressName = plist.Where(e => e.Id == p.BelongToProgress).Any() ?
                        plist.Where(e => e.Id == p.BelongToProgress).FirstOrDefault().Name : "",
                        Name = p.Name,
                        BelongToLoginUser = p.BelongToLoginUser,
                        BelongToLoginUserName = users.Where(e => e.UserId == p.BelongToLoginUser).Any() ?
                        users.Where(e => e.UserId == p.BelongToLoginUser).FirstOrDefault().Name : "",
                        Description = p.Description,
                        CreateDate = p.CreateDate,
                        CreateBy = p.CreateBy,
                        CreateByName = users.Where(e => e.UserId == p.CreateBy).Any() ?
                        users.Where(e => e.UserId == p.CreateBy).FirstOrDefault().Name : "",
                        UpdateDate = p.UpdateDate,
                        UpdateBy = p.UpdateBy,
                        UpdateByName = users.Where(e => e.UserId == p.UpdateBy).Any() ?
                        users.Where(e => e.UserId == p.UpdateBy).FirstOrDefault().Name : "",
                    });
                });

            _service.SetBelongUser(null);
            _service.SetAsignUser(request.userId);
            var asign = new List<CTaskForm>();
            _service.Query().ToList()
                .ForEach(p =>
                {
                    asign.Add(new CTaskForm
                    {
                        Id = p.Id,
                        Type = p.Type,
                        TypeName = types.Where(e => e.Id == p.Type).Any() ?
                        types.Where(e => e.Id == p.Type).FirstOrDefault().Name : "",
                        BelongToProgress = p.BelongToProgress,
                        BelongToProgressName = plist.Where(e => e.Id == p.BelongToProgress).Any() ?
                        plist.Where(e => e.Id == p.BelongToProgress).FirstOrDefault().Name : "",
                        Name = p.Name,
                        BelongToLoginUser = p.BelongToLoginUser,
                        BelongToLoginUserName = users.Where(e => e.UserId == p.BelongToLoginUser).Any() ?
                        users.Where(e => e.UserId == p.BelongToLoginUser).FirstOrDefault().Name : "",
                        Description = p.Description,
                        CreateDate = p.CreateDate,
                        CreateBy = p.CreateBy,
                        CreateByName = users.Where(e => e.UserId == p.CreateBy).Any() ?
                        users.Where(e => e.UserId == p.CreateBy).FirstOrDefault().Name : "",
                        UpdateDate = p.UpdateDate,
                        UpdateBy = p.UpdateBy,
                        UpdateByName = users.Where(e => e.UserId == p.UpdateBy).Any() ?
                        users.Where(e => e.UserId == p.UpdateBy).FirstOrDefault().Name : "",
                    });
                });

            return this.Ok(new
            {
                data = new
                {
                    belong = belong,
                    asign = asign
                }
            });
        }

        public class InsertRequest
        {
            [Required]
            public string name { get; set; }
            [Required]
            public string belongToLoginUser { get; set; }
            [Required]
            public string description { get; set; }
            [Required]
            public string userId { get; set; }
            [Required]
            public int type { get; set; }
        }

        [HttpPost]
        public IActionResult Insert(
            [FromServices] ITaskFormService _service,
            [FromBody] InsertRequest request)
        {
            var vo = _service.Add(
                request.name,
                request.belongToLoginUser,
                request.description,
                request.userId,
                1,
                request.type);

            if (vo != null)
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest();
            }
        }

        public class DeleteRequest
        {
            [Required]
            public int id { get; set; }
        }

        [HttpPost]
        public IActionResult Delete(
            [FromServices] ITaskFormService _service,
            [FromBody] DeleteRequest request)
        {
            var success = _service.Delete(request.id);
            if (success)
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest();
            }
        }

        public class ChangePrgressRequest
        {
            [Required]
            public int id { get; set; }
            [Required]
            public int progressNo { get; set; }
        }

        [HttpPost]
        public IActionResult ChangeProgress(
            [FromServices] ITaskFormService _service,
            [FromBody] ChangePrgressRequest request)
        {
            var vo = _service.ChangeProgress(request.id, request.progressNo);
            if (vo != null)
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}

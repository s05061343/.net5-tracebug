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

        //public class CTaskForm
        //{
        //    public int Id { get; set; }
        //    public int Priority { get; set; }
        //    public string PriorityName { get; set; }
        //    public int Type { get; set; }
        //    public string TypeName { get; set; }
        //    public int BelongToProgress { get; set; }
        //    public string BelongToProgressName { get; set; }
        //    public string Name { get; set; }
        //    public string BelongToLoginUser { get; set; }
        //    public string BelongToLoginUserName { get; set; }
        //    public string Description { get; set; }
        //    public DateTime? CreateDate { get; set; }
        //    public string CreateBy { get; set; }
        //    public string CreateByName { get; set; }
        //    public DateTime? UpdateDate { get; set; }
        //    public string UpdateBy { get; set; }
        //    public string UpdateByName { get; set; }
        //}

        [HttpPost]
        public IActionResult Query(
            [FromServices] ITaskFormService _service,
            [FromServices] DbContext _dbContext,
            [FromBody] QueryRequest request)
        {
            _service.SetBelongUser(request.userId);
            _service.SetAsignUser(null);
            var belong = _service.Query().ToList();

            _service.SetBelongUser(null);
            _service.SetAsignUser(request.userId);
            var asign = _service.Query().ToList();

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
            [Required]
            public int priority { get; set; }
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
                request.type,
                request.priority);

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

        public class ChangePriorityRequest
        {
            [Required]
            public int id { get; set; }
            [Required]
            public int priorityNo { get; set; }
        }

        [HttpPost]
        public IActionResult ChangePriority(
            [FromServices] ITaskFormService _service,
            [FromBody] ChangePriorityRequest request)
        {
            var vo = _service.ChangePriority(request.id, request.priorityNo);
            if (vo != null)
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Commen(
            [FromServices] DbContext _dbContext)
        {
            var users = _dbContext.Set<Model.Sqlite.LoginUser>().ToList();
            var progress = _dbContext.Set<Model.Sqlite.ProgressType>().ToList();
            var roles = _dbContext.Set<Model.Sqlite.RoleType>().ToList();
            var prioritys = _dbContext.Set<Model.Sqlite.PriorityType>().ToList();
            if (users.Any())
            {
                return this.Ok(new 
                { 
                    data = new 
                    {
                        users = users,
                        progress = progress,
                        roles = roles,
                        prioritys = prioritys
                    }
                });
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}

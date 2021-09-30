using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TaskForm
{
    public class TaskFormService : ITaskFormService
    {
        public class CTaskForm
        {
            public int Id { get; set; }
            public int Priority { get; set; }
            public string PriorityName { get; set; }
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

        protected readonly ILogger _logger;
        private readonly DbContext _dbContext;
        private string _userId;
        private string _asignUserId;
        public TaskFormService(DbContext dbContext, ILogger<TaskFormService> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void SetBelongUser(string userId)
        {
            if (userId != "admin")
                _userId = userId;
        }

        public IEnumerable<CTaskForm> Query()
        {
            //var plist = _dbContext.Set<Model.Sqlite.ProgressType>().ToList();
            var users = _dbContext.Set<Model.Sqlite.LoginUser>().ToList();
            var types = _dbContext.Set<Model.Sqlite.FormType>().ToList();

            var originlist = _dbContext.Set<Model.Sqlite.TaskForm>()
                .Where(p => p.BelongToLoginUser == _userId || string.IsNullOrEmpty(_userId))
                .Where(p => p.CreateBy == _asignUserId || string.IsNullOrEmpty(_asignUserId))
                .ToList();

            var result = new List<CTaskForm>();
            originlist.ForEach(p =>
             {
                 result.Add(new CTaskForm
                 {
                     Id = p.Id,
                     Priority = p.Priority,
                     Type = p.Type,
                     TypeName = types.Where(e => e.Id == p.Type).Any() ?
                     types.Where(e => e.Id == p.Type).FirstOrDefault().Name : "",
                     BelongToProgress = p.BelongToProgress,
                     //BelongToProgressName = plist.Where(e => e.Id == p.BelongToProgress).Any() ?
                     //plist.Where(e => e.Id == p.BelongToProgress).FirstOrDefault().Name : "",
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

            return result;
        }

        public Model.Sqlite.TaskForm Add(
            string name,
            string belongToLoginUser,
            string description,
            string userId,
            int progressNo = 1,
            int type = 1,
            int priority = 1)
        {
            try
            {
                var vo = new Model.Sqlite.TaskForm
                {
                    Priority = priority,
                    Type = type,
                    BelongToProgress = progressNo,
                    Name = name,
                    BelongToLoginUser = belongToLoginUser,
                    Description = description,
                    CreateDate = DateTime.Now,
                    CreateBy = userId,
                    UpdateDate = DateTime.Now,
                    UpdateBy = userId
                };

                _dbContext.Set<Model.Sqlite.TaskForm>().Add(vo);
                _dbContext.SaveChanges();
                return vo;
            }
            catch (Exception ex)
            {
                _logger.LogError($"@{ex}");
                return null;
            }
        }

        public bool Delete(int taskId)
        {
            var result = false;

            try
            {
                var vo = _dbContext.Set<Model.Sqlite.TaskForm>().Find(taskId);
                _dbContext.Set<Model.Sqlite.TaskForm>().Remove(vo);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"@{ex}");
            }

            return result;
        }

        public Model.Sqlite.TaskForm ChangeProgress(int taskId, int progressNo)
        {
            try
            {
                var vo = _dbContext.Set<Model.Sqlite.TaskForm>().Find(taskId);
                vo.BelongToProgress = progressNo;
                _dbContext.SaveChanges();
                return vo;
            }
            catch (Exception ex)
            {
                _logger.LogError($"@{ex}");
                return null;
            }
        }

        public Model.Sqlite.TaskForm ChangePriority(int taskId, int priorityNo)
        {
            try
            {
                var vo = _dbContext.Set<Model.Sqlite.TaskForm>().Find(taskId);
                vo.Priority = priorityNo;
                _dbContext.SaveChanges();
                return vo;
            }
            catch (Exception ex)
            {
                _logger.LogError($"@{ex}");
                return null;
            }
        }


        public void SetAsignUser(string userId)
        {
            if (userId != "admin")
                _asignUserId = userId;
        }
    }
}

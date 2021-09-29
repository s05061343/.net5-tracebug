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
            _userId = userId;
        }

        public IEnumerable<Model.Sqlite.TaskForm> Query()
        {
            return _dbContext.Set<Model.Sqlite.TaskForm>()
                .Where(p => p.BelongToLoginUser == _userId || string.IsNullOrEmpty(_userId))
                .Where(p => p.CreateBy == _asignUserId || string.IsNullOrEmpty(_asignUserId))
                .ToList();
        }

        public Model.Sqlite.TaskForm Add(
            string name,
            string belongToLoginUser,
            string description,
            string userId,
            int progressNo = 1,
            int type = 1)
        {
            try
            {
                var vo = new Model.Sqlite.TaskForm
                {
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

        public void SetAsignUser(string userId)
        {
            _asignUserId = userId;
        }
    }
}

using System.Collections.Generic;
using static Service.TaskForm.TaskFormService;

namespace Service.TaskForm
{
    public interface ITaskFormService
    {
        public void SetBelongUser(string userId);

        public void SetAsignUser(string userId);

        public IEnumerable<CTaskForm> Query();

        public Model.Sqlite.TaskForm Add(
            string name,
            string belongToLoginUser,
            string description,
            string userId,
            int progressNo = 1,
            int type = 1,
            int priority = 1);

        public bool Delete(int taskId);

        public Model.Sqlite.TaskForm ChangeProgress(int taskId, int progressNo);

        public Model.Sqlite.TaskForm ChangePriority(int taskId, int priorityNo);
    }
}
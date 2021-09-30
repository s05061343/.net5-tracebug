using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Sqlite
{
    public class TaskForm
    {
        [Key]
        public int Id { get; set; }
        public int Priority { get; set; }
        public string PriorityName { get; set; }
        public int Type { get; set; }
        public int BelongToProgress { get; set; }
        public string Name { get; set; }
        public string BelongToLoginUser { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}

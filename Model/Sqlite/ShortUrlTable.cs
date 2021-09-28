using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Sqlite
{
    public class ShortUrlTable
    {
        [Key]
        public string Id { get; set; }
        public string Url { get; set; }
        public DateTime? Expired { get; set; }
    }
}

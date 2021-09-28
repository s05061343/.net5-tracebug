using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Sqlite
{
    public class SQLiteContext : DbContext
    {
        public virtual DbSet<ShortUrlTable> ShortUrlTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=SQLiteDB.db");
    }
}

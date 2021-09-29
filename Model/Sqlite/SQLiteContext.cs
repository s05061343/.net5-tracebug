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
        public virtual DbSet<TaskForm> TaskForm { get; set; }
        public virtual DbSet<ProgressType> ProgressType { get; set; }
        public virtual DbSet<LoginUser> LoginUser { get; set; }
        public virtual DbSet<RoleType> RoleType { get; set; }
        public virtual DbSet<FormType> FormType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../Web/SQLiteDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgressType>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProgressType>().HasData(
                new ProgressType { Id = 1, Name = "新任務" },
                new ProgressType { Id = 2, Name = "進行中" },
                new ProgressType { Id = 3, Name = "已完成" });

            modelBuilder.Entity<RoleType>().HasData(
                new RoleType { Id = 1, Name = "QA" },
                new RoleType { Id = 2, Name = "PG" },
                new RoleType { Id = 3, Name = "PM" },
                new RoleType { Id = 4, Name = "Administrator" });

            modelBuilder.Entity<FormType>().HasData(
                new ProgressType { Id = 1, Name = "Bug Report" },
                new ProgressType { Id = 2, Name = "Feature Request" },
                new ProgressType { Id = 3, Name = "Test Case" });

            modelBuilder.Entity<LoginUser>().HasData(
                new LoginUser { UserId = "admin", Password = "admin", Name = "管理員", RoleNo = 4 },
                new LoginUser { UserId = "ts001", Password = "ts001", Name = "王曉明", RoleNo = 1 },
                new LoginUser { UserId = "ts002", Password = "ts002", Name = "劉俊麟", RoleNo = 3 },
                new LoginUser { UserId = "ts003", Password = "ts003", Name = "金城武", RoleNo = 2 },
                new LoginUser { UserId = "ts004", Password = "ts004", Name = "彭于晏", RoleNo = 1 },
                new LoginUser { UserId = "ts005", Password = "ts005", Name = "兆祐廷", RoleNo = 2 });


        }
    }
}

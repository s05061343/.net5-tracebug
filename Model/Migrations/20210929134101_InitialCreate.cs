using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RoleNo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ProgressType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    BelongToProgress = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    BelongToLoginUser = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreateBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdateBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskForm", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FormType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "錯誤解決" });

            migrationBuilder.InsertData(
                table: "FormType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "功能請求" });

            migrationBuilder.InsertData(
                table: "LoginUser",
                columns: new[] { "UserId", "Name", "Password", "RoleNo" },
                values: new object[] { "ts001", "王曉明", "ts001", 1 });

            migrationBuilder.InsertData(
                table: "LoginUser",
                columns: new[] { "UserId", "Name", "Password", "RoleNo" },
                values: new object[] { "ts002", "劉俊麟", "ts002", 3 });

            migrationBuilder.InsertData(
                table: "LoginUser",
                columns: new[] { "UserId", "Name", "Password", "RoleNo" },
                values: new object[] { "ts003", "金城武", "ts003", 2 });

            migrationBuilder.InsertData(
                table: "LoginUser",
                columns: new[] { "UserId", "Name", "Password", "RoleNo" },
                values: new object[] { "ts004", "彭于晏", "ts004", 1 });

            migrationBuilder.InsertData(
                table: "LoginUser",
                columns: new[] { "UserId", "Name", "Password", "RoleNo" },
                values: new object[] { "ts005", "兆祐廷", "ts005", 2 });

            migrationBuilder.InsertData(
                table: "ProgressType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "新任務" });

            migrationBuilder.InsertData(
                table: "ProgressType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "進行中" });

            migrationBuilder.InsertData(
                table: "ProgressType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "已完成" });

            migrationBuilder.InsertData(
                table: "RoleType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "QA" });

            migrationBuilder.InsertData(
                table: "RoleType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "PG" });

            migrationBuilder.InsertData(
                table: "RoleType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "PM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormType");

            migrationBuilder.DropTable(
                name: "LoginUser");

            migrationBuilder.DropTable(
                name: "ProgressType");

            migrationBuilder.DropTable(
                name: "RoleType");

            migrationBuilder.DropTable(
                name: "TaskForm");
        }
    }
}

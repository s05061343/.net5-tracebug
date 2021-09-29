﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Sqlite;

namespace Model.Migrations
{
    [DbContext(typeof(SQLiteContext))]
    [Migration("20210929134101_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Model.Sqlite.FormType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FormType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "錯誤解決"
                        },
                        new
                        {
                            Id = 2,
                            Name = "功能請求"
                        });
                });

            modelBuilder.Entity("Model.Sqlite.LoginUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.ToTable("LoginUser");

                    b.HasData(
                        new
                        {
                            UserId = "ts001",
                            Name = "王曉明",
                            Password = "ts001",
                            RoleNo = 1
                        },
                        new
                        {
                            UserId = "ts002",
                            Name = "劉俊麟",
                            Password = "ts002",
                            RoleNo = 3
                        },
                        new
                        {
                            UserId = "ts003",
                            Name = "金城武",
                            Password = "ts003",
                            RoleNo = 2
                        },
                        new
                        {
                            UserId = "ts004",
                            Name = "彭于晏",
                            Password = "ts004",
                            RoleNo = 1
                        },
                        new
                        {
                            UserId = "ts005",
                            Name = "兆祐廷",
                            Password = "ts005",
                            RoleNo = 2
                        });
                });

            modelBuilder.Entity("Model.Sqlite.ProgressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProgressType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "新任務"
                        },
                        new
                        {
                            Id = 2,
                            Name = "進行中"
                        },
                        new
                        {
                            Id = 3,
                            Name = "已完成"
                        });
                });

            modelBuilder.Entity("Model.Sqlite.RoleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RoleType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "QA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PG"
                        },
                        new
                        {
                            Id = 3,
                            Name = "PM"
                        });
                });

            modelBuilder.Entity("Model.Sqlite.TaskForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BelongToLoginUser")
                        .HasColumnType("TEXT");

                    b.Property<int>("BelongToProgress")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreateBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskForm");
                });
#pragma warning restore 612, 618
        }
    }
}
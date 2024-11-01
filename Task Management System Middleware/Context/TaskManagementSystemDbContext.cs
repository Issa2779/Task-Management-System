using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Task_Management_System_Middleware.Models;

namespace Task_Management_System_Middleware.Context;

public partial class TaskManagementSystemDbContext : DbContext
{
    public TaskManagementSystemDbContext()
    {
    }

    public TaskManagementSystemDbContext(DbContextOptions<TaskManagementSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserTask> UserTasks { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlite("Data Source=Task_Management_System_DB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.ToTable("user_task");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DueDate).HasColumnType("DATE");
            entity.Property(e => e.Status).HasColumnType("VARCHAR(50)");
            entity.Property(e => e.TaskName).HasColumnType("VARCHAR(255)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TimeSheetApplication.Models;

public partial class TimeSheetApplicationContext : DbContext
{
    public TimeSheetApplicationContext()
    {
    }

    public TimeSheetApplicationContext(DbContextOptions<TimeSheetApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<TaskList> TaskLists { get; set; }

    public virtual DbSet<TimeSheet> TimeSheets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSqlLocalDb ;Database=TimeSheetApplication;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeEmail).HasName("PK__Employee__616BAD36D173ED57");

            entity.HasIndex(e => e.EmployeeId, "UQ__Employee__78113480F6383760").IsUnique();

            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee_Email");
            entity.Property(e => e.EmployeeDesignation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee_Designation");
            entity.Property(e => e.EmployeeFirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee_FirstName");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.EmployeeJoiningDate)
                .HasColumnType("date")
                .HasColumnName("Employee_JoiningDate");
            entity.Property(e => e.EmployeeLastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee_LastName");
            entity.Property(e => e.EmployeeLeavingDate)
                .HasColumnType("date")
                .HasColumnName("Employee_LeavingDate");
            entity.Property(e => e.EmployeePassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee_Password");
            entity.Property(e => e.EmployeeStatus).HasColumnName("Employee_Status");
        });

        modelBuilder.Entity<TaskList>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__TaskList__716F4AEDBB0F4CA2"); 

            entity.ToTable("TaskList");

            entity.Property(e => e.TaskId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Task_Id"); 
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee_Email");
            entity.Property(e => e.TaskCompletion)
                .HasColumnType("datetime")
                .HasColumnName("Task_Completion");
            entity.Property(e => e.TaskCraeted)
                .HasColumnType("datetime")
                .HasColumnName("Task_Craeted");
            entity.Property(e => e.TaskDeadline)
                .HasColumnType("datetime")
                .HasColumnName("Task_Deadline");
            entity.Property(e => e.TaskDetails)
                .HasColumnType("text")
                .HasColumnName("Task_Details");
            entity.Property(e => e.TaskType).HasColumnName("Task_Type");

            entity.HasOne(d => d.EmployeeEmailNavigation).WithMany(p => p.TaskLists)
                .HasForeignKey(d => d.EmployeeEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaskList__Employ__5CD6CB2B");
        });

        modelBuilder.Entity<TimeSheet>(entity =>
        {
            entity.HasKey(e => e.TimeSheetId).HasName("PK__TimeShee__D0EF8CC805B24816");

            entity.ToTable("TimeSheet");

            entity.Property(e => e.TimeSheetId)
                .ValueGeneratedNever()
                .HasColumnName("TimeSheet_Id");
            entity.Property(e => e.ApprovalStatus).HasColumnName("Approval_Status");
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee_Email");
            entity.Property(e => e.TaskId).HasColumnName("Task_Id");

            entity.HasOne(d => d.EmployeeEmailNavigation).WithMany(p => p.TimeSheets)
                .HasForeignKey(d => d.EmployeeEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TimeSheet__Emplo__5FB337D6");

            entity.HasOne(d => d.Task).WithMany(p => p.TimeSheets)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TimeSheet__Task___60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class SmirnovaPlanGoDbContext : DbContext
{
    public SmirnovaPlanGoDbContext()
    {
    }

    public SmirnovaPlanGoDbContext(DbContextOptions<SmirnovaPlanGoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationStatus> NotificationStatuses { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportType> ReportTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesOfUser> RolesOfUsers { get; set; }

    public virtual DbSet<ShortTaskDescription> ShortTaskDescriptions { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectInfo> SubjectInfos { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskAttachment> TaskAttachments { get; set; }

    public virtual DbSet<TaskCategory> TaskCategories { get; set; }

    public virtual DbSet<TaskComment> TaskComments { get; set; }

    public virtual DbSet<TaskPrioritiesHistory> TaskPrioritiesHistories { get; set; }

    public virtual DbSet<TaskPriority> TaskPriorities { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<TaskStatusHistory> TaskStatusHistories { get; set; }

    public virtual DbSet<TaskType> TaskTypes { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83F81665EB3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NotificationTime)
                .HasColumnType("datetime")
                .HasColumnName("notificationTime");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.TaskId).HasColumnName("taskId");

            entity.HasOne(d => d.Status).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__statu__4D94879B");

            entity.HasOne(d => d.Task).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK__Notificat__taskI__4CA06362");
        });

        modelBuilder.Entity<NotificationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83FEA0FBF0E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .HasColumnName("statusName");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reports__3213E83FAA8DF638");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.ReportPeriodEnd).HasColumnName("reportPeriodEnd");
            entity.Property(e => e.ReportPeriodStart).HasColumnName("reportPeriodStart");
            entity.Property(e => e.ReportTypeId).HasColumnName("reportTypeId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ReportType).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ReportTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__reportT__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reports__userId__534D60F1");
        });

        modelBuilder.Entity<ReportType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReportTy__3213E83F6EF6437C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReportTypeName)
                .HasMaxLength(100)
                .HasColumnName("reportTypeName");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3213E83F96F0A11D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<RolesOfUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("RolesOfUser");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Role).WithMany(p => p.RolesOfUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesOfUser_Roles");

            entity.HasOne(d => d.User).WithOne(p => p.RolesOfUser)
                .HasForeignKey<RolesOfUser>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesOfUser_Users");
        });

        modelBuilder.Entity<ShortTaskDescription>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__TaskDesc__3213E83F1A6BFEF5");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("taskId");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(d => d.Task).WithOne(p => p.ShortTaskDescription)
                .HasForeignKey<ShortTaskDescription>(d => d.TaskId)
                .HasConstraintName("FK__TaskDescr__taskI__3A81B327");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3213E83FA85B43B7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(255)
                .HasColumnName("subjectName");
        });

        modelBuilder.Entity<SubjectInfo>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__SubjectI__3213E83F402CB8F9");

            entity.ToTable("SubjectInfo");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("subjectId");
            entity.Property(e => e.Classroom)
                .HasMaxLength(50)
                .HasColumnName("classroom");
            entity.Property(e => e.TeacherId).HasColumnName("teacherId");

            entity.HasOne(d => d.Subject).WithOne(p => p.SubjectInfo)
                .HasForeignKey<SubjectInfo>(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectInfo_Subjects");

            entity.HasOne(d => d.Teacher).WithMany(p => p.SubjectInfos)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__SubjectIn__teach__619B8048");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3213E83F3283DBB6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Deadline)
                .HasColumnType("datetime")
                .HasColumnName("deadline");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.PriorityId).HasColumnName("priorityId");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.SubjectId).HasColumnName("subjectId");
            entity.Property(e => e.TypeId).HasColumnName("typeId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Category).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__categoryI__37A5467C");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__priorityI__35BCFE0A");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__statusId__36B12243");

            entity.HasOne(d => d.Subject).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_Tasks_Subjects");


            entity.HasOne(d => d.Type).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__typeId__34C8D9D1");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Tasks__userId__33D4B598");
        });

        modelBuilder.Entity<TaskAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskAtta__3213E83F70439DD9");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("filePath");
            entity.Property(e => e.TaskId).HasColumnName("taskId");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskAttachments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK__TaskAttac__taskI__3E52440B");
        });

        modelBuilder.Entity<TaskCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskCate__3213E83F1DA79648");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<TaskComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskComm__3213E83FBC7AB98E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.TaskId).HasColumnName("taskId");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskComments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK__TaskComme__taskI__47DBAE45");
        });

        modelBuilder.Entity<TaskPrioritiesHistory>(entity =>
        {
            entity.ToTable("TaskPrioritiesHistory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ChangedAt)
                .HasColumnType("datetime")
                .HasColumnName("changedAt");
            entity.Property(e => e.NewPriority).HasColumnName("newPriority");
            entity.Property(e => e.OldPriority).HasColumnName("oldPriority");
            entity.Property(e => e.TaskId).HasColumnName("taskId");

            entity.HasOne(d => d.NewPriorityNavigation).WithMany(p => p.TaskPrioritiesHistoryNewPriorityNavigations)
                .HasForeignKey(d => d.NewPriority)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskPrioritiesHistory_TaskPriorities1");

            entity.HasOne(d => d.OldPriorityNavigation).WithMany(p => p.TaskPrioritiesHistoryOldPriorityNavigations)
                .HasForeignKey(d => d.OldPriority)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskPrioritiesHistory_TaskPriorities");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskPrioritiesHistories)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskPrioritiesHistory_Tasks");
        });

        modelBuilder.Entity<TaskPriority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskPrio__3213E83FB093C4AF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(100)
                .HasColumnName("priorityName");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskStat__3213E83FA02D9194");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .HasColumnName("statusName");
        });

        modelBuilder.Entity<TaskStatusHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskStat__3213E83F871CFE96");

            entity.ToTable("TaskStatusHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChangedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("changedAt");
            entity.Property(e => e.NewStatusId).HasColumnName("newStatusId");
            entity.Property(e => e.OldStatusId).HasColumnName("oldStatusId");
            entity.Property(e => e.TaskId).HasColumnName("taskId");

            entity.HasOne(d => d.NewStatus).WithMany(p => p.TaskStatusHistoryNewStatuses)
                .HasForeignKey(d => d.NewStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskStatusHistory_TaskStatuses1");

            entity.HasOne(d => d.OldStatus).WithMany(p => p.TaskStatusHistoryOldStatuses)
                .HasForeignKey(d => d.OldStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskStatusHistory_TaskStatuses");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskStatusHistories)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK__TaskStatu__taskI__4222D4EF");
        });

        modelBuilder.Entity<TaskType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskType__3213E83F54278A26");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(100)
                .HasColumnName("typeName");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3213E83FE762DBC4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F813C9834");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164E5B8A0A6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__3213E83F5305A951");

            entity.ToTable("UserInfo");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middleName");
            entity.Property(e => e.PlaceOfStudy)
                .HasMaxLength(255)
                .HasColumnName("placeOfStudy");

            entity.HasOne(d => d.User).WithOne(p => p.UserInfo)
                .HasForeignKey<UserInfo>(d => d.UserId)
                .HasConstraintName("FK__UserInfo__id__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    protected void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskType>().HasData(
        new TaskType { Id = -1, TypeName =  "Учебная" },
        new TaskType { Id = -2, TypeName = "Внеучебная" } );

        modelBuilder.Entity<TaskCategory>().HasData(
        new TaskCategory { Id = -1, CategoryName = "Проект" },
        new TaskCategory { Id = -2, CategoryName = "Презентация" },
        new TaskCategory { Id = -3, CategoryName = "Письменная работа" },
        new TaskCategory { Id = -4, CategoryName = "Дела по дому" },
        new TaskCategory { Id = -5, CategoryName = "Поход в магазин" },
        new TaskCategory { Id = -6, CategoryName = "Прогулка" });

        modelBuilder.Entity<Role>().HasData(
        new Role { Id = -1, RoleName = "Студент" },
        new Role { Id = -2, RoleName = "Администратор" });

        modelBuilder.Entity<TaskStatus>().HasData(
        new TaskStatus { Id = -1, StatusName = "Не начата" },
        new TaskStatus { Id = -2, StatusName = "В процессе" },
        new TaskStatus { Id = -3, StatusName = "Завершена" },
        new TaskStatus { Id = -4, StatusName = "Просрочена" },
        new TaskStatus { Id = -5, StatusName = "Отложена" },
        new TaskStatus { Id = -6, StatusName = "Отменена" });

        modelBuilder.Entity<TaskPriority>().HasData(
        new TaskPriority { Id = -1, PriorityName = "Низкий" },
        new TaskPriority { Id = -2, PriorityName = "Средний" },
        new TaskPriority { Id = -3, PriorityName = "Высокий" });
    }
}

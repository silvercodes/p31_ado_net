using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _08_mig_practice.Models;

public partial class P31PracticeDbContext : DbContext
{
    public P31PracticeDbContext()
    {
    }

    public P31PracticeDbContext(DbContextOptions<P31PracticeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Pair> Pairs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ScheduleItem> ScheduleItems { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<TeachersProfile> TeachersProfiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=p31_mystat_db;Trusted_Connection=True;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__branches__3213E83F198A51AD");

            entity.ToTable("branches");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Title)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.City).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_branches_city");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cities__3213E83FAF69F688");

            entity.ToTable("cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classroo__3213E83F35F8D087");

            entity.ToTable("classrooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Number)
                .HasMaxLength(32)
                .HasColumnName("number");
            entity.Property(e => e.Title)
                .HasMaxLength(64)
                .HasColumnName("title");

            entity.HasOne(d => d.Branch).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_classrooms_branch");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__groups__3213E83F8969D34E");

            entity.ToTable("groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasMany(d => d.Pairs).WithMany(p => p.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupsPair",
                    r => r.HasOne<Pair>().WithMany()
                        .HasForeignKey("PairId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_groups_pairs_pair"),
                    l => l.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_groups_pairs_group"),
                    j =>
                    {
                        j.HasKey("GroupId", "PairId");
                        j.ToTable("groups_pairs");
                        j.IndexerProperty<int>("GroupId").HasColumnName("group_id");
                        j.IndexerProperty<int>("PairId").HasColumnName("pair_id");
                    });
        });

        modelBuilder.Entity<Pair>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pairs__3213E83FBCF55EDA");

            entity.ToTable("pairs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.IsOnline).HasColumnName("is_online");
            entity.Property(e => e.PairDate).HasColumnName("pair_date");
            entity.Property(e => e.ScheduleItemId).HasColumnName("schedule_item_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.Theme)
                .HasMaxLength(256)
                .HasColumnName("theme");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Pairs)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK_pairs_classroom");

            entity.HasOne(d => d.ScheduleItem).WithMany(p => p.Pairs)
                .HasForeignKey(d => d.ScheduleItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pairs_schedule_item");

            entity.HasOne(d => d.Subject).WithMany(p => p.Pairs)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pairs_subject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Pairs)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pairs_teacher");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F4101E16D");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ScheduleItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__schedule__3213E83FEB107973");

            entity.ToTable("schedule_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemEnd).HasColumnName("item_end");
            entity.Property(e => e.ItemStart).HasColumnName("item_start");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subjects__3213E83FE85E6290");

            entity.ToTable("subjects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("smalldatetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Slug)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("slug");
            entity.Property(e => e.Title)
                .HasMaxLength(256)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TeachersProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teachers__3213E83F8D264E9C");

            entity.ToTable("teachers_profiles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(64)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(64)
                .HasColumnName("last_name");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TeachersProfile)
                .HasForeignKey<TeachersProfile>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_teachers_profiles_user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F5BDB720C");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164A034882E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Hash)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("hash");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

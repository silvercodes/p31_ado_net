﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _08_mig_practice.Models;

#nullable disable

namespace _08_mig_practice.Migrations
{
    [DbContext(typeof(P31PracticeDbContext))]
    [Migration("20250329095916_ModUser")]
    partial class ModUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GroupsPair", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("group_id");

                    b.Property<int>("PairId")
                        .HasColumnType("int")
                        .HasColumnName("pair_id");

                    b.HasKey("GroupId", "PairId");

                    b.HasIndex("PairId");

                    b.ToTable("groups_pairs", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__branches__3213E83F198A51AD");

                    b.HasIndex("CityId");

                    b.ToTable("branches", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__cities__3213E83FAF69F688");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int")
                        .HasColumnName("branch_id");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("number");

                    b.Property<string>("Title")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__classroo__3213E83F35F8D087");

                    b.HasIndex("BranchId");

                    b.ToTable("classrooms", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__groups__3213E83F8969D34E");

                    b.ToTable("groups", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.Pair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClassroomId")
                        .HasColumnType("int")
                        .HasColumnName("classroom_id");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit")
                        .HasColumnName("is_online");

                    b.Property<DateOnly>("PairDate")
                        .HasColumnType("date")
                        .HasColumnName("pair_date");

                    b.Property<int>("ScheduleItemId")
                        .HasColumnType("int")
                        .HasColumnName("schedule_item_id");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    b.Property<string>("Theme")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("theme");

                    b.HasKey("Id")
                        .HasName("PK__pairs__3213E83FBCF55EDA");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("ScheduleItemId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("pairs", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__roles__3213E83F4101E16D");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.ScheduleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("ItemEnd")
                        .HasColumnType("time")
                        .HasColumnName("item_end");

                    b.Property<TimeOnly>("ItemStart")
                        .HasColumnType("time")
                        .HasColumnName("item_start");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint")
                        .HasColumnName("number");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PK__schedule__3213E83FEB107973");

                    b.ToTable("schedule_items", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("slug");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__subjects__3213E83FE85E6290");

                    b.ToTable("subjects", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.TeachersProfile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("PK__teachers__3213E83F8D264E9C");

                    b.ToTable("teachers_profiles", (string)null);
                });

            modelBuilder.Entity("_08_mig_practice.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("email");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("char(64)")
                        .HasColumnName("hash")
                        .IsFixedLength();

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("PK__users__3213E83F5BDB720C");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Email" }, "UQ__users__AB6E6164A034882E")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("GroupsPair", b =>
                {
                    b.HasOne("_08_mig_practice.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("FK_groups_pairs_group");

                    b.HasOne("_08_mig_practice.Models.Pair", null)
                        .WithMany()
                        .HasForeignKey("PairId")
                        .IsRequired()
                        .HasConstraintName("FK_groups_pairs_pair");
                });

            modelBuilder.Entity("_08_mig_practice.Models.Branch", b =>
                {
                    b.HasOne("_08_mig_practice.Models.City", "City")
                        .WithMany("Branches")
                        .HasForeignKey("CityId")
                        .IsRequired()
                        .HasConstraintName("FK_branches_city");

                    b.Navigation("City");
                });

            modelBuilder.Entity("_08_mig_practice.Models.Classroom", b =>
                {
                    b.HasOne("_08_mig_practice.Models.Branch", "Branch")
                        .WithMany("Classrooms")
                        .HasForeignKey("BranchId")
                        .IsRequired()
                        .HasConstraintName("FK_classrooms_branch");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("_08_mig_practice.Models.Pair", b =>
                {
                    b.HasOne("_08_mig_practice.Models.Classroom", "Classroom")
                        .WithMany("Pairs")
                        .HasForeignKey("ClassroomId")
                        .HasConstraintName("FK_pairs_classroom");

                    b.HasOne("_08_mig_practice.Models.ScheduleItem", "ScheduleItem")
                        .WithMany("Pairs")
                        .HasForeignKey("ScheduleItemId")
                        .IsRequired()
                        .HasConstraintName("FK_pairs_schedule_item");

                    b.HasOne("_08_mig_practice.Models.Subject", "Subject")
                        .WithMany("Pairs")
                        .HasForeignKey("SubjectId")
                        .IsRequired()
                        .HasConstraintName("FK_pairs_subject");

                    b.HasOne("_08_mig_practice.Models.TeachersProfile", "Teacher")
                        .WithMany("Pairs")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("FK_pairs_teacher");

                    b.Navigation("Classroom");

                    b.Navigation("ScheduleItem");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("_08_mig_practice.Models.TeachersProfile", b =>
                {
                    b.HasOne("_08_mig_practice.Models.User", "IdNavigation")
                        .WithOne("TeachersProfile")
                        .HasForeignKey("_08_mig_practice.Models.TeachersProfile", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_teachers_profiles_user");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("_08_mig_practice.Models.User", b =>
                {
                    b.HasOne("_08_mig_practice.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_users_role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("_08_mig_practice.Models.Branch", b =>
                {
                    b.Navigation("Classrooms");
                });

            modelBuilder.Entity("_08_mig_practice.Models.City", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("_08_mig_practice.Models.Classroom", b =>
                {
                    b.Navigation("Pairs");
                });

            modelBuilder.Entity("_08_mig_practice.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("_08_mig_practice.Models.ScheduleItem", b =>
                {
                    b.Navigation("Pairs");
                });

            modelBuilder.Entity("_08_mig_practice.Models.Subject", b =>
                {
                    b.Navigation("Pairs");
                });

            modelBuilder.Entity("_08_mig_practice.Models.TeachersProfile", b =>
                {
                    b.Navigation("Pairs");
                });

            modelBuilder.Entity("_08_mig_practice.Models.User", b =>
                {
                    b.Navigation("TeachersProfile");
                });
#pragma warning restore 612, 618
        }
    }
}

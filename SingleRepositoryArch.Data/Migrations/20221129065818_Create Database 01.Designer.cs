﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SingleRepositoryArch.Infra.Data;

#nullable disable

namespace SingleRepositoryArch.Data.Migrations
{
    [DbContext(typeof(SingleRepoContext))]
    [Migration("20221129065818_Create Database 01")]
    partial class CreateDatabase01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SingleRepositoryArch.Data.Models.Management.Semester", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("Capacity")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("semesters");
                });

            modelBuilder.Entity("SingleRepositoryArch.Data.Models.Management.SemesterSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FinishTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SemesterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("TeacherId");

                    b.ToTable("semesterSchedule");
                });

            modelBuilder.Entity("SingleRepositoryArch.Data.Models.Management.Teacher", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("teachers");
                });

            modelBuilder.Entity("SingleRepositoryArch.Data.Models.Management.TeacherDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<short>("ChildernNumber")
                        .HasColumnType("smallint");

                    b.Property<byte?>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<bool?>("MaritalStatus")
                        .HasColumnType("bit");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("teacherDetails");
                });

            modelBuilder.Entity("SingleRepositoryArch.Data.Models.Management.SemesterSchedule", b =>
                {
                    b.HasOne("SingleRepositoryArch.Data.Models.Management.Semester", "Semester")
                        .WithMany("SemesterSchedules")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SingleRepositoryArch.Data.Models.Management.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SingleRepositoryArch.Data.Models.Management.TeacherDetails", b =>
                {
                    b.HasOne("SingleRepositoryArch.Data.Models.Management.Teacher", "Teacher")
                        .WithOne("TeacherDetails")
                        .HasForeignKey("SingleRepositoryArch.Data.Models.Management.TeacherDetails", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SingleRepositoryArch.Data.Models.Management.Semester", b =>
                {
                    b.Navigation("SemesterSchedules");
                });

            modelBuilder.Entity("SingleRepositoryArch.Data.Models.Management.Teacher", b =>
                {
                    b.Navigation("TeacherDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schoolar.infrastructure.Persistence;

#nullable disable

namespace Schoolar.infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Schoolar.Data.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DepartmentNameAr")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("InsManager")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorManger")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("InstructorManger")
                        .IsUnique()
                        .HasFilter("[InstructorManger] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.DepartmetSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmetId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "DepartmetId");

                    b.HasIndex("DepartmetId");

                    b.ToTable("DepartmetSubjects");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.InstructorSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "InstructorId");

                    b.HasIndex("InstructorId");

                    b.ToTable("InstructorSubject");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NameAr")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.StudentSubject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubjects");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Subjects", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SubjectNameAr")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Department", b =>
                {
                    b.HasOne("Schoolar.Data.Entities.Instructor", "Instructor")
                        .WithOne("departmentManager")
                        .HasForeignKey("Schoolar.Data.Entities.Department", "InstructorManger")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.DepartmetSubject", b =>
                {
                    b.HasOne("Schoolar.Data.Entities.Department", "Department")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("DepartmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schoolar.Data.Entities.Subjects", "Subject")
                        .WithMany("DepartmetsSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Instructor", b =>
                {
                    b.HasOne("Schoolar.Data.Entities.Department", "department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Schoolar.Data.Entities.Instructor", "Supervisor")
                        .WithMany("Instructors")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Supervisor");

                    b.Navigation("department");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.InstructorSubject", b =>
                {
                    b.HasOne("Schoolar.Data.Entities.Instructor", "instructor")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schoolar.Data.Entities.Subjects", "Subject")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Student", b =>
                {
                    b.HasOne("Schoolar.Data.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.StudentSubject", b =>
                {
                    b.HasOne("Schoolar.Data.Entities.Student", "Student")
                        .WithMany("StudentSubject")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schoolar.Data.Entities.Subjects", "Subject")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Department", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Instructor", b =>
                {
                    b.Navigation("InstructorSubjects");

                    b.Navigation("Instructors");

                    b.Navigation("departmentManager");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Student", b =>
                {
                    b.Navigation("StudentSubject");
                });

            modelBuilder.Entity("Schoolar.Data.Entities.Subjects", b =>
                {
                    b.Navigation("DepartmetsSubjects");

                    b.Navigation("InstructorSubjects");

                    b.Navigation("StudentsSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}

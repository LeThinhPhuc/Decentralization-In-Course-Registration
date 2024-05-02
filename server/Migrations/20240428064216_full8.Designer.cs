﻿// <auto-generated />
using System;
using BMCSDL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BMCSDL.Migrations
{
    [DbContext(typeof(CourseRegistraionManagementContext))]
    [Migration("20240428064216_full8")]
    partial class full8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BMCSDL.Models.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId")
                        .IsUnique()
                        .HasFilter("[RoleId] IS NOT NULL");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BMCSDL.Models.ClassTime", b =>
                {
                    b.Property<string>("ClassroomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClassroomId", "TimeId");

                    b.HasIndex("TimeId");

                    b.ToTable("ClassTime");
                });

            modelBuilder.Entity("BMCSDL.Models.Classroom", b =>
                {
                    b.Property<string>("ClassRoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassroomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ClassRoomId");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("BMCSDL.Models.Faculty", b =>
                {
                    b.Property<string>("FacultyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("BMCSDL.Models.GiaoVu", b =>
                {
                    b.Property<string>("GiaoVuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GiaoVuId");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("GiaoVu");
                });

            modelBuilder.Entity("BMCSDL.Models.Person", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacultyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.HasIndex("FacultyId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.RegisteredSubject", b =>
                {
                    b.Property<string>("RegisteredSubjecId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RegisteredSubjecId");

                    b.HasAlternateKey("SubjectId");

                    b.ToTable("RegisteredSubject");
                });

            modelBuilder.Entity("BMCSDL.Models.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("BMCSDL.Models.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("BMCSDL.Models.StudentRegisteredSubject", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("RegisteredSubjectId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<float>("Mark")
                        .HasColumnType("real");

                    b.HasKey("StudentId", "RegisteredSubjectId");

                    b.HasIndex("RegisteredSubjectId");

                    b.ToTable("StudentRegisteredSubject");
                });

            modelBuilder.Entity("BMCSDL.Models.Subject", b =>
                {
                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacultyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("BMCSDL.Models.SubjectClass", b =>
                {
                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("ClassroomId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("TimeId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(2);

                    b.HasKey("SubjectId", "ClassroomId", "TimeId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("TimeId");

                    b.ToTable("SubjectClass");
                });

            modelBuilder.Entity("BMCSDL.Models.Teacher", b =>
                {
                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TeacherId");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("BMCSDL.Models.Time", b =>
                {
                    b.Property<string>("TimeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("TimeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeId");

                    b.ToTable("Time");
                });

            modelBuilder.Entity("BMCSDL.Models.TruongBoMon", b =>
                {
                    b.Property<string>("TruongBoMonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TruongBoMonId");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("TruongBoMon");
                });

            modelBuilder.Entity("BMCSDL.Models.TruongPhoKhoa", b =>
                {
                    b.Property<string>("TruongPhoKhoaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TruongPhoKhoaId");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("TruongPhoKhoa");
                });

            modelBuilder.Entity("BMCSDL.Models.Account", b =>
                {
                    b.HasOne("BMCSDL.Models.Role", "Role")
                        .WithOne("Account")
                        .HasForeignKey("BMCSDL.Models.Account", "RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BMCSDL.Models.ClassTime", b =>
                {
                    b.HasOne("BMCSDL.Models.Classroom", "Classroom")
                        .WithMany("ClassTime")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Time", "Time")
                        .WithMany("ClassTime")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("BMCSDL.Models.GiaoVu", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("GiaoVu")
                        .HasForeignKey("BMCSDL.Models.GiaoVu", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.Person", b =>
                {
                    b.HasOne("BMCSDL.Models.Account", "Account")
                        .WithOne("Person")
                        .HasForeignKey("BMCSDL.Models.Person", "AccountId");

                    b.HasOne("BMCSDL.Models.Faculty", "Faculty")
                        .WithMany("Person")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Account");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("BMCSDL.Models.RegisteredSubject", b =>
                {
                    b.HasOne("BMCSDL.Models.Subject", "Subject")
                        .WithOne("RegisteredSubject")
                        .HasForeignKey("BMCSDL.Models.RegisteredSubject", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("BMCSDL.Models.Student", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("Student")
                        .HasForeignKey("BMCSDL.Models.Student", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.StudentRegisteredSubject", b =>
                {
                    b.HasOne("BMCSDL.Models.RegisteredSubject", "RegisteredSubject")
                        .WithMany("StudentRegisteredSubject")
                        .HasForeignKey("RegisteredSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Student", "Student")
                        .WithMany("StudentRegisteredSubject")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegisteredSubject");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BMCSDL.Models.Subject", b =>
                {
                    b.HasOne("BMCSDL.Models.Faculty", "Faculty")
                        .WithMany("Subject")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("BMCSDL.Models.SubjectClass", b =>
                {
                    b.HasOne("BMCSDL.Models.Classroom", "Classroom")
                        .WithMany("SubjectClass")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Subject", "Subject")
                        .WithMany("SubjectClass")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Time", "Time")
                        .WithMany("SubjectClass")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Subject");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("BMCSDL.Models.Teacher", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("Teacher")
                        .HasForeignKey("BMCSDL.Models.Teacher", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.TruongBoMon", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("TruongBoMon")
                        .HasForeignKey("BMCSDL.Models.TruongBoMon", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.TruongPhoKhoa", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("TruongPhoKhoa")
                        .HasForeignKey("BMCSDL.Models.TruongPhoKhoa", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.Account", b =>
                {
                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.Classroom", b =>
                {
                    b.Navigation("ClassTime");

                    b.Navigation("SubjectClass");
                });

            modelBuilder.Entity("BMCSDL.Models.Faculty", b =>
                {
                    b.Navigation("Person");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("BMCSDL.Models.Person", b =>
                {
                    b.Navigation("GiaoVu");

                    b.Navigation("Student");

                    b.Navigation("Teacher");

                    b.Navigation("TruongBoMon");

                    b.Navigation("TruongPhoKhoa");
                });

            modelBuilder.Entity("BMCSDL.Models.RegisteredSubject", b =>
                {
                    b.Navigation("StudentRegisteredSubject");
                });

            modelBuilder.Entity("BMCSDL.Models.Role", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("BMCSDL.Models.Student", b =>
                {
                    b.Navigation("StudentRegisteredSubject");
                });

            modelBuilder.Entity("BMCSDL.Models.Subject", b =>
                {
                    b.Navigation("RegisteredSubject");

                    b.Navigation("SubjectClass");
                });

            modelBuilder.Entity("BMCSDL.Models.Time", b =>
                {
                    b.Navigation("ClassTime");

                    b.Navigation("SubjectClass");
                });
#pragma warning restore 612, 618
        }
    }
}

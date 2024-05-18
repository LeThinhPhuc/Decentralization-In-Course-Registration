﻿// <auto-generated />
using System;
using BMCSDL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BMCSDL.Migrations
{
    [DbContext(typeof(CourseRegistraionManagementContext))]
    partial class CourseRegistraionManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AccountId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("BMCSDL.Models.ClassTime", b =>
                {
                    b.Property<string>("ClassroomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClassroomId", "TimeId");

                    b.HasIndex("TimeId");

                    b.ToTable("ClassTime", (string)null);
                });

            modelBuilder.Entity("BMCSDL.Models.Classroom", b =>
                {
                    b.Property<string>("ClassRoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassroomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxQuantity")
                        .HasColumnType("int");

                    b.HasKey("ClassRoomId");

                    b.ToTable("Classroom", (string)null);
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

                    b.ToTable("Faculty", (string)null);
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

                    b.ToTable("GiaoVu", (string)null);
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

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("BMCSDL.Models.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("BMCSDL.Models.RoleAccount", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("RoleId", "AccountId");

                    b.HasIndex("AccountId");

                    b.ToTable("RoleAccount", (string)null);
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

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("BMCSDL.Models.StudentRegisteredSubject", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("ClassroomId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(2);

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(4);

                    b.Property<string>("TimeId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(3);

                    b.Property<float>("Mark1")
                        .HasColumnType("real");

                    b.Property<float>("Mark2")
                        .HasColumnType("real");

                    b.Property<float>("Mark3")
                        .HasColumnType("real");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentId", "SubjectId", "ClassroomId", "TeacherId", "TimeId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TimeId");

                    b.ToTable("StudentRegisteredSubject", (string)null);
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

                    b.Property<bool>("isOpen")
                        .HasColumnType("bit");

                    b.HasKey("SubjectId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Subject", (string)null);
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

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(3);

                    b.Property<int>("CurrentQuantity")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "ClassroomId", "TimeId", "TeacherId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TimeId");

                    b.ToTable("SubjectClass", (string)null);
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

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("BMCSDL.Models.TeacherSubject", b =>
                {
                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubject", (string)null);
                });

            modelBuilder.Entity("BMCSDL.Models.Time", b =>
                {
                    b.Property<string>("TimeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("TimeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeId");

                    b.ToTable("Time", (string)null);
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

                    b.ToTable("TruongBoMon", (string)null);
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

                    b.ToTable("TruongPhoKhoa", (string)null);
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
                        .HasForeignKey("BMCSDL.Models.Person", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BMCSDL.Models.Faculty", "Faculty")
                        .WithMany("Person")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Account");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("BMCSDL.Models.RoleAccount", b =>
                {
                    b.HasOne("BMCSDL.Models.Account", "Account")
                        .WithMany("RoleAccount")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Role", "Role")
                        .WithMany("RoleAccount")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BMCSDL.Models.Student", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("Student")
                        .HasForeignKey("BMCSDL.Models.Student", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.StudentRegisteredSubject", b =>
                {
                    b.HasOne("BMCSDL.Models.Classroom", "Classroom")
                        .WithMany("StudentRegisteredSubject")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Student", "Student")
                        .WithMany("StudentRegisteredSubject")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Subject", "Subject")
                        .WithMany("StudentRegisteredSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Teacher", "Teacher")
                        .WithMany("StudentRegisteredSubject")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Time", "Time")
                        .WithMany("StudentRegisteredSubject")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Student");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("BMCSDL.Models.Subject", b =>
                {
                    b.HasOne("BMCSDL.Models.Faculty", "Faculty")
                        .WithMany("Subject")
                        .HasForeignKey("FacultyId");

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

                    b.HasOne("BMCSDL.Models.Teacher", "Teacher")
                        .WithMany("SubjectClass")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Time", "Time")
                        .WithMany("SubjectClass")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("BMCSDL.Models.Teacher", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("Teacher")
                        .HasForeignKey("BMCSDL.Models.Teacher", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.TeacherSubject", b =>
                {
                    b.HasOne("BMCSDL.Models.Subject", "Subject")
                        .WithMany("TeacherSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMCSDL.Models.Teacher", "Teacher")
                        .WithMany("TeacherSubject")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("BMCSDL.Models.TruongBoMon", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("TruongBoMon")
                        .HasForeignKey("BMCSDL.Models.TruongBoMon", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.TruongPhoKhoa", b =>
                {
                    b.HasOne("BMCSDL.Models.Person", "Person")
                        .WithOne("TruongPhoKhoa")
                        .HasForeignKey("BMCSDL.Models.TruongPhoKhoa", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BMCSDL.Models.Account", b =>
                {
                    b.Navigation("Person");

                    b.Navigation("RoleAccount");
                });

            modelBuilder.Entity("BMCSDL.Models.Classroom", b =>
                {
                    b.Navigation("ClassTime");

                    b.Navigation("StudentRegisteredSubject");

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

            modelBuilder.Entity("BMCSDL.Models.Role", b =>
                {
                    b.Navigation("RoleAccount");
                });

            modelBuilder.Entity("BMCSDL.Models.Student", b =>
                {
                    b.Navigation("StudentRegisteredSubject");
                });

            modelBuilder.Entity("BMCSDL.Models.Subject", b =>
                {
                    b.Navigation("StudentRegisteredSubject");

                    b.Navigation("SubjectClass");

                    b.Navigation("TeacherSubject");
                });

            modelBuilder.Entity("BMCSDL.Models.Teacher", b =>
                {
                    b.Navigation("StudentRegisteredSubject");

                    b.Navigation("SubjectClass");

                    b.Navigation("TeacherSubject");
                });

            modelBuilder.Entity("BMCSDL.Models.Time", b =>
                {
                    b.Navigation("ClassTime");

                    b.Navigation("StudentRegisteredSubject");

                    b.Navigation("SubjectClass");
                });
#pragma warning restore 612, 618
        }
    }
}

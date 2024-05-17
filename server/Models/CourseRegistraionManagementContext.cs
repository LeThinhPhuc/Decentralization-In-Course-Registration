using BMCSDL.DTOs;
using Microsoft.EntityFrameworkCore;
namespace BMCSDL.Models
{
    public class CourseRegistraionManagementContext : DbContext
    {
        public CourseRegistraionManagementContext(DbContextOptions<CourseRegistraionManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //Write Fluent API configurations here

            modelBuilder.Entity<RoleAccount>(entity =>
            {
                entity.HasKey(k => new { k.RoleId, k.AccountId });
            });

            modelBuilder.Entity<RoleAccount>(entity =>
            {
                entity.HasOne(e => e.Role)
                      .WithMany(r => r.RoleAccount)
                      .HasForeignKey(r => r.RoleId);
            });

            modelBuilder.Entity<RoleAccount>(entity =>
            {
                entity.HasOne(e => e.Account)
                      .WithMany(a => a.RoleAccount)
                      .HasForeignKey(e => e.AccountId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);

            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(a => a.UserName).IsUnique();
                entity.HasKey(a => a.AccountId);

                entity.HasOne(a => a.Person)
                      .WithOne(p => p.Account)
                      .HasForeignKey<Person>(p => p.PersonId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TruongPhoKhoa>(entity =>
            {
                entity.HasKey(e => e.TruongPhoKhoaId);
                entity.HasOne(e => e.Person)
                      .WithOne(p => p.TruongPhoKhoa)
                      .HasForeignKey<TruongPhoKhoa>(p => p.PersonId);
            });

            modelBuilder.Entity<TruongBoMon>(entity =>
            {
                entity.HasKey(e => e.TruongBoMonId);
                entity.HasOne(e => e.Person)
                      .WithOne(e => e.TruongBoMon)
                      .HasForeignKey<TruongBoMon>(t => t.PersonId);
            });

            modelBuilder.Entity<GiaoVu>(entity =>
            {
                entity.HasKey(e => e.GiaoVuId);
                entity.HasOne(e => e.Person)
                      .WithOne(p => p.GiaoVu)
                      .HasForeignKey<GiaoVu>(g => g.PersonId);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId);
                entity.HasOne(e => e.Person)
                      .WithOne(e => e.Teacher)
                      .HasForeignKey<Teacher>(t => t.PersonId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);
                entity.HasOne(e => e.Person)
                      .WithOne(e => e.Student)
                      .HasForeignKey<Student>(t => t.PersonId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.PersonId);
                entity.HasOne(p => p.Account)
                      .WithOne(a => a.Person)
                      .HasForeignKey<Person>(p => p.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.Faculty)
                      .WithMany(f => f.Person)
                      .HasForeignKey(p => p.FacultyId)
                      .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(f => f.FacultyId);
                entity.HasMany(f => f.Person)
                      .WithOne(p => p.Faculty)
                      .HasForeignKey(e => e.FacultyId)
                      .OnDelete(DeleteBehavior.Cascade);
                
            });



            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(s => s.SubjectId);
            });

            modelBuilder.Entity<StudentRegisteredSubject>(entity =>
            {
                entity.HasKey(k => new { k.StudentId, k.SubjectId ,k.ClassroomId,k.TeacherId,k.TimeId});
            });

            modelBuilder.Entity<StudentRegisteredSubject>(entity =>
            {
                entity.HasOne(e => e.Student)
                      .WithMany(s => s.StudentRegisteredSubject)
                      .HasForeignKey(k => k.StudentId);

            });

            modelBuilder.Entity<StudentRegisteredSubject>(entity =>
            {
                entity.HasOne(e => e.Subject)
                      .WithMany(s => s.StudentRegisteredSubject)
                      .HasForeignKey(k => k.SubjectId);
            });

           

            modelBuilder.Entity<SubjectClass>(e =>
            {
                e.HasKey(k => new { k.SubjectId, k.ClassroomId, k.TimeId, k.TeacherId });
            });


            modelBuilder.Entity<SubjectClass>(entity =>
            {
                entity.HasOne(e => e.Subject)
                      .WithMany(e => e.SubjectClass)
                      .HasForeignKey(e =>e.SubjectId);  
            });

            modelBuilder.Entity<SubjectClass>(entity =>
            {
                entity.HasOne(e => e.Classroom)
                      .WithMany(c => c.SubjectClass)
                      .HasForeignKey(e => e.ClassroomId);
            });

            modelBuilder.Entity<SubjectClass>(entity =>
            {
                entity.HasOne(e => e.Teacher)
                      .WithMany(t => t.SubjectClass)
                      .HasForeignKey(e => e.TeacherId);
            });

            modelBuilder.Entity<ClassTime>(entity =>
            {
                entity.HasKey(k => new {k.ClassroomId,k.TimeId});
            });

            modelBuilder.Entity<ClassTime>(entity =>
            {
                entity.HasOne(e => e.Classroom)
                      .WithMany(c => c.ClassTime)
                      .HasForeignKey(e => e.ClassroomId);
            });

            modelBuilder.Entity<ClassTime>(entity =>
            {
                entity.HasOne(e => e.Time)
                      .WithMany(t => t.ClassTime)
                      .HasForeignKey(e => e.TimeId);
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.HasKey(e => e.TimeId);

                entity.HasMany(e => e.SubjectClass)
                      .WithOne(s => s.Time)
                      .HasForeignKey(s => s.TimeId);    
            });

            modelBuilder.Entity<TeacherSubject>(entity =>
            {
                entity.HasKey(k => new { k.SubjectId, k.TeacherId });
            });

            modelBuilder.Entity<TeacherSubject>(entity =>
            {
                entity.HasOne(e => e.Teacher)
                      .WithMany(t => t.TeacherSubject)
                      .HasForeignKey( k => k.TeacherId);
            });

            modelBuilder.Entity<TeacherSubject>(entity =>
            {
                entity.HasOne(e => e.Subject)
                      .WithMany(s => s.TeacherSubject)
                      .HasForeignKey(k => k.SubjectId);
            });
            

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TruongBoMon> TruongBoMon { get; set; }
        public DbSet<TruongPhoKhoa> TruongPhoKhoa { get; set; }
        public DbSet<GiaoVu> GiaoVu { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentRegisteredSubject> StudentRegisteredSubject { get; set; }
        public DbSet<Classroom> Classroom { get; set; } 
        public DbSet<SubjectClass> SubjectClass { get; set; }
        public DbSet<Time> Time { get; set; }
        public DbSet<ClassTime> ClassTime { get; set; }
        public DbSet<TeacherSubject> TeacherSubject { get; set; }
        public DbSet<RoleAccount> RoleAccount { get; set; }
        
    }
}

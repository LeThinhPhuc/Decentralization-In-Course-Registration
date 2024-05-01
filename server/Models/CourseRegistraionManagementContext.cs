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
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);
                entity.HasOne(r => r.Account)
                      .WithOne(a => a.Role)
                      .HasForeignKey<Account>(a => a.RoleId);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.AccountId);
                entity.HasOne(a => a.Role) //specify that Account includes one Role reference navigation property
                      .WithOne(r => r.Account) //configures the other end of the relationship
                      .HasForeignKey<Account>(a => a.RoleId);
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
                      .WithOne(e => e.Stuent)
                      .HasForeignKey<Student>(t => t.PersonId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.PersonId);
                entity.HasOne(p => p.Account)
                      .WithOne(a => a.Person)
                      .HasForeignKey<Person>(p => p.AccountId);

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

                entity.HasMany(f => f.Subject)
                      .WithOne(s => s.Faculty)
                      .HasForeignKey(s => s.FacultyId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(s => s.SubjectId);
                entity.HasOne(s => s.Faculty)
                      .WithMany(f => f.Subject)
                      .HasForeignKey(s => s.SubjectId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.RegisteredSubject)
                      .WithOne(r => r.Subject)
                      .HasPrincipalKey<RegisteredSubject>(r => r.SubjectId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RegisteredSubject>(entity =>
            {
                entity.HasKey(r => r.RegisteredSubjecId);
                entity.HasOne(r => r.Subject)
                      .WithOne(s => s.RegisteredSubject)
                      .HasForeignKey<RegisteredSubject>(r => r.SubjectId)
                      .OnDelete(DeleteBehavior.Cascade);


            });

            modelBuilder.Entity<StudentRegisteredSubject>(e =>
            {
                e.HasKey(k => new { k.StudentId, k.RegisteredSubjectId });

            });

            modelBuilder.Entity<StudentRegisteredSubject>(entity =>
            {
                entity.HasOne(s => s.Student)
                      .WithMany(student => student.RegisteredSubjects)
                      .HasForeignKey(s => s.StudentId);
            });

            modelBuilder.Entity<StudentRegisteredSubject>(entity =>
            {
                entity.HasOne(s => s.RegisteredSubject)
                      .WithMany(r => r.Subjects)
                      .HasForeignKey(e => e.RegisteredSubjectId);
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
        public DbSet<RegisteredSubject> RegisteredSubject { get; set; }

        public DbSet<StudentRegisteredSubject> StudentRegisteredSubject { get; set; }
    }
}

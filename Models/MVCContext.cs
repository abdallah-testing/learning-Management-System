using Microsoft.EntityFrameworkCore;

namespace MVC.Models
{
    public class MVCContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsInstructor> CrsInstructors { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DELL-PRECISION7\\SQLEXPRESS;database=MVCDb;Integrated Security=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>(D =>
            {
                D.HasKey(d => d.Id);
                D.Property(d => d.Name).HasMaxLength(20);
                D.Property(d => d.ManagerName).HasMaxLength(20);

                D.HasMany(d => d.Instructors)
                   .WithOne(i => i.Department)
                   .HasForeignKey(i => i.DeptId)
                   .OnDelete(DeleteBehavior.NoAction);
                
                D.HasMany(d => d.Courses)
                   .WithOne(c => c.Department)
                   .HasForeignKey(c => c.DeptId)
                   .OnDelete(DeleteBehavior.NoAction);
                
                D.HasMany(d => d.Trainees)
                    .WithOne(t => t.Department)
                    .HasForeignKey(t => t.DeptId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CrsInstructor>(CI =>
            {
                CI.HasKey(ci => ci.Id);

                CI.HasOne(ci => ci.Course)
                    .WithMany(c => c.CrsInstructor)
                    .HasForeignKey(ci => ci.CrsId)
                    .OnDelete(DeleteBehavior.NoAction);

                CI.HasOne(ci => ci.Instructor)
                    .WithMany(i => i.CrsInstructor)
                    .HasForeignKey(ci => ci.InstructorId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CrsResult>(CR =>
            {
                CR.HasOne(cr => cr.Course)
                    .WithMany(c => c.CrsResults)
                    .OnDelete(DeleteBehavior.NoAction);

                CR.HasOne(cr => cr.Trainee)
                    .WithMany(t => t.CrsResults)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Instructor>(I =>
            {
                I.HasKey(i => i.Id);
                I.Property(i => i.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Course>(C =>
            {
                C.HasKey(c => c.Id);
                C.Property(c => c.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Instructor>(T =>
            {
                T.HasKey(t => t.Id);
                T.Property(t => t.Name).HasMaxLength(20);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CodeFirst
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet za vaše entitete
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // definiraj relaciju izmedju ocjena i studenata
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            // Seed podaci za Student entitet
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "Pero Perić", DateOfBirth = DateTime.Parse("2000-09-01"), Height = 1.75M, Weight = 70 },
                new Student { StudentId = 2, StudentName = "Ivo Ivić", DateOfBirth = DateTime.Parse("2000-01-15"), Height = 1.85M, Weight = 85 }
            );

            // Seed podaci za Enrollment entitet
            modelBuilder.Entity<Grade>().HasData(
                new Grade { GradeId = 1, GradeName = "odličan", Section = "Matematika", StudentId = 1 },
                new Grade { GradeId = 2, GradeName = "vrlo dobar", Section = "Hrvatski jezik", StudentId = 1 },
                new Grade { GradeId = 3, GradeName = "odličan", Section = "Biologija", StudentId = 1 },
                new Grade { GradeId = 4, GradeName = "dobar", Section = "Kemija", StudentId = 1 },
                new Grade { GradeId = 5, GradeName = "vrlo dobar", Section = "Matematika", StudentId = 2 },
                new Grade { GradeId = 6, GradeName = "odličan", Section = "Fizika", StudentId = 2 },
                new Grade { GradeId = 7, GradeName = "odličan", Section = "Hrvatski jezik", StudentId = 2 }

            );
        }
    }

    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }

    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}

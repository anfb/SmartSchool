using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId }); //Many to many
        }
    }
}
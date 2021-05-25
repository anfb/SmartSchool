using System.Collections.Generic;
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

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, "Lauro"),
                    new Teacher(2, "Roberto"),
                    new Teacher(3, "Ronaldo"),
                    new Teacher(4, "Rodrigo"),
                    new Teacher(5, "Alexandre"),
                });
            
            builder.Entity<Course>()
                .HasData(new List<Course>{
                    new Course(1, "Matemática", 1),
                    new Course(2, "Física", 2),
                    new Course(3, "Português", 3),
                    new Course(4, "Inglês", 4),
                    new Course(5, "Programação", 5)
                });
            
            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, "Marta", "Kent", "33225555"),
                    new Student(2, "Paula", "Isabela", "3354288"),
                    new Student(3, "Laura", "Antonia", "55668899"),
                    new Student(4, "Luiza", "Maria", "6565659"),
                    new Student(5, "Lucas", "Machado", "565685415"),
                    new Student(6, "Pedro", "Alvares", "456454545"),
                    new Student(7, "Paulo", "José", "9874512")
                });

            builder.Entity<StudentCourse>()
                .HasData(new List<StudentCourse>() {
                    new StudentCourse() {StudentId = 1, CourseId = 2 },
                    new StudentCourse() {StudentId = 1, CourseId = 4 },
                    new StudentCourse() {StudentId = 1, CourseId = 5 },
                    new StudentCourse() {StudentId = 2, CourseId = 1 },
                    new StudentCourse() {StudentId = 2, CourseId = 2 },
                    new StudentCourse() {StudentId = 2, CourseId = 5 },
                    new StudentCourse() {StudentId = 3, CourseId = 1 },
                    new StudentCourse() {StudentId = 3, CourseId = 2 },
                    new StudentCourse() {StudentId = 3, CourseId = 3 },
                    new StudentCourse() {StudentId = 4, CourseId = 1 },
                    new StudentCourse() {StudentId = 4, CourseId = 4 },
                    new StudentCourse() {StudentId = 4, CourseId = 5 },
                    new StudentCourse() {StudentId = 5, CourseId = 4 },
                    new StudentCourse() {StudentId = 5, CourseId = 5 },
                    new StudentCourse() {StudentId = 6, CourseId = 1 },
                    new StudentCourse() {StudentId = 6, CourseId = 2 },
                    new StudentCourse() {StudentId = 6, CourseId = 3 },
                    new StudentCourse() {StudentId = 6, CourseId = 4 },
                    new StudentCourse() {StudentId = 7, CourseId = 1 },
                    new StudentCourse() {StudentId = 7, CourseId = 2 },
                    new StudentCourse() {StudentId = 7, CourseId = 3 },
                    new StudentCourse() {StudentId = 7, CourseId = 4 },
                    new StudentCourse() {StudentId = 7, CourseId = 5 }
                });
        }
    }
}
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Data
{
    public class Repository : IRepository
    {

        #region VARIABLES
        private readonly SmartContext context;
        
        #endregion

        public Repository(SmartContext context)
        {
            this.context = context;
        }

        #region PUBLIC METHODS
        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }
        public bool SaveChanges()
        {
            return (this.context.SaveChanges() > 0);
        }

        public Student[] GetAllStudents(bool includeTeacher = false)
        {
            IQueryable<Student> query = this.context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsCourse)
                             .ThenInclude(sc => sc.Course)
                             .ThenInclude(c => c.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);
            return query.ToArray();
        }

        public Student[] GetAllStudentsByCourseId(int courseId, bool includeTeacher = false)
        {
             IQueryable<Student> query = this.context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsCourse)
                             .ThenInclude(sc => sc.Course)
                             .ThenInclude(c => c.Teacher);
            }

            query = query.AsNoTracking()
            .OrderBy(s => s.Id)
            .Where(s => s.StudentsCourse.Any(sc => sc.CourseId == courseId));
            
            return query.ToArray();
        }

        public Student GetStudentById(int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = this.context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsCourse)
                             .ThenInclude(sc => sc.Course)
                             .ThenInclude(c => c.Teacher);
            }

            query = query.AsNoTracking()
            .OrderBy(s => s.Id)
            .Where(s => s.Id == studentId);
            
            return query.FirstOrDefault();
        }

        public Teacher[] GetAllTeachers(bool includeStudents = false)
        {
            IQueryable<Teacher> query = this.context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Courses)
                             .ThenInclude(c => c.StudentsCourse)
                             .ThenInclude(sc => sc.Student);
            }

            query = query.AsNoTracking().OrderBy(t => t.Id);
            return query.ToArray();
        }

        public Teacher[] GetAllTeachersByCourseId(int courseId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = this.context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Courses)
                            .ThenInclude(c => c.StudentsCourse)
                            .ThenInclude(sc => sc.Student);
            }

            query = query.AsNoTracking()
                        .OrderBy(s => s.Id)
                        .Where(s => s.Courses.Any(
                            d => d.StudentsCourse.Any(
                                ad => ad.CourseId == courseId)));

            return query.ToArray();
        }

        public Teacher GetTeacherById(int teacherId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = this.context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Courses)
                            .ThenInclude(c => c.StudentsCourse)
                            .ThenInclude(sc => sc.Student);
            }

            query = query.AsNoTracking()
                        .OrderBy(t => t.Id)
                        .Where(t => t.Id == teacherId);
            
            return query.FirstOrDefault();
        }

        #endregion

    }
}
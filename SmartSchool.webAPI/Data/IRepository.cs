using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Data
{
    public interface IRepository
    {
        public void Add<T>(T entity) where T : class;
        public void  Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;  
        public bool SaveChanges(); 

        # region STUDENT METHODS
        public Student [] GetAllStudents(bool includeTeacher = false);
        public Student [] GetAllStudentsByCourseId(int courseId, bool includeTeacher = false);
        public Student GetStudentById(int studentId, bool includeTeacher = false);
        #endregion

        # region TEACHER METHODS
        public Teacher [] GetAllTeachers(bool includeStudents = false);
        public Teacher [] GetAllTeachersByCourseId(int courseId, bool includeStudents = false);
        public Teacher GetTeacherById(int teacherId, bool includeStudents = false);

        #endregion
    }
}
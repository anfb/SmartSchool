using System.Collections.Generic;

namespace SmartSchool.webAPI.Models
{
    public class Course
    {
        public Course(){}
        public Course(int id, string description, int teacherId)
        {
            this.Id = id;
            this.Description = description;
            this.TeacherId = teacherId;
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<StudentCourse> StudentsCourse { get; set; }
    }
}
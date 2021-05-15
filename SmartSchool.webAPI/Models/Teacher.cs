using System.Collections.Generic;

namespace SmartSchool.webAPI.Models
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
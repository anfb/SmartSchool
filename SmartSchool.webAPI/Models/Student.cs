using System.Collections.Generic;

namespace SmartSchool.webAPI.Models
{
    public class Student
    {
        public Student() { }
        public Student(int id, string name, string lastName, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<StudentCourse> StudentsCourse { get; set; }
    }
}
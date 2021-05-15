using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // api/controllerName
    public class StudentController : ControllerBase
    {
        public List<Student> students = new List<Student>(){
            new Student(){
                Id = 1,
                Name = "Carlos",
                LastName = "Barbosa",
                PhoneNumber = "(81) 9 8547-4145"
            },
            new Student(){
                Id = 2,
                Name = "Artur",
                LastName = "Barbosa",
                PhoneNumber = "(81) 9 8547-4145"
            },
            new Student(){
                Id = 3,
                Name = "João",
                LastName = "Barbosa",
                PhoneNumber = "(81) 9 8547-4145"
            },
            new Student(){
                Id = 4,
                Name = "Adriano",
                LastName = "Barbosa",
                PhoneNumber = "(81) 9 8547-4145"
            }
        };
        public StudentController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(students);
        }

        // .../api/Student/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Student student = students.FirstOrDefault(a => a.Id == id);
            if(student == null) return BadRequest("Student was not found.");
            return Ok(student);
        }
    }
}
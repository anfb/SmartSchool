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

        // .../api/Student/byId?id=1
        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
            Student student = students.FirstOrDefault(a => a.Id == id);
            if(student == null) return BadRequest("Student was not found.");
            return Ok(student);
        }

        // .../api/Student/byName?name=Fulano&lastname=barbosa
        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string lastName){
            Student student = students.FirstOrDefault(a => a.Name.ToUpperInvariant().ToLowerInvariant().Contains(name.ToUpperInvariant().ToLowerInvariant()) 
                                                        && a.LastName.ToUpperInvariant().ToLowerInvariant().Contains(lastName.ToUpperInvariant().ToLowerInvariant()));
            if(student == null) return BadRequest("Student was not found.");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent(Student student){
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutSudent(int id, Student student){
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchSudent(int id, Student student){
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id){
            return Ok();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Data;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // api/controllerName
    public class StudentController : ControllerBase
    {
        #region VARIABLES
        private readonly IRepository repository;
        #endregion
        public StudentController(IRepository repository) 
        {
            this.repository = repository;
        }
    
        [HttpGet]
        public IActionResult Get()
        {
            var students = this.repository.GetAllStudents(true);
            return Ok(students);
        }

        [HttpGet("{Id}")]
        public IActionResult GetStudentById(int id)
        {
            Student student = this.repository.GetStudentById(id, false);
            if(student == null) return BadRequest("Teacher does not exists.");
            
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            this.repository.Add(student);
            if (this.repository.SaveChanges()) return Ok(student);
            
            return BadRequest("Student was not found.");
        }

        [HttpPut("{id}")]
        public IActionResult PutSudent(int id, Student student)
        {
            Student _student = this.repository.GetStudentById(id);
            if(_student == null) return BadRequest("Student does not exists.");

            this.repository.Update(student);
            if(this.repository.SaveChanges()) return Ok(student);

            return BadRequest("Student not updated.");
        }

        [HttpPatch("{id}")]
        public IActionResult PatchSudent(int id, Student student)
        {
            Student _student = this.repository.GetStudentById(id);
            if(_student == null) return BadRequest("Student does not exists.");

            this.repository.Update(student);
            if(this.repository.SaveChanges()) return Ok(student);

            return BadRequest("Student not updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student _student = this.repository.GetStudentById(id);
            if(_student == null) return BadRequest("Student does not exists.");
            
            this.repository.Delete(_student); 
            if(this.repository.SaveChanges()) return Ok("Student was deleted.");
            
            return BadRequest("Student was not deleted.");
        }

    }
}
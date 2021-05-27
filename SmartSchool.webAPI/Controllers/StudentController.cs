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
        private readonly SmartContext context;
        #endregion
        public StudentController(SmartContext context) 
        {
            this.context = context;
        }
    
        #region PUBLIC METHODS
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Students);
        }

        // .../api/Student/byId?id=1
        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
            Student student = this.context.Students.FirstOrDefault(a => a.Id == id);
            if (student == null) return BadRequest("Student was not found.");
            return Ok(student);
        }

        // .../api/Student/byName?name=Fulano&lastname=barbosa
        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string lastName)
        {
            Student student = this.context.Students.FirstOrDefault(a => a.Name.Contains(name)
                                                        && a.LastName.Contains(lastName));
            if (student == null) return BadRequest("Student was not found.");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            this.context.Add(student);
            this.context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutSudent(int id, Student student)
        {
            Student sdt = this.context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if(sdt == null) return BadRequest("Invalid Path! Student does not exists.");
            
            this.context.Update(student);
            this.context.SaveChanges();
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchSudent(int id, Student student)
        {
            Student sdt = this.context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if(sdt == null) return BadRequest("Invalid Path! Student does not exists.");

            this.context.Update(student);
            this.context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student student = this.context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return BadRequest("Student does not exists.");

            this.context.Remove(student);
            this.context.SaveChanges();
            return Ok();
        }
        #endregion  
    }
}
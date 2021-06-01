using Microsoft.AspNetCore.Mvc;
using SmartSchool.webAPI.Data;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/controllerName
    public class TeacherController : ControllerBase
    {
        #region VARIABLES
        private readonly IRepository repository;
        #endregion

        public TeacherController(IRepository repository) 
        { 
            this.repository = repository;
        }
 
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.repository.GetAllTeachers(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            Teacher teacher = this.repository.GetTeacherById(id, false);
            if(teacher == null) return BadRequest("Teacher does not exists.");
            
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult PostTeacher(Teacher teacher) 
        {
            this.repository.Add(teacher);
            if (this.repository.SaveChanges()) return Ok(teacher);
            
            return BadRequest("Teacher was not found.");
        }

        [HttpPut("{id}")]
        public IActionResult PutTeacher(int id, Teacher teacher)
        {
            Teacher _teacher = this.repository.GetTeacherById(id);
            if(_teacher == null) return BadRequest("Teacher does not exists.");

            this.repository.Update(teacher);
            if(this.repository.SaveChanges()) return Ok(teacher);

            return BadRequest("Teacher not updated.");
        }

        [HttpPatch("{id}")]
        public IActionResult PathTeacher(int id, Teacher teacher)
        {
            Teacher _teacher = this.repository.GetTeacherById(id);
            if(_teacher == null) return BadRequest("Teacher does not exists.");

            this.repository.Update(teacher);
            if(this.repository.SaveChanges()) return Ok(teacher);

            return BadRequest("Teacher not updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTeacher(int id)
        {
            Teacher _teacher = this.repository.GetTeacherById(id);
            if(_teacher == null) return BadRequest("Teacher does not exists.");
            
            this.repository.Delete(_teacher); 
            if(this.repository.SaveChanges()) return Ok("Teacher was deleted.");
            
            return BadRequest("Teacher was not deleted.");
        }

    }
}
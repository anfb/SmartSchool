using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Data;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // api/controllerName
    public class TeacherController : ControllerBase
    {
        private readonly SmartContext context;
        public TeacherController(SmartContext context) 
        { 
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Teachers);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            Teacher teacher = this.context.Teachers.FirstOrDefault(t => t.Id == id);
            if(teacher == null) return BadRequest($"Teacher with id equal {id} does not exist.");

            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult PostTeacher(Teacher teacher)
        {
            this.context.Add(teacher);
            this.context.SaveChanges();
            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public IActionResult PutTeacher(int id, Teacher teacher)
        {
            Teacher existedTeacher = this.context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if(existedTeacher == null) return BadRequest($"Teacher with Id {id} does not exists.");

            this.context.Update(teacher);
            this.context.SaveChanges();
            return Ok(teacher);
        }

        [HttpPatch("{id}")]
        public IActionResult PathTeacher(int id, Teacher teacher)
        {
            Teacher existedTeacher = this.context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if(existedTeacher == null) return BadRequest($"Teacher with id {id} does not exists.");

            this.context.Update(teacher);
            this.context.SaveChanges();
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTeacher(int id)
        {
            Teacher teacher = this.context.Teachers.FirstOrDefault(t => t.Id == id);
            if(teacher == null) return BadRequest("This teacher does not exists.");

            this.context.Remove(teacher);
            this.context.SaveChanges();
            return Ok(); 
        }
    }
}
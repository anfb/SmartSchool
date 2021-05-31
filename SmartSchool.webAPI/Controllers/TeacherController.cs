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
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostTeacher(Teacher teacher)
        {
            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public IActionResult PutTeacher(int id, Teacher teacher)
        {
            return Ok(teacher);
        }

        [HttpPatch("{id}")]
        public IActionResult PathTeacher(int id, Teacher teacher)
        {
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTeacher(int id)
        {
            return Ok(); 
        }
        
    }
}
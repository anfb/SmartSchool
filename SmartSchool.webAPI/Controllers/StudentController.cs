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
    
        #region PUBLIC METHODS
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // .../api/Student/byId?id=1
        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // .../api/Student/byName?name=Fulano&lastname=barbosa
        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string lastName)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutSudent(int id, Student student)
        {
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchSudent(int id, Student student)
        {
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok();
        }
        
        #endregion  
    }
}
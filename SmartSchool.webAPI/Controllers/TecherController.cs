using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.webAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // api/controllerName
    public class TeacherController : ControllerBase
    {
        public TeacherController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Teacher: Luan, Julia, David");
        }
    }
}
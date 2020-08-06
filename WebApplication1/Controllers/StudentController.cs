using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService studentService;
        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var stud = studentService.GetStudentById(id);
            if(stud == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            else
            {
                return Ok(stud);
            }
        }

        [HttpPost]
        public IActionResult Post(Student newStudent)
        {
            bool retValue = studentService.NewStudent(newStudent);
            if(retValue)
            {
                return Ok("Saved the student successfully");
            }
            else
            {
                return BadRequest("Failed Saving the details");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student currStudent)
        {
            if(currStudent == null || id == 0)
            {
                return BadRequest("Failed Saving the details");
            }

            bool retValue = studentService.UpdateStudent(id, currStudent);
            if (retValue)
            {
                return Ok("Saved the student successfully");
            }
            else
            {
                return BadRequest("Failed Saving the details");
            }
        }
    }
}

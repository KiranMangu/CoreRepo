using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/employeeqs")]
    [ApiController]
    public class EmployeeQSController : ControllerBase
    {
        static List<EmployeeQS> employees = new List<EmployeeQS>{
        new EmployeeQS        {Id = 1,             Name = "Ramu",        Department = "Administration"},
        new EmployeeQS        {Id = 2,             Name = "Kumar",       Department = "Administration"},
        new EmployeeQS        {Id = 3,             Name = "Kishore",     Department = "HR"},
        new EmployeeQS        {Id = 4,             Name = "Abhiram",     Department = "Accountant"},
        new EmployeeQS        {Id = 5,             Name = "Suresh",      Department = "IT"},
        };
        [HttpGet()]
        public IEnumerable<EmployeeQS> Get()
        {
            return employees;
        }

        [HttpGet("Get/{id}")]
        public EmployeeQS Get(int id)
        {
            return employees.Find(emp => emp.Id == id);
        }

        [HttpPost("Post")]
        public void Post(EmployeeQS emp)
        {

            employees.Add(emp);
        }

        [HttpPut("Put/{id}")]
        public void Put(int id, EmployeeQS emp)
        {
            EmployeeQS currEmp = employees.Find(emp => emp.Id == id);
            currEmp.Name = emp.Name;
            currEmp.Department = emp.Department;
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            employees.Remove(employees.Find(emp => emp.Id == id));
        }
    }

}

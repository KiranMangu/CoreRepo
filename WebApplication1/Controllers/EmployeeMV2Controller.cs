using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/employeemv2")]
    [ApiController]
    public class EmployeeMV2Controller : ControllerBase
    {
        static List<EmployeeMV2> employees = new List<EmployeeMV2>{
        new EmployeeMV2        {Id = 1,             Name = "Ramu",        Department = "Administration"},
        new EmployeeMV2        {Id = 2,             Name = "Kumar",       Department = "Administration"},
        new EmployeeMV2        {Id = 3,             Name = "Kishore",     Department = "HR"},
        new EmployeeMV2        {Id = 4,             Name = "Abhiram",     Department = "Accountant"},
        new EmployeeMV2        {Id = 5,             Name = "Suresh",      Department = "IT"},
        };
        [HttpGet()]
        public IEnumerable<EmployeeMV2> Get()
        {
            return employees;
        }

        [HttpGet("Get/{id}")]
        public EmployeeMV2 Get(int id)
        {
            return employees.Find(emp => emp.Id == id);
        }

        [HttpPost("Post")]
        public void Post(EmployeeMV2 emp)
        {

            employees.Add(emp);
        }

        [HttpPut("Put/{id}")]
        public void Put(int id, EmployeeMV2 emp)
        {
            EmployeeMV2 currEmp = employees.Find(emp => emp.Id == id);
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

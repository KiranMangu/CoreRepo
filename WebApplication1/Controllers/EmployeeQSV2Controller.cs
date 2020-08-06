using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/employeeqs")]
    [ApiController]
    public class EmployeeQSV2Controller : ControllerBase
    {
        static List<EmployeeQSV2> employees = new List<EmployeeQSV2>{
        new EmployeeQSV2        {Id = 1,             Name = "Ramu",        Department = "Administration"},
        new EmployeeQSV2        {Id = 2,             Name = "Kumar",       Department = "Administration"},
        new EmployeeQSV2        {Id = 3,             Name = "Kishore",     Department = "HR"},
        new EmployeeQSV2        {Id = 4,             Name = "Abhiram",     Department = "Accountant"},
        new EmployeeQSV2        {Id = 5,             Name = "Suresh",      Department = "IT"},
        };
        [HttpGet()]
        public IEnumerable<EmployeeQSV2> Get()
        {
            return employees;
        }

        [HttpGet("Get/{id}")]
        public EmployeeQSV2 Get(int id)
        {
            return employees.Find(emp => emp.Id == id);
        }

        [HttpPost("Post")]
        public void Post(EmployeeQSV2 emp)
        {

            employees.Add(emp);
        }

        [HttpPut("Put/{id}")]
        public void Put(int id, EmployeeQSV2 emp)
        {
            EmployeeQSV2 currEmp = employees.Find(emp => emp.Id == id);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>{
        new Employee        {Id = 1,             Name = "Ramu",        Department = "Administration"},
        new Employee        {Id = 2,             Name = "Kumar",       Department = "Administration"},
        new Employee        {Id = 3,             Name = "Kishore",     Department = "HR"},
        new Employee        {Id = 4,             Name = "Abhiram",     Department = "Accountant"},
        new Employee        {Id = 5,             Name = "Suresh",      Department = "IT"},
        };

        [HttpGet()]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        [HttpGet("Get/{id}")]
        public Employee Get(int id)
        {
            return employees.Find(emp => emp.Id == id);
        }

        [HttpPost("Post")]
        public void Post(Employee emp)
        {

            employees.Add(emp);
        }

        [HttpPut("Put/{id}")]
        public void Put(int id, Employee emp)
        {
            Employee currEmp = employees.Find(emp => emp.Id == id);
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

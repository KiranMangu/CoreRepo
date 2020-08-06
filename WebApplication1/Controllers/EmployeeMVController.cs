using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/employeemv1")]
    [ApiController]
    public class EmployeeMVController : ControllerBase
    {
        static List<EmployeeMV> employees = new List<EmployeeMV>{
        new EmployeeMV        {Id = 1,             Name = "Ramu",        Department = "Administration"},
        new EmployeeMV        {Id = 2,             Name = "Kumar",       Department = "Administration"},
        new EmployeeMV        {Id = 3,             Name = "Kishore",     Department = "HR"},
        new EmployeeMV        {Id = 4,             Name = "Abhiram",     Department = "Accountant"},
        new EmployeeMV        {Id = 5,             Name = "Suresh",      Department = "IT"},
        };
        [HttpGet()]
        public IEnumerable<EmployeeMV> Get()
        {
            return employees;
        }

        [HttpGet("Get/{id}")]
        public EmployeeMV Get(int id)
        {
            return employees.Find(emp => emp.Id == id);
        }

        [HttpPost("Post")]
        public void Post(EmployeeMV emp)
        {

            employees.Add(emp);
        }

        [HttpPut("Put/{id}")]
        public void Put(int id, EmployeeMV emp)
        {
            EmployeeMV currEmp = employees.Find(emp => emp.Id == id);
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

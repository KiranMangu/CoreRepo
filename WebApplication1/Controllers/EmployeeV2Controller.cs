using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiController]
    public class EmployeeV2Controller : ControllerBase
    {
        static List<EmployeeV2> employees = new List<EmployeeV2>{
        new EmployeeV2        {Id = 1,             Name = "Ramu",        Department = "Administration"},
        new EmployeeV2        {Id = 2,             Name = "Kumar",       Department = "Administration"},
        new EmployeeV2        {Id = 3,             Name = "Kishore",     Department = "HR"},
        new EmployeeV2        {Id = 4,             Name = "Abhiram",     Department = "Accountant"},
        new EmployeeV2        {Id = 5,             Name = "Suresh",      Department = "IT"},
        };
        public IEnumerable<EmployeeV2> Get()
        {
            return employees;
        }

        [HttpGet("{id}")]
        public EmployeeV2 Get(int id)
        {
            return employees.Find(emp => emp.Id == id);
        }

        [HttpPost()]
        public void Post(EmployeeV2 emp)
        {

            employees.Add(emp);
        }

        [HttpPut("{id}")]
        public void Put(int id, EmployeeV2 emp)
        {
            EmployeeV2 currEmp = employees.Find(emp => emp.Id == id);
            currEmp.Name = emp.Name;
            currEmp.Department = emp.Department;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employees.Remove(employees.Find(emp => emp.Id == id));
        }
    }

}

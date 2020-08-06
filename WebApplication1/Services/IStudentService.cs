using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int Id);
        Boolean NewStudent(Student newStudent);
        Boolean UpdateStudent(int Id, Student currStudent);
        Boolean RemoveStudent(int Id);
    }
}

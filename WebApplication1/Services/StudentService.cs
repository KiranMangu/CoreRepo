using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DBContext;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        StudentDbContext studentDBContext;
        public StudentService(StudentDbContext _studentDBContext)
        {
            studentDBContext = _studentDBContext;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return studentDBContext.Students;
        }

        public Student GetStudentById(int Id)
        {
            return studentDBContext.Students.FirstOrDefault(std => std.Id == Id);
        }

        public bool NewStudent(Student newStudent)
        {
            try
            {
                studentDBContext.Add(newStudent);
                studentDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RemoveStudent(int Id)
        {
            var currStd = studentDBContext.Students.FirstOrDefault(std => std.Id == Id);
            if (currStd == null)
                return false;
            else
            {
                try
                {
                    studentDBContext.Students.Remove(currStd);
                    studentDBContext.SaveChanges();
                    return true; 
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool UpdateStudent(int Id, Student currStudent)
        {
            var currStd = studentDBContext.Students.FirstOrDefault(std => std.Id == Id);
            if (currStd == null)
                return false;
            else
            {
                try
                {
                    currStd.Name = currStudent.Name;
                    //currStd.Course = currStudent.Course;
                    studentDBContext.Update(currStd);
                    studentDBContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            //throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.DBContext
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}

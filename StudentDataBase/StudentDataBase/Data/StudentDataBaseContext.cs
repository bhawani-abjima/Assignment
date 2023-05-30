using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentDataBase.Models;

namespace StudentDataBase.Data
{
    public class StudentDataBaseContext : DbContext
    {
        public StudentDataBaseContext (DbContextOptions<StudentDataBaseContext> options)
            : base(options)
        {
        }

        /*protected override void OnModelCreating(ModelBuilder Student)
        {
            Student.Entity<Student>().ToTable("Studentdata");
        }*/

        public DbSet<Student> Student { get; set; } = default!;
    }
}

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

        public DbSet<StudentDataBase.Models.Student> Student { get; set; } = default!;
    }
}

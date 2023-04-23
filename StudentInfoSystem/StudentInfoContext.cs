using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentInfoContext : DbContext
    {
        public StudentInfoContext() : base("Server=localhost\\GAS-LAPTOP;Database=StudentInfoDatabase;Trusted_Connection=True;") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

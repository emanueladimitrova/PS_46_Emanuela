using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace UserLogin
{
    internal class UserContext : DbContext
    {
        public UserContext() : base("Server=localhost\\GAS-LAPTOP;Database=StudentInfoDatabase;Trusted_Connection=True;") { }
        public DbSet<User> Users { get; set; }
    }
}

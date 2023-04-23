using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace UserLogin
{
    internal class LoggerContext : DbContext
    {
        public LoggerContext() : base("Server=localhost\\SQLEXPRESS;Database=Student_Info_Database;Trusted_Connection=True;") { }
        public DbSet<LogEntity> Logs { get; set; }
    }
}

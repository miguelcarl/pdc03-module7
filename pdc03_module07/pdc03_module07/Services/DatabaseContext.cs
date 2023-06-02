using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using pdc03_module07.Model;
using System.IO;
using Microsoft.Extensions.Options;

namespace pdc03_module07.Services
{
    public class DatabaseContext:DbContext
    {   
        public DbSet<EmployeeModel> Employees { get; set; }
        public DatabaseContext() 
        { 
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Employee.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}

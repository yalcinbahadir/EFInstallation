using EFInstallation.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInstallation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

       
        //For connection string check App.config
        //base class -DbContext- needs a connection string in order to communucate with the database
        public ApplicationDbContext():base("defaultConnection")
        {

        }
        //For Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
            //Model-wide configuration
            modelBuilder.HasDefaultSchema("TestSolutionDb");
            //Entity configuration
            modelBuilder.Entity<Employee>().ToTable("Workers");
            //Property configuration
            modelBuilder.Entity<Employee>().Property(p => p.FirstName).HasMaxLength(25);
            base.OnModelCreating(modelBuilder);
        }
    }
}

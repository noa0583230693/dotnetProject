using Clean.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Clean.DATA.Data
{ 
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
         : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
     
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectAssignment> Assignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // 1. הגבלת אורך של תפקיד העובד בפרויקט
      

            //// 3. טבלת ProjectAssignment עם מפתח מורכב
            //modelBuilder.Entity<ProjectAssignment>()
            //    .HasKey(pa => new { pa.ProjectId, pa.EmployeeId });
        }



    }
}




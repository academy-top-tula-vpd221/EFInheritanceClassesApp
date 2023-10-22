using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EFInheritanceClassesApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFModrelCreateApp
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<EmployeeSalary> EmployeesSalaries { get; set; } = null!;
        public DbSet<EmployeePosition> EmployeePositions { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=temp2_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            // Fluent API
            base.OnModelCreating(modelBuilder);

            //TPT
            //modelBuilder.Entity<Employee>().ToTable("Empl");
            //modelBuilder.Entity<EmployeeSalary>().ToTable("EmplSalary");
            //modelBuilder.Entity<EmployeePosition>().ToTable("EmplPosition");

            // TPH - Table Per Hiearchy
            // TPT - Table Per Type
            // TPC - Table Per Concrete Type (Class)

            modelBuilder.Entity<Employee>().UseTpcMappingStrategy();
            modelBuilder.Entity<Employee>()
                        .ToTable("Employees", t => t.Property(e => e.Id)
                                                    .UseIdentityColumn(1, 1));
            modelBuilder.Entity<EmployeeSalary>()
                        .ToTable("EmployeesSalary", t => t.Property(e => e.Id)
                                                    .UseIdentityColumn(10000, 1));
            modelBuilder.Entity<EmployeePosition>()
                        .ToTable("EmployeesPosition", t => t.Property(e => e.Id)
                                                    .UseIdentityColumn(20000, 1));
        }
    }

}

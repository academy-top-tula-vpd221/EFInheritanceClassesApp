using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInheritanceClassesApp
{
    public class Employee
    {
        public int Id { get; set; } // = Guid.NewGuid();
        public string? Name { get; set;}
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }

    //[Table("EmplSalaries")]
    public class EmployeeSalary : Employee
    {
        public int Salary { set; get; }

        public override string ToString()
        {
            return base.ToString() + $", Salary: {Salary}";
        }
    }

    //[Table("EmplPositions")]
    public class EmployeePosition : Employee
    {
        public string? Position { set; get; }

        public override string ToString()
        {
            return base.ToString() + $", Position: {Position}";
        }
    }


}

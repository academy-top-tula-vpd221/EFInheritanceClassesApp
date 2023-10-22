using EFInheritanceClassesApp;
using EFModrelCreateApp;

using (ApplicationContext context = new())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    context.Employees.Add(new Employee() { Name = "Bob" });
    context.EmployeesSalaries.Add(new EmployeeSalary() { Name = "Joe", Salary = 100000 });
    context.EmployeePositions.Add(new EmployeePosition() { Name = "Sam", Position = "Manager" });

    context.SaveChanges();
}


using (ApplicationContext context = new())
{
    var employees = context.Employees.ToList();
    foreach (var employee in employees)
        Console.WriteLine(employee);
}

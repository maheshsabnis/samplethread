using System.Collections.Concurrent;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Concurrent Dictionary Updates");

ConcurrentDictionary<int, Employee> Employees = new ConcurrentDictionary<int, Employee>();

Employees.TryAdd(1, new Employee() { EmpNo = 101, EmpName = "Abhay", Salary = 11000 });

Employees.TryAdd(2, new Employee() { EmpNo = 102, EmpName = "Baban", Salary = 22000 });

Employees.TryAdd(3, new Employee() { EmpNo = 103, EmpName = "Chaitanya", Salary = 33000 });

Employees.TryAdd(4, new Employee() { EmpNo = 104, EmpName = "Deepak", Salary = 44000 });

Employees.TryAdd(5, new Employee() { EmpNo = 105, EmpName = "Eshwar", Salary = 55000 });

Employees.TryAdd(6, new Employee() { EmpNo = 106, EmpName = "Falgun", Salary = 66000 });

Employees.TryAdd(7, new Employee() { EmpNo = 107, EmpName = "Ganpat", Salary = 77000 });

Employees.TryAdd(8, new Employee() { EmpNo = 108, EmpName = "Hitesh", Salary = 88000 });

Employees.TryAdd(9, new Employee() { EmpNo = 109, EmpName = "Ishan", Salary = 99000 });

Employees.TryAdd(10, new Employee() { EmpNo = 111, EmpName = "Kaushubh", Salary = 21000 });

Employees.TryAdd(11, new Employee() { EmpNo = 112, EmpName = "Lakshman", Salary = 22000 });

Employees.TryAdd(12, new Employee() { EmpNo = 113, EmpName = "Mohan", Salary = 23000 });

Employees.TryAdd(13, new Employee() { EmpNo = 114, EmpName = "Naveen", Salary = 24000 });

Employees.TryAdd(14, new Employee() { EmpNo = 115, EmpName = "Omkar", Salary = 25000 });

Employees.TryAdd(15, new Employee() { EmpNo = 116, EmpName = "Prakash", Salary = 26000 });

Employees.TryAdd(16, new Employee() { EmpNo = 117, EmpName = "Qumars", Salary = 27000 });

Employees.TryAdd(17, new Employee() { EmpNo = 118, EmpName = "Ramesh", Salary = 28000 });

Employees.TryAdd(18, new Employee() { EmpNo = 119, EmpName = "Sachin", Salary = 29000 });

Employees.TryAdd(19, new Employee() { EmpNo = 120, EmpName = "Tushar", Salary = 30000 });

Employees.TryAdd(20, new Employee() { EmpNo = 121, EmpName = "Umesh", Salary = 31000 });

Employees.TryAdd(21, new Employee() { EmpNo = 122, EmpName = "Vivek", Salary = 32000 });

Employees.TryAdd(22, new Employee() { EmpNo = 123, EmpName = "Waman", Salary = 33000 });

Employees.TryAdd(23, new Employee() { EmpNo = 124, EmpName = "Xavier", Salary = 34000 });

Employees.TryAdd(24, new Employee() { EmpNo = 125, EmpName = "Yadav", Salary = 35000 });

Employees.TryAdd(25, new Employee() { EmpNo = 126, EmpName = "Zishan", Salary = 36000 });
Console.WriteLine("The Original Data");
PrintData();
Console.WriteLine();
Console.WriteLine("EMployees after Tax Calculation");

Task taskTDS = Task.Factory.StartNew(() =>
{
    CalculateTax();
});

//PrintData();
Console.WriteLine();
Console.WriteLine("Employees After Updating Salary");
Task taskUpdateSalary = Task.Factory.StartNew(() =>
{
    UpdateSalary();
});
//PrintData();


Console.ReadLine();

void CalculateTax()
{
      (from record in Employees.Values
                  select record).ToList().
    ForEach(emp => emp.TDS = Convert.ToDecimal(emp.Salary * 0.1));
    Console.WriteLine("Employees After Calculating Tax");
    PrintData();
}

void UpdateSalary()
{
    (from record in Employees.Values
     select record).ToList().
   ForEach(emp => emp.Salary = emp.Salary * 2);
    Console.WriteLine("Employees After Updating Salary");
    PrintData();
}

void PrintData()
{
    foreach (var record in Employees)
    {
        Console.WriteLine($"{record.Value.EmpNo} {record.Value.EmpName} {record.Value.Salary} {record.Value.TDS}");
    }
}
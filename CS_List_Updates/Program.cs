using System.Collections;
// See https://aka.ms/new-console-template for more information
Console.WriteLine(" Liost Updates");
// Data
List<Employee> Employees = new List<Employee>();

Employees.Add(new Employee() { EmpNo = 101, EmpName = "Abhay", Salary = 11000 });

Employees.Add(new Employee() { EmpNo = 102, EmpName = "Baban", Salary = 22000 });

Employees.Add(new Employee() { EmpNo = 103, EmpName = "Chaitanya", Salary = 33000 });

Employees.Add(new Employee() { EmpNo = 104, EmpName = "Deepak", Salary = 44000 });

Employees.Add(new Employee() { EmpNo = 105, EmpName = "Eshwar", Salary = 55000 });

Employees.Add(new Employee() { EmpNo = 106, EmpName = "Falgun", Salary = 66000 });

Employees.Add(new Employee() { EmpNo = 107, EmpName = "Ganpat", Salary = 77000 });

Employees.Add(new Employee() { EmpNo = 108, EmpName = "Hitesh", Salary = 88000 });

Employees.Add(new Employee() { EmpNo = 109, EmpName = "Ishan", Salary = 99000 });

Employees.Add(new Employee() { EmpNo = 111, EmpName = "Kaushubh", Salary = 21000 });

Employees.Add(new Employee() { EmpNo = 112, EmpName = "Lakshman", Salary = 22000 });

Employees.Add(new Employee() { EmpNo = 113, EmpName = "Mohan", Salary = 23000 });

Employees.Add(new Employee() { EmpNo = 114, EmpName = "Naveen", Salary = 24000 });

Employees.Add(new Employee() { EmpNo = 115, EmpName = "Omkar", Salary = 25000 });

Employees.Add(new Employee() { EmpNo = 116, EmpName = "Prakash", Salary = 26000 });

Employees.Add(new Employee() { EmpNo = 117, EmpName = "Qumars", Salary = 27000 });

Employees.Add(new Employee() { EmpNo = 118, EmpName = "Ramesh", Salary = 28000 });

Employees.Add(new Employee() { EmpNo = 119, EmpName = "Sachin", Salary = 29000 });

Employees.Add(new Employee() { EmpNo = 120, EmpName = "Tushar", Salary = 30000 });

Employees.Add(new Employee() { EmpNo = 121, EmpName = "Umesh", Salary = 31000 });

Employees.Add(new Employee() { EmpNo = 122, EmpName = "Vivek", Salary = 32000 });

Employees.Add(new Employee() { EmpNo = 123, EmpName = "Waman", Salary = 33000 });

Employees.Add(new Employee() { EmpNo = 124, EmpName = "Xavier", Salary = 34000 });

Employees.Add(new Employee() { EmpNo = 125, EmpName = "Yadav", Salary = 35000 });

Employees.Add(new Employee() { EmpNo = 126, EmpName = "Zishan", Salary = 36000 });
Console.WriteLine("The Original Data");
PrintData();
Console.WriteLine();

//Task taskTDS = Task.Factory.StartNew(() =>
//{
//    CalculateTax();
//});

Thread t1 = new Thread(CalculateTax);
t1.Start();
t1.Join();
Thread t2 = new Thread(UpdateSalary);
t2.Start();
t2.Join();


//PrintData();
Console.WriteLine();

//Task taskUpdateSalary = Task.Factory.StartNew(() =>
//{
//    UpdateSalary();
//});
//PrintData();


Task.WaitAll();

Console.ReadLine();

void CalculateTax()
{
    (from record in Employees
     select record).ToList().
  ForEach(emp => emp.TDS = Convert.ToDecimal(emp.Salary * 0.1));
    Console.WriteLine("Employees After Calculating Tax");
    PrintData();
}

void UpdateSalary()
{
    (from record in Employees
     select record).ToList().
   ForEach(emp => emp.Salary = emp.Salary * 2);
    Console.WriteLine("Employees After Updating Salary");
    PrintData();
}

void PrintData()
{
    foreach (var record in Employees)
    {
        Console.WriteLine($"{record.EmpNo} {record.EmpName} {record.Salary} {record.TDS}");
    }
}
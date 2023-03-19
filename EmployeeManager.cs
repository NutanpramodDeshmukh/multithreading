using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll_Services
{
    internal class EmployeeManager
    {
        private readonly SqlRepository repo;
        public EmployeeManager(SqlRepository repo)
        {
            this.repo = repo;
        }
        public void GetEmployees()
        {
            var employees = repo.GetEmployees();
            if (employees.Count <= 0)
            {
                Console.WriteLine($"list is empty");
            }
            else
            {
                foreach (var item in employees)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void UpdateSalary()
        {
            Task thread =
            Console.WriteLine("Enter the Employee Name:");
            string name = (Console.ReadLine());
            Console.WriteLine("Enter update Salary");
            int s = int.Parse(Console.ReadLine());
            var flag = repo.UpdateEmployeeSalary(name, s);
            if (flag)
            {
                Console.WriteLine("Employee Salary Update Successfully..");
            }
            else
            {
                Console.WriteLine("Failed While Updating Employee Salary");
            }
        }
        public void GetEmpolyeebyDate()
        {
            Console.WriteLine("Enter the Range of Date(YYYY-MM-DD):");
            Console.WriteLine("Enter the start date");
            var r1 = Console.ReadLine();
            Console.WriteLine("Enter the end date");
            var r2 = Console.ReadLine();
            var employees = repo.GetEmpolyeeByDataRange(r1, r2);
            if (employees.Count <= 0)
            {
                Console.WriteLine($"list is empty");
            }
            else
            {
                foreach (var item in employees)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void GetTotalSalaryByGender()
        {
            Console.WriteLine("Enter M for Male or F for Female");
            var g = Console.ReadLine();
            var employees = repo.GetTotalSalarybygender(g);
            if (employees.Count <= 0)
            {
                Console.WriteLine($"list is empty");
            }
            else
            {
                foreach (var item in employees)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void InsertData()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Employee employee = new Employee();
            Console.Write("Enter Name: ");
            employee.EmployeeName = Console.ReadLine();
            Console.Write("Enter Salary: ");
            employee.Salary = int.Parse(Console.ReadLine());
            Console.Write("Enter Date: ");
            employee.Date = Console.ReadLine();
            Console.Write("Enter Gender: ");
            employee.Gender = Console.ReadLine();

            var flag = repo.InsertEmployee(employee);
            if (flag)
            {
                Console.WriteLine("Employee Created Successfully..");
            }
            else
            {
                Console.WriteLine("Failed While Adding Employee");
            }
            stopwatch.Stop();
            Console.WriteLine("Time Taken for Execution Without thread: " + stopwatch.ElapsedMilliseconds + "ms");


            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task thread = new Task(() =>
            {
                Employee employee = new Employee();
                Console.Write("Enter Name: ");
                employee.EmployeeName = Console.ReadLine();
                Console.Write("Enter Salary: ");
                employee.Salary = int.Parse(Console.ReadLine());
                Console.Write("Enter Date: ");
                employee.Date = Console.ReadLine();
                Console.Write("Enter Gender: ");
                employee.Gender = Console.ReadLine();

                var flag = repo.InsertEmployee(employee);
                if (flag)
                {
                    Console.WriteLine("Employee Created Successfully..");
                }
                else
                {
                    Console.WriteLine("Failed While Adding Employee");
                }
            });
            thread.Start();
            thread.Wait();
            sw.Stop();
            Console.WriteLine("Time Taken for Execution With thread: " + sw.ElapsedMilliseconds + "ms");
        }
        public void Delete()
        {
            Console.Write("Enter the Employee Id to delete:");
            int id = int.Parse(Console.ReadLine());
            var flag = repo.DeleteEmployeeById(id);
            if (flag)
            {
                Console.WriteLine("Employee deleted Successfully..");
            }
            else
            {
                Console.WriteLine("Failed While Adding Employee");
            }
        }
    }
}
}

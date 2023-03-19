using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll_Services
{
    internal class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter 1 to get all Employees\nEnter 2 to update salary\nEnter 3 to get data in range\nEnter 4 to get Total Salary by gender\nEnter 5 to insert new Employee data\nEnter 6 to delete Employee data ");
                int input = int.Parse(Console.ReadLine());
                EmployeeManager manager = new EmployeeManager(new SqlRepository());
                switch (input)
                {
                    case 1: manager.GetEmployees(); break;
                    case 2: manager.UpdateSalary(); break;
                    case 3: manager.GetEmpolyeebyDate(); break;
                    case 4: manager.GetTotalSalaryByGender(); break;
                    case 5: manager.InsertData(); break;
                    case 6: manager.Delete(); break;
                    default: Console.WriteLine("Invalid Entry"); break;
                }
            }
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
        public string Date { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            var st = $"ID: {Id}\nName: {EmployeeName}\nSalary: {Salary}\nDate: {Date}\nGender: {Gender}  \n-----------------\n";
            return st;
        }
    }
}


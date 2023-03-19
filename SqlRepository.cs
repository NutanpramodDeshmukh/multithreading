using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll_Services
{
    internal class SqlRepository
    {
        string ConnectionString = @"Data Source=.;Initial Catalog=payroll_service;Integrated Security=True;";
        public List<Employee> GetEmployees()
        {
            string SQL = "select * from empolyee_payroll";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                var employee = new Employee();
                employee.Id = reader.GetInt32(0);
                employee.EmployeeName = reader.GetString(1);
                employee.Salary = reader.GetInt32(2);
                employee.Date = reader.GetDateTime(3).ToString();
                employee.Gender = reader.GetString(4);
                employees.Add(employee);
            }
            connection.Close();
            return employees;
        }
        public bool UpdateEmployeeSalary(string name, int salary)
        {
            var Sql = @$"update empolyee_Payroll set Salary={salary} where name='{name}'";

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Sql, con);
            con.Open();
            int output = sqlCommand.ExecuteNonQuery();
            con.Close();
            return output > 0;
        }
        public List<Employee> GetEmpolyeeByDataRange(string r1, string r2)
        {
            var Sql = @$"SELECT * FROM empolyee_payroll WHERE start BETWEEN CAST('{r1}'AS DATE) AND CAST('{r2}' AS DATE)";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(Sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                var employee = new Employee();
                employee.Id = reader.GetInt32(0);
                employee.EmployeeName = reader.GetString(1);
                employee.Salary = reader.GetInt32(2);
                employee.Date = reader.GetDateTime(3).ToString();
                employee.Gender = reader.GetString(4);
                employees.Add(employee);
            }
            connection.Close();
            return employees;
        }
        public List<Employee> GetTotalSalarybygender(string g)
        {
            var Sql = @$"SELECT SUM(salary) AS Total_Empolyee_Salary FROM empolyee_payroll WHERE gender='M' GROUP BY gender";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(Sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                var employee = new Employee();
                employee.Id = reader.GetInt32(0);
                employee.EmployeeName = reader.GetString(1);
                employee.Salary = reader.GetInt32(2);
                employee.Date = reader.GetDateTime(3).ToString();
                employee.Gender = reader.GetString(4);
                employees.Add(employee);
            }
            connection.Close();
            return employees;
        }
        public bool InsertEmployee(Employee employee)
        {
            var Sql = @$"insert into empolyee_payroll (name,salary,start,gender) values('{employee.EmployeeName}',{employee.Salary}, '{employee.Date}','{employee.Gender}')";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Sql, con);
            con.Open();
            int output = sqlCommand.ExecuteNonQuery();
            con.Close();
            return output > 0;
        }

        public bool DeleteEmployeeById(int employeeId)
        {
            var Sql = @$"delete from empolyee where id = {employeeId}";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Sql, con);
            con.Open();
            int output = sqlCommand.ExecuteNonQuery();
            con.Close();
            return output > 0;
        }
    }
}
}

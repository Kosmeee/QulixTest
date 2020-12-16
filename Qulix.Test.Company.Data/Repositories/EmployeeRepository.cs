using Qulix.Test.Company.Data.Context;
using Qulix.Test.Company.Domain.Models;
using Qulix.Test.Company.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Qulix.Test.Company.Data.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        private readonly ICompanyDbContext companyDbContext;
        private readonly SqlConnection connection;

        public EmployeeRepository(ICompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
            connection = companyDbContext.GetConnection();
        }

        public void Add(Employee employee)
        {
            connection.Open();
            string sqlExp = $"Insert into Employees(FirstName,LastName,Patronymic,EmploymentDate,CompanyId,PositionId) Values('{employee.FirstName}','{employee.LastName}','{employee.Patronymic}',@dt,'{employee.Company.Id}',{employee.Position.Id})";
            SqlCommand command = new SqlCommand(sqlExp, connection);
            command.Parameters.Add("dt", SqlDbType.DateTime);
            command.Parameters["dt"].Value = employee.EmploymentDate;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            string sqlExp = $"Delete from Employees WHERE Id={id}";
            SqlCommand command = new SqlCommand(sqlExp, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Edit(Employee employee)
        {
            connection.Open();
            string sqlExp = $"Update Employees SET FirstName='{employee.FirstName}', LastName = '{employee.LastName}',EmploymentDate=@dt, Patronymic = '{employee.Patronymic}',CompanyId = '{employee.Company.Id}',PositionId = '{employee.Position.Id}' WHERE Id={employee.Id}";
            SqlCommand command = new SqlCommand(sqlExp, connection);
            command.Parameters.Add("dt", SqlDbType.DateTime);
            command.Parameters["dt"].Value = employee.EmploymentDate;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Employee Get(int id)
        {
            connection.Open();
            var Employees = new List<Employee>();
            string sqlExp = $"Select Employees.Id, Employees.FirstName,Employees.LastName,Employees.Patronymic,Employees.EmploymentDate,Companies.Id, Companies.Title, Companies.OrganisationalForm,Positions.Id, Positions.Title FROM Employees Left JOIN Companies on Employees.CompanyId=Companies.Id LEFT JOIN Positions on Employees.PositionId=Positions.Id  WHERE Employees.Id={ id}";
            SqlCommand command = new SqlCommand(sqlExp, connection);

            var reader = command.ExecuteReader();
            reader.Read();
            var employee = new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Patronymic = reader.GetString(3) ?? "",
                    EmploymentDate = reader.GetDateTime(4),
                    Company = new Domain.Models.Company { Id = reader.GetInt32(5), Title = reader.GetString(6), OrganisationalForm = reader.GetString(7) },
                    Position = new Position { Id = reader.GetInt32(8), Title = reader.GetString(9) },
                };
            reader.Close();
            connection.Close();
            return employee;
        }

        public List<Employee> GetAll()
        {
            connection.Open();
            var Employees = new List<Employee>();
            string sqlExp = "Select Employees.Id, Employees.FirstName,Employees.LastName,Employees.Patronymic,Employees.EmploymentDate,Companies.Id, Companies.Title, Companies.OrganisationalForm,Positions.Id, Positions.Title FROM Employees Left JOIN Companies on Employees.CompanyId=Companies.Id LEFT JOIN Positions on Employees.PositionId=Positions.Id";
            SqlCommand command = new SqlCommand(sqlExp, connection);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {

                Employees.Add(
                    new Employee
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Patronymic = reader.GetString(3) ?? "",
                        EmploymentDate = reader.GetDateTime(4),
                        Company = new Domain.Models.Company { Id = reader.GetInt32(5), Title = reader.GetString(6), OrganisationalForm = reader.GetString(7) },
                        Position = new Position { Id = reader.GetInt32(8), Title = reader.GetString(9) },
                    });
            }
            reader.Close();
            connection.Close();
            return Employees;
        }
    }
}

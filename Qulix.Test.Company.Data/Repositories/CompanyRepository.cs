using Qulix.Test.Company.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Qulix.Test.Company.Domain.Repositories;

namespace Qulix.Test.Company.Data.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        private readonly ICompanyDbContext companyDbContext;
        private readonly SqlConnection connection;

        public CompanyRepository(ICompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
            connection = companyDbContext.GetConnection();
        }

        public List<Domain.Models.Company> GetAll()
        {
            connection.Open();
            var Companies = new List<Domain.Models.Company>();
            string sqlExp = "Select * FROM Companies";
            string sqlExpCount = "Select Count(CompanyId) FROM Employees WHERE CompanyId = @Id";
            SqlCommand command = new SqlCommand(sqlExp, connection);
            
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                command = new SqlCommand(sqlExpCount, connection);
                command.Parameters.Add("Id", SqlDbType.Int);
                command.Parameters["Id"].Value = reader.GetInt32(0);
                Companies.Add(
                    new Domain.Models.Company
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        OrganisationalForm = reader.GetString(2),
                        Size = (int)command.ExecuteScalar(),
                    });
            }

            reader.Close();
            connection.Close();


            return Companies;
        }

        public Domain.Models.Company Get(int id)
        {
            connection.Open();
            string sqlExp = $"Select * FROM Companies WHERE Id={id}";
            SqlCommand command = new SqlCommand(sqlExp, connection);
            var reader = command.ExecuteReader();
            reader.Read();
            var company = new Domain.Models.Company
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                OrganisationalForm = reader.GetString(2),
            };
            connection.Close();
            return company;
        }

        public void Edit(Domain.Models.Company company)
        {
            connection.Open();
            string sqlExp = $"Update Companies SET Title='{company.Title}', OrganisationalForm = '{company.OrganisationalForm}' WHERE Id={company.Id}";
            SqlCommand command = new SqlCommand(sqlExp, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Add(Domain.Models.Company company)
        {
            connection.Open();
            string sqlExp = $"Insert into Companies(Title, OrganisationalForm) Values('{company.Title}','{company.OrganisationalForm}')";
            SqlCommand command = new SqlCommand(sqlExp, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            string sqlExp = $"Delete from Employees WHERE CompanyId={id}";
            SqlCommand command = new SqlCommand(sqlExp, connection);
            command.ExecuteNonQuery();
            sqlExp = $"Delete from Companies WHERE Id={id}";
            command = new SqlCommand(sqlExp, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

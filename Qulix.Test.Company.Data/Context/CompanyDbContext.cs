using System.Data.SqlClient;

namespace Qulix.Test.Company.Data.Context
{
   public class CompanyDbContext : ICompanyDbContext
    {
      private readonly SqlConnection connection;
        private const string db = "Server =.; database=CompanyDb;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public CompanyDbContext()
        {
           connection = new SqlConnection(db);
        
        }

        public System.Data.SqlClient.SqlConnection GetConnection()
        {
            return connection;
        }
    }
}

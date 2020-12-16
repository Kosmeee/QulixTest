using System.Data.SqlClient;

namespace Qulix.Test.Company.Data.Context
{
   public interface ICompanyDbContext
    {
        System.Data.SqlClient.SqlConnection GetConnection(); // getting sql connection
    }
}

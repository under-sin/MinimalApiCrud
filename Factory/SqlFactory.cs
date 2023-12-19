using System.Data;
using Microsoft.Data.SqlClient;

namespace MinimalApiCrud.Factory;

public class SqlFactory
{
    public IDbConnection SqlConnection()
    {
        return new SqlConnection("Server=localhost; Database=master; User=sa; Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True");
    }
}

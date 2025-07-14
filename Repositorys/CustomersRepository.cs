using AspnetCoreMvcFull.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositorys
{
  public class CustomersRepository : ICustomersRepository
  {

    private string _ConnectionStrings; 
    public CustomersRepository(IConfiguration configuration)
    {
      _ConnectionStrings = configuration.GetConnectionString("DefulatConnectionstring");
      
    }


    public async Task<Customers> CreateProduct(Customers customers)
    {
      ;
      var prams = new DynamicParameters();

      prams.Add("@CustomerId", customers.CustomerId, DbType.Int32);
      prams.Add("@FirstName", customers.FirstName, DbType.String);
      prams.Add("@LastName", customers.LastName, DbType.String);
      prams.Add("@Email", customers.Email, DbType.String);
      prams.Add("@FullAddress", customers.FullAddress, DbType.String);

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Customers>("Sp_UpsertCustomer", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }
    }
    public async Task<List<Customers>> GetCustomersDetils()
    {
      List<Customers> customers = new List<Customers>();
      var prams = new DynamicParameters();

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryMultipleAsync("sp_GetCustomersAllDetils", prams, commandType: CommandType.StoredProcedure);

        customers.AddRange(res.Read<Customers>().ToList());

        return customers;
      }
    }
    public async Task<Customers> GetCustomersDetilsByCustomerId(int CustomerId)
    {
      Customers customers = new Customers();
      var prams = new DynamicParameters();

      prams.Add("@CustomerId", CustomerId, DbType.Int32);

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Customers>("sp_GetCustomersDetilsByCustomerId", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }
    }
    public async Task<Customers> DeletedCustomersByCustomerId(int CustomerId)
    {
      Customers customers = new Customers();
      var prams = new DynamicParameters();

      prams.Add("@CustomerId", CustomerId, DbType.Int32);

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Customers>("DeletedCustomersByCustomerId", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }

    }
  }
}

using AspnetCoreMvcFull.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositorys
{
  public class ProductRepository : IProductRepository
  {
    private string _ConnectionStrings;  
    public ProductRepository(IConfiguration configuration)
    {
      _ConnectionStrings = configuration.GetConnectionString("DefulatConnectionstring");
    }

    public async Task<Product> CreateProduct(Product product)
    {
      Product customers = new Product();
      var prams = new DynamicParameters();

      prams.Add("@ProductId", product.ProductId, DbType.Int32);
      prams.Add("@Title", product.Title, DbType.String);
      prams.Add("@Description", product.Description, DbType.String);
      prams.Add("@Amount", product.Amount, DbType.String);
      

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Product>("Sp_UpsertProduct", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }
    }
    public async Task<List<Product>> GetProductDetils()
    {
      List<Product> customers = new List<Product>();
      var prams = new DynamicParameters();

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryMultipleAsync("sp_GetProductDetils", prams, commandType: CommandType.StoredProcedure);

        customers.AddRange(res.Read<Product>().ToList());

        return customers;
      }
    }
    public async Task<Product> GetProductDetilsByProductId(int ProductId)
    {
      Product customers = new Product();
      var prams = new DynamicParameters();

      prams.Add("@ProductId", ProductId, DbType.Int32);

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Product>("Sp_GetProductDetilsByProductId", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }
    }
    public async Task<Product> DeletedProductByProductId(int ProductId)
    {
      Product customers = new Product();
      var prams = new DynamicParameters();

      prams.Add("@ProductId", ProductId, DbType.Int32);

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Product>("DeletedProductByProductId", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }

    }
  }
}

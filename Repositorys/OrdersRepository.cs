using AspnetCoreMvcFull.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AspnetCoreMvcFull.Repositorys
{
  public class OrdersRepository : IOrersRepository
  {
    private string _ConnectionStrings;

    public OrdersRepository(IConfiguration configuration)
    {
      _ConnectionStrings = configuration.GetConnectionString("DefulatConnectionstring");
    }

    public async Task<Orders> CreateOrders(Orders orders)
    {
      Orders customers = new Orders();
      var prams = new DynamicParameters();

      prams.Add("@OrderId", orders.OrderId, DbType.Int32);
      prams.Add("@CustomerId", orders.CustomerId, DbType.Int32);
      prams.Add("@Amount", orders.Amount, DbType.Decimal);
     


      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Orders>("Sp_UpsertOrders", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }

    }

    public async Task<Orders> DeleteOrderByOrderId(int id)
    {
      Orders customers = new Orders();
      var prams = new DynamicParameters();

      prams.Add("@OrderId", id, DbType.Int32);
     

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Orders>("Sp_DeleteOrderByOrderId", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }

    }


    public async Task<OrderDetails> SaveOrderDetail(int customerId, OrderDetails detail)
    {
      using (IDbConnection db = new SqlConnection(_ConnectionStrings))
      {
        var parameters = new DynamicParameters();
        parameters.Add("@OrderDetailsId", detail.OrderDetailsId);
        parameters.Add("@OrderId", detail.OrderId);
        parameters.Add("@CustomerId", customerId);
        parameters.Add("@ProductId", detail.ProductId);
        parameters.Add("@Quantity", detail.Quantity);
        parameters.Add("@Amount", detail.Amount);
        parameters.Add("@TaxAmount", detail.TaxAmount);
        parameters.Add("@DiscountAmount", detail.DiscountAmount);

        var res = await db.QueryAsync<OrderDetails>("Sp_InsertOrderDetails", parameters, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();
        return response;
      }
    }

   
    public async Task<Orders> GetOrderById(int id)
    {
      Orders customers = new Orders();
      var prams = new DynamicParameters();

      prams.Add("@OrderId", id, DbType.Int32);
     

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Orders>("Sp_GetOrderById", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }

    }
    public async Task<Orders> GetOrderByInvoiceNumber(string InvoiceNumber)
    {
      Orders customers = new Orders();
      var prams = new DynamicParameters();

      prams.Add("@InvoiceNumber", InvoiceNumber, DbType.String);
     

      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryAsync<Orders>("Sp_GetOrderByInvoiceNumber", prams, commandType: CommandType.StoredProcedure);

        var response = res.FirstOrDefault();

        return response;
      }

    }
    public async Task<List<OrderDetails>> GetAllOrdersAsync()
    {
      List<OrderDetails> response = new List<OrderDetails>();
      var prams = new DynamicParameters();

     
     


      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryMultipleAsync("Sp_GetAllOrders", prams, commandType: CommandType.StoredProcedure);

         response.AddRange(res.Read<OrderDetails>().ToList());

        return response;
      }

    }
    public async Task<string> GetInvoiceNumber(int OrderId)
    {


      var parameters = new DynamicParameters();
      parameters.Add("@OrderId", OrderId, DbType.Int32);
      parameters.Add("@NewInvoiceNumber", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        await _db.ExecuteAsync("sp_GenerateInvoiceNumber", parameters, commandType: CommandType.StoredProcedure);

        var invoiceNumber = parameters.Get<string>("@NewInvoiceNumber");
        return invoiceNumber;
      }
    }

    
    public async Task<List<OrderDetails>> OrderDetailsByOrderId(int orderId)
    {
      List<OrderDetails> response = new List<OrderDetails>();
      var prams = new DynamicParameters();
      prams.Add("@OrderId", orderId);
      using (IDbConnection _db = new SqlConnection(_ConnectionStrings))
      {
        var res = await _db.QueryMultipleAsync("sp_GetOrderDetails_ByOrderId", prams, commandType: CommandType.StoredProcedure);

         response.AddRange(res.Read<OrderDetails>().ToList());

        return response;
      }

    }
  }
}

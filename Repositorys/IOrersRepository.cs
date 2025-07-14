using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Repositorys
{
  public interface IOrersRepository
  {
    public Task<Orders> CreateOrders(Orders orders);
    public Task<Orders> DeleteOrderByOrderId(int id);
    public Task<Orders> GetOrderById(int id);
    public Task<Orders> GetOrderByInvoiceNumber(string InvoiceNumber);
    public Task<OrderDetails> SaveOrderDetail(int customerId, OrderDetails orderDetails);
    public Task<List<OrderDetails>> GetAllOrdersAsync();
    public Task<string> GetInvoiceNumber(int OrderId);
    public Task<List<OrderDetails>> OrderDetailsByOrderId(int orderId);

  }
}

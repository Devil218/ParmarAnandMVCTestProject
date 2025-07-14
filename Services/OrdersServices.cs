using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Repositorys;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace AspnetCoreMvcFull.Services
{
  public class OrdersServices : IOrdersServices
  {
    private readonly IOrersRepository _orersRepository;
    public OrdersServices(IOrersRepository orersRepository)
    {
      _orersRepository = orersRepository;
    }


    public async Task<Orders> CreateOrders(Orders orders)
    {
      return await _orersRepository.CreateOrders(orders);
    }
    public async Task<Orders> DeleteOrderByOrderId(int id)
    {
      return await _orersRepository.DeleteOrderByOrderId(id);
    }
    public async Task<Orders> GetOrderById(int id)
    {
      return await _orersRepository.GetOrderById(id);
    }
    public async Task<Orders> GetOrderByInvoiceNumber(string InvoiceNumber)
    {
      return await _orersRepository.GetOrderByInvoiceNumber(InvoiceNumber);
    }
    public async Task<OrderDetails> SaveOrderDetail(int customerId, OrderDetails orderDetails)
    {
      
       return await _orersRepository.SaveOrderDetail(customerId,orderDetails);
      
    }
    public async Task<List<OrderDetails>> GetAllOrdersAsync()
    {
      return await _orersRepository.GetAllOrdersAsync();
    }
    public async Task<string> GetInvoiceNumber(int orderId)
    {
      return await _orersRepository.GetInvoiceNumber(orderId);
    }

    public async Task<List<OrderDetails>> OrderDetailsByOrderId(int orderId)
    {
      return await _orersRepository.OrderDetailsByOrderId(orderId);
    }
  }
}

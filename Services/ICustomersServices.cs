using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Services
{
  public interface ICustomersServices
  {

  public Task<Customers>CreateProduct(Customers customers);
  public Task<List<Customers>> GetCustomersDetils();
  public Task<Customers> GetCustomersDetilsByCustomerId(int CustomerId);
  public Task<Customers> DeletedCustomersByCustomerId(int CustomerId);
  }
}

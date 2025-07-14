using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Repositorys
{
  public interface ICustomersRepository
  {

    public Task<Customers> CreateProduct(Customers customers);
    public Task<Customers> GetCustomersDetilsByCustomerId(int CustomerId);
    public Task<Customers> DeletedCustomersByCustomerId(int CustomerId);
    public Task<List<Customers>> GetCustomersDetils();

  }
}

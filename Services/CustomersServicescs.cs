using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Repositorys;

namespace AspnetCoreMvcFull.Services
{
  public class CustomersServicescs : ICustomersServices
  {
    private readonly ICustomersRepository _productRepository;
    public CustomersServicescs(ICustomersRepository productRepository)
    {
         _productRepository = productRepository;
    }

    public async Task<Customers>CreateProduct(Customers customers)
    {
      return await _productRepository.CreateProduct(customers);
    }
    public async Task<Customers> GetCustomersDetilsByCustomerId(int CustomerId)
    {
      return await _productRepository.GetCustomersDetilsByCustomerId(CustomerId);
    }
    public async Task<Customers> DeletedCustomersByCustomerId(int CustomerId)
    {
      return await _productRepository.DeletedCustomersByCustomerId(CustomerId);
    }
    public async Task<List<Customers>> GetCustomersDetils()
    {
      return await _productRepository.GetCustomersDetils();
    }


  }
}

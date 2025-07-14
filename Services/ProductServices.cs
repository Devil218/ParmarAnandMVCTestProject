using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Repositorys;
using Microsoft.CodeAnalysis;

namespace AspnetCoreMvcFull.Services
{
  public class ProductServices : IProductServices
  {
    private readonly IProductRepository _poroductRepository;
    public ProductServices(IProductRepository productRepository)
    {
      _poroductRepository = productRepository;  
    }

    public async Task<Product> CreateProduct(Product Product)
    {
      return await _poroductRepository.CreateProduct(Product);
    }
    public async Task<Product> GetProductDetilsByProductId(int ProductId)
    {
      return await _poroductRepository.GetProductDetilsByProductId(ProductId);
    }
    public async Task<Product> DeletedProductByProductId(int ProductId)
    {
      return await _poroductRepository.DeletedProductByProductId(ProductId);
    }
    public async Task<List<Product>> GetProductDetils()
    {
      return await _poroductRepository.GetProductDetils();
    }
  }
}

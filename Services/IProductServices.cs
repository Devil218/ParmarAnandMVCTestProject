using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Services
{
  public interface IProductServices
  {
    public Task<Product> CreateProduct(Product product);
    public Task<List<Product>> GetProductDetils();
    public Task<Product> GetProductDetilsByProductId(int ProductId);
    public Task<Product> DeletedProductByProductId(int ProductId);
  }
}

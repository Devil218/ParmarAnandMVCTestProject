using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Repositorys
{
  public interface IProductRepository
  {

    public Task<Product> CreateProduct(Product product);
    public Task<List<Product>> GetProductDetils();
    public Task<Product> GetProductDetilsByProductId(int CustomerId);
    public Task<Product> DeletedProductByProductId(int CustomerId);
  }


}

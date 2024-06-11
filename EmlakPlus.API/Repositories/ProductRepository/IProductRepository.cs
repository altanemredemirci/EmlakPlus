using EmlakPlus.Entity;

namespace EmlakPlus.API.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<ProductDetail> GetByIdAsync(int id);
        Task<int> CreateProductAsync(ProductDetail productDetail);
        Task<int> UpdateProductAsync(ProductDetail productDetail);
        Task<int> DeleteProductAsync(int id);
    }
}

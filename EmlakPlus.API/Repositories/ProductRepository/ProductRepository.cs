using EmlakPlus.API.Models.Context;
using EmlakPlus.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmlakPlus.API.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EstateContext _estateContext;

        public ProductRepository(EstateContext estateContext)
        {
            _estateContext = estateContext;
        }

        public async Task<int> CreateProductAsync(ProductDetail productDetail)
        {
            await _estateContext.ProductDetail.AddAsync(productDetail);

            return await _estateContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var model = _estateContext.Products.Find(id);
            _estateContext.Products.Remove(model);

            return await _estateContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _estateContext.Products.Include(i => i.ProductType).Include(i => i.City).Include(i => i.Agency).ToListAsync();
        }

        public async Task<ProductDetail> GetByIdAsync(int id)
        {
            var value = await _estateContext.ProductDetail.Where(i => i.ProductId == id).Include(i => i.Product).ThenInclude(i => i.ProductType).Include(i => i.Product.City).Include(i => i.Product.Agency).Include("Images").FirstOrDefaultAsync();
            return value;
        }

        public async Task<int> UpdateProductAsync(ProductDetail productDetail)
        {
            _estateContext.Entry(productDetail).State = EntityState.Modified;
            try
            {
                return await _estateContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailExists(productDetail.Id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ProductDetailExists(int id)
        {
            return _estateContext.ProductDetail.Any(e => e.Id == id);
        }
    }
}

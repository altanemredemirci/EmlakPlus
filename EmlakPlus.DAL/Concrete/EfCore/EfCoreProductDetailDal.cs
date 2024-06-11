using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Concrete.EfCore
{
    public class EfCoreProductDetailDal : EfCoreGenericRepository<ProductDetail, DataContext>, IProductDetailDal
    {
        public override List<ProductDetail> GetAll(Expression<Func<ProductDetail, bool>> filter)
        {
            using (var context = new DataContext())
            {
                var products = context.ProductDetail.Include(i => i.Product).ThenInclude(i => i.ProductType).Include(i => i.Product.City).Include(i => i.Product.Agency).Include("Images").AsQueryable();

                return filter != null
                    ? products.Where(filter).ToList()
                    : products.ToList();
            }
        }

        public override ProductDetail GetById(int id)
        {
            using (var context = new DataContext())
            {
                var model = context.ProductDetail.Where(i => i.ProductId == id).Include(i => i.Product).ThenInclude(i => i.ProductType).Include(i => i.Product.City).Include(i => i.Product.Agency).Include("Images").FirstOrDefault();

                return model;
            }
        }

        public List<ProductDetail> Last5Product()
        {
            using (var context = new DataContext())
            {
                return context.ProductDetail.Include(i => i.Product).ThenInclude(i => i.ProductType).Include(i => i.Product.City).OrderByDescending(i => i.PublishDate).Take(5).ToList();
            }
        }

        public override async void Update(ProductDetail entity)
        {
            using (var context = new DataContext())
            {
                var product = context.Products.FirstOrDefault(i => i.Id == entity.ProductId);

                product.IsPopular = entity.Product.IsPopular;
                product.Address = entity.Product.Address;
                product.CoverImage = entity.Product.CoverImage;
                product.AgencyId = entity.Product.AgencyId;
                product.CityId = entity.Product.CityId;
                product.District = entity.Product.District;
                product.Type = entity.Product.Type;
                product.Price = entity.Product.Price;
                product.Title = entity.Product.Title;
                product.Status = entity.Product.Status;
                product.ProductTypeId = entity.Product.ProductTypeId;

                entity.Product = product;

                //await context.SaveChangesAsync();

                var images = context.Images.Where(i => i.ProductDetailId == entity.Id).ToList();

                context.Images.RemoveRange(images);
                context.Images.AddRange(entity.Images);
                //await context.SaveChangesAsync();


                //await context.SaveChangesAsync();

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

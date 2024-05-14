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
    public class EfCoreProductDal : EfCoreGenericRepository<Product, DataContext>, IProductDal
    {
        public override List<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            using (var context = new DataContext())
            {
                return context.Products.Where(i => i.Status == true).Include(i => i.ProductType).Include(i => i.City).Include(i=> i.Agency).ToList();
            }
        }


        public List<Product> GetPopularAll()
        {
            using (var context = new DataContext())
            {
                return  context.Products.Where(i => i.IsPopular==true && i.Status==true).Include(i=>i.ProductType).Include(i=>i.City).ToList();
            }
        }
    }
}

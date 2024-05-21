using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Concrete.EfCore
{
    public class EfCoreProductDetailDal : EfCoreGenericRepository<ProductDetail, DataContext>, IProductDetailDal
    {
        public override ProductDetail GetById(int id)
        {
            using(var context = new DataContext())
            {
                var model =  context.ProductDetail.Where(i => i.ProductId == id).Include(i => i.Product).ThenInclude(i=> i.ProductType).Include(i=> i.Product.City).Include(i=> i.Product.Agency).Include("Images").FirstOrDefault();

                return model;
            }
        }
    }
}

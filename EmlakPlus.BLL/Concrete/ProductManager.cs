using EmlakPlus.BLL.Abstract;
using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            return _productDal.GetAll(filter);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetOne(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetOne(filter);
        }

        public List<Product> GetPopularAll()
        {
            return _productDal.GetPopularAll();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}

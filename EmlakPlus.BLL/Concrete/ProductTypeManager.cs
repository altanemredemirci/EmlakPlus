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
    public class ProductTypeManager : IProductTypeService
    {
        private readonly IProductTypeDal _productTypeDal;

        public ProductTypeManager(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }

        public void Create(ProductType entity)
        {
            _productTypeDal.Create(entity);
        }

        public void Delete(ProductType entity)
        {
            _productTypeDal.Delete(entity);
        }

        public List<ProductType> GetAll(Expression<Func<ProductType, bool>> filter)
        {
            return _productTypeDal.GetAll(filter);
        }

        public ProductType GetById(int id)
        {
            return _productTypeDal.GetById(id);
        }

        public void Update(ProductType entity)
        {
            _productTypeDal.Update(entity);
        }
    }
}

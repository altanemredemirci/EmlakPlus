using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();
        Product GetById(int id);

        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);

    }
}

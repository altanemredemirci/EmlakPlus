using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Abstract
{
    public interface IRepositoryService<T> where T:class
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T GetOne(Expression<Func<T, bool>> filter = null);
        T GetById(int id);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

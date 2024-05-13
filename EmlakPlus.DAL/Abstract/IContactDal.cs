using EmlakPlus.DAL.Concrete.EfCore;
using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Abstract
{
    public interface IContactDal
    {
        Contact GetOne();
        void Update(Contact entity);
    }
}

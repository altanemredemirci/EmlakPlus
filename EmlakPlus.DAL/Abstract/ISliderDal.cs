using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Abstract
{
    public interface ISliderDal
    {
        List<Slider> GetAll(Expression<Func<Slider, bool>> filter);
        Slider GetOne(Expression<Func<Slider, bool>> filter);

        void Update(Slider entity);
    }
}

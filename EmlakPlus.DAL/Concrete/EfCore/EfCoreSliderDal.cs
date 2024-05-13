using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Concrete.EfCore
{
    public class EfCoreSliderDal : ISliderDal
    {   
        public Slider GetAll(Expression<Func<Slider, bool>> filter)
        {
            using (var context = new DataContext())
            {
                return context.Sliders.FirstOrDefault(filter);
            }
        }
    }
}

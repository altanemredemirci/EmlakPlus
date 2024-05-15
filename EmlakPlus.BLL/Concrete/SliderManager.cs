using EmlakPlus.BLL.Abstract;
using EmlakPlus.DAL.Abstract;
using EmlakPlus.DAL.Concrete.EfCore;
using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public Slider GetOne(Expression<Func<Slider, bool>> filter = null)
        {
            return _sliderDal.GetOne(filter);
        }

        public void Update(Slider entity)
        {
            _sliderDal.Update(entity);
        }

        List<Slider> ISliderService.GetAll(Expression<Func<Slider, bool>> filter=null)
        {
            return _sliderDal.GetAll(filter);
        }
    }
}

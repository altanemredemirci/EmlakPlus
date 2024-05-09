using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Concrete.EfCore
{
    public class EfCoreSliderDal : ISliderDal
    {
        private readonly DataContext db;

        public EfCoreSliderDal(DataContext db)
        {
            this.db = db;
        }

        public List<Slider> GetAll()
        {
            return db.Sliders.ToList();
        }
    }
}

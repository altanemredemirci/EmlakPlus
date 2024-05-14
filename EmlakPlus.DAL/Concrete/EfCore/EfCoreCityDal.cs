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
    public class EfCoreCityDal : ICityDal
    {
        public List<City> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Cities.Include(i => i.Districts).ToList();
            }
        }

        public List<District> GetDistrictsById(int id)
        {
            using (var context = new DataContext())
            {
                return context.Districts.Where(i=> i.CityId==id).ToList();
            }
        }
    }
}

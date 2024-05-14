using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Abstract
{
    public interface ICityDal
    {
        List<City> GetAll();
        List<District> GetDistrictsById(int id);
    }
}

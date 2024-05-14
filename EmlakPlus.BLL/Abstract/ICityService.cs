using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Abstract
{
    public interface ICityService
    {
        List<City> GetAll();

        List<District> GetDistrictsById(int id);
    }
}

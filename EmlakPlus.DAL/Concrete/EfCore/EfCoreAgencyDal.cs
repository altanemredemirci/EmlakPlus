using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Concrete.EfCore
{
    public class EfCoreAgencyDal :EfCoreGenericRepository<Agency, DataContext>, IAgencyDal
    {
       
    }
}

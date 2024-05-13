using EmlakPlus.BLL.Abstract;
using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Concrete
{
    public class AgencyManager : IAgencyService
    {
        private readonly IAgencyDal _agencyDal;

        public AgencyManager(IAgencyDal agencyDal)
        {
            _agencyDal = agencyDal;
        }

        public void Create(Agency entity)
        {
            _agencyDal.Create(entity);
        }

        public void Delete(Agency entity)
        {
            _agencyDal.Delete(entity);
        }

        public List<Agency> GetAll(Expression<Func<Agency, bool>> filter)
        {
            return _agencyDal.GetAll(filter);
        }

        public Agency GetById(int id)
        {
            return _agencyDal.GetById(id);
        }

        public void Update(Agency entity)
        {
            _agencyDal.Update(entity);
        }
    }
}

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
    public class WhoWeAreManager : IWhoWeAreService
    {
        private readonly IWhoWeAreDal _whoWeAreDal;

        public WhoWeAreManager(IWhoWeAreDal whoWeAreDal)
        {
            _whoWeAreDal = whoWeAreDal;
        }

        public WhoWeAre GetOne(Expression<Func<WhoWeAre, bool>> filter = null)
        {
            return _whoWeAreDal.GetOne(filter);
        }

        public void Update(WhoWeAre entity)
        {
            _whoWeAreDal.Update(entity);
        }
    }
}

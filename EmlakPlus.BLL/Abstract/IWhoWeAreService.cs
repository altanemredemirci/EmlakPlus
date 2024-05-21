using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Abstract
{
    public interface IWhoWeAreService
    {
        WhoWeAre GetOne(Expression<Func<WhoWeAre, bool>> filter = null);
        void Update(WhoWeAre entity);
    }
}

using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Concrete.EfCore
{
    public class EfCoreWhoWeAreDal : IWhoWeAreDal
    {
        public WhoWeAre GetOne(Expression<Func<WhoWeAre, bool>> filter)
        {
            using(var context = new DataContext())
            {

                return filter == null
                    ? context.WhoWeAres.Include(i => i.Employments).FirstOrDefault()
                    : context.WhoWeAres.Include(i => i.Employments).FirstOrDefault(filter);
            }
        }

        public void Update(WhoWeAre entity)
        {
            using (var context = new DataContext())
            {
                var employments = context.Employments.Where(i => i.WhoWeAreId == entity.Id).ToList();

                for (int i = 0; i < 3; i++)
                {
                    employments[i].Title = entity.Employments[i].Title;
                    employments[i].Status = entity.Employments[i].Status;
                }

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

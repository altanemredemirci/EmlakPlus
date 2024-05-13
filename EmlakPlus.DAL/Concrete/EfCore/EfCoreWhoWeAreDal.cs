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
    public class EfCoreWhoWeAreDal : IWhoWeAreDal
    {
        public WhoWeAre GetOne()
        {
            using(var context = new DataContext())
            {
                return context.WhoWeAres.Include(i=> i.Employments.Where(e=> e.Status==true)).FirstOrDefault();
            }
        }

        public void Update(WhoWeAre entity)
        {
            using (var context = new DataContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

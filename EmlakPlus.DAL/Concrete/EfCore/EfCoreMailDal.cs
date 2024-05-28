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
    public class EfCoreMailDal : IMailDal
    {
        public void Create(Mail entity)
        {
            using (var context = new DataContext())
            {
                context.Mails.Add(entity);
                context.SaveChanges();
            }
               
        }

        public List<Mail> GetAll(Expression<Func<Mail, bool>> filter = null)
        {
              using (var context = new DataContext())
                {
                    return filter == null
                        ? context.Mails.ToList()
                        : context.Mails.Where(filter).ToList();
                }
            
        }

        public Mail GetById(int id)
        {
            using (var context = new DataContext())
            {
                return context.Mails.Find(id);
            }
        }

        public List<Mail> GetLast4(Expression<Func<Mail, bool>> filter = null)
        {
            using (var context = new DataContext())
            {
                return filter == null
                    ? context.Mails.OrderByDescending(i=> i.SendDate).Take(4).ToList()
                    : context.Mails.Where(filter).OrderByDescending(i => i.SendDate).Take(4).ToList();
            }
        }

        public void Update(Mail entity)
        {
            using (var context = new DataContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

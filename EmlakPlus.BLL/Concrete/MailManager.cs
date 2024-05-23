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
    public class MailManager : IMailService
    {
        private readonly IMailDal _mailDal;

        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public void Create(Mail entity)
        {
            _mailDal.Create(entity);
        }

        public List<Mail> GetAll(Expression<Func<Mail, bool>> filter = null)
        {
            return _mailDal.GetAll(filter);
        }

        public Mail GetById(int id)
        {
            return _mailDal.GetById(id);
        }

        public void Update(Mail entity)
        {
            _mailDal.Update(entity);
        }
    }
}

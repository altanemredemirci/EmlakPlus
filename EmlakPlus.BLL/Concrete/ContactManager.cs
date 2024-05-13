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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public Contact GetOne()
        {
            return _contactDal.GetOne();
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}

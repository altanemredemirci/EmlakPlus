using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Abstract
{
    public interface IContactService
    {
        Contact GetOne();
        void Update(Contact entity);
    }
}

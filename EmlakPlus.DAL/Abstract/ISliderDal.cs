﻿using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Abstract
{
    public interface ISliderDal
    {
        Slider GetAll(Expression<Func<Slider, bool>> filter);
    }
}

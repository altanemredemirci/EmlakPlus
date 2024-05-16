using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Abstract
{
    public interface IStatisticDal
    {
        int ProductTypeCount();
        int ActiveProductTypeCount();
        int PassiveProductTypeCount();
        int ProductCount();
        int ApartmentCount();
        string TopAgencyByProductCount();
        string TopProductTypeByProductCount();
        decimal AvgProductBySale();
        decimal AvgProductByRent();
        string TopCityByProductCount();
        int DiffrentCityCount();
        decimal LastProductPrice();
        decimal TheMostExpensiveProduct();
        decimal CheapestProduct();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int ActiveAgencyCount();
    }
}

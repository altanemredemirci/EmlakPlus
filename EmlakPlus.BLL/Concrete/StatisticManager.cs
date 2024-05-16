using EmlakPlus.BLL.Abstract;
using EmlakPlus.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;

        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public int ActiveAgencyCount()
        {
            return _statisticDal.ActiveAgencyCount();
        }

        public int ActiveProductTypeCount()
        {
            return _statisticDal.ActiveProductTypeCount();
        }

        public decimal AvgProductByRent()
        {
            return _statisticDal.AvgProductByRent();
        }

        public decimal AvgProductBySale()
        {
            return _statisticDal.AvgProductBySale();
        }

        public decimal CheapestProduct()
        {
            return _statisticDal.CheapestProduct();
        }

        public int DiffrentCityCount()
        {
            return _statisticDal.DiffrentCityCount();
        }

        public decimal LastProductPrice()
        {
            return _statisticDal.LastProductPrice();
        }

        public string NewestBuildingYear()
        {
            return _statisticDal.NewestBuildingYear();
        }

        public string OldestBuildingYear()
        {
            return _statisticDal.OldestBuildingYear();
        }

        public int PassiveProductTypeCount()
        {
            return _statisticDal.PassiveProductTypeCount();
        }

        public int ProductCount()
        {
            return _statisticDal.ProductCount();
        }

        public int ProductTypeCount()
        {
            return _statisticDal.ProductTypeCount();
        }

        public decimal TheMostExpensiveProduct()
        {
            return _statisticDal.TheMostExpensiveProduct();
        }

        public string TopAgencyByProductCount()
        {
            return _statisticDal.TopAgencyByProductCount();
        }

        public string TopCityByProductCount()
        {
            return _statisticDal.TopCityByProductCount();
        }

        public string TopProductTypeByProductCount()
        {
            return _statisticDal.TopProductTypeByProductCount();
        }
    }
}

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
    public class EfCoreStatisticDal : IStatisticDal
    {
        public int ActiveAgencyCount()
        {
            using(var context = new DataContext())
            {
                return context.Agencies.Where(i => i.Status == true).Count();
            }
        }

        public int ActiveProductTypeCount()
        {
            using (var context = new DataContext())
            {
                return context.ProductTypes.Where(i => i.Status == true).Count();
            }
        }


        public int PassiveProductTypeCount()
        {
            using (var context = new DataContext())
            {
                return context.ProductTypes.Where(i => i.Status == false).Count();
            }
        }

        public int ApartmentCount()
        {
            using (var context = new DataContext())
            {
                return context.ProductTypes.Where(i => i.Name == "Daire").Include(i => i.Products).Count();
            }
        }

        public decimal AvgProductByRent()
        {
            using (var context = new DataContext())
            {
                return context.Products.Where(i=> i.Type=="Kiralık").Average(i => i.Price);
            }
        }

        public decimal AvgProductBySale()
        {
            using (var context = new DataContext())
            {
                return context.Products.Where(i => i.Type == "Satılık").Average(i => i.Price);
            }
        }

        public decimal CheapestProduct()
        {
            using (var context = new DataContext())
            {
                return context.Products.Min(i => i.Price);
            }
        }

        public int DiffrentCityCount()
        {
            using (var context = new DataContext())
            {
                return context.Products.Select(i => i.CityId).Distinct().Count();
            }
        }

        public decimal LastProductPrice()
        {
            using (var context = new DataContext())
            {
                return context.Products.OrderByDescending(i => i.Id).Select(i => i.Price).FirstOrDefault();
            }
        }

        public string NewestBuildingYear()
        {
            using (var context = new DataContext())
            {
                return context.ProductDetail.OrderByDescending(i => i.BuildYear).Select(i => i.BuildYear).FirstOrDefault();
            }
        }

        public string OldestBuildingYear()
        {
            using (var context = new DataContext())
            {
                return context.ProductDetail.OrderBy(i => i.BuildYear).Select(i => i.BuildYear).FirstOrDefault();
            }
        }

        public int ProductCount()
        {
            using (var context = new DataContext())
            {
                return context.Products.Count();
            }
        }

        public int ProductTypeCount()
        {
            using (var context = new DataContext())
            {
                return context.ProductTypes.Count();
            }
        }

        public decimal TheMostExpensiveProduct()
        {
            using (var context = new DataContext())
            {
                return context.Products.OrderByDescending(i => i.Price).Select(i => i.Price).FirstOrDefault();
            }
        }

        public string TopAgencyByProductCount()
        {
            using (var context = new DataContext())
            {
                return context.Products
                    .GroupBy(i => i.Agency.Name)
                    .Select(group => new { AgencyName = group.Key, ProductCount = group.Count() })
                    .OrderByDescending(x => x.ProductCount)
                    .FirstOrDefault().AgencyName;
            }
        }

        public string TopCityByProductCount()
        {
            using (var context = new DataContext())
            {
                return context.Products
                   .GroupBy(i => i.City.Name)
                   .Select(group => new { CityName = group.Key, ProductCount = group.Count() })
                   .OrderByDescending(x => x.ProductCount)
                   .FirstOrDefault().CityName;
            }
        }

        public string TopProductTypeByProductCount()
        {
            using (var context = new DataContext())
            {
                return context.Products
                  .GroupBy(i => i.ProductType.Name)
                  .Select(group => new { ProductTypeName = group.Key, ProductCount = group.Count() })
                  .OrderByDescending(x => x.ProductCount)
                  .FirstOrDefault().ProductTypeName;
            }
        }
    }
}

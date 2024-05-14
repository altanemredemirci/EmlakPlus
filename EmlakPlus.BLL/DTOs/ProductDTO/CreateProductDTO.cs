using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.DTOs.ProductDTO
{
    public class CreateProductDTO
    {
        [StringLength(100)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        [StringLength(200)]
        public string CoverImage { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        public bool Status { get; set; }

        public bool IsPopular { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.Entity
{
    public class City
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public List<District> Districts { get; set; }

        public List<Product> Products { get; set; }
    }
}

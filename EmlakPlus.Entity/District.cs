using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.Entity
{
    public class District
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.DTOs.AgencyDTO
{
    public class CreateAgencyDTO
    {
        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }

        [StringLength(200)]
        public string Facebook { get; set; }

        [StringLength(200)]
        public string Twitter { get; set; }

        [StringLength(200)]
        public string Instagram { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.DTOs.ClientDTO
{
    public class ResultClientDTO
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [StringLength(2000)]
        public string Comment { get; set; }
    }
}

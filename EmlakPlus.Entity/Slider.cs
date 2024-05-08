using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.Entity
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public string ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        [StringLength(30)]
        public string Page { get; set; }
    }
}

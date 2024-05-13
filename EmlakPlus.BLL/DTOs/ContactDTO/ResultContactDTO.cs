using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.DTOs.ContactDTO
{
    public class ResultContactDTO
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Text { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public string Location { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.DTOs.MailDTO
{
    public class UpdateMailDTO
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(500)]
        public string Message { get; set; }
        public bool Read { get; set; }
    }
}

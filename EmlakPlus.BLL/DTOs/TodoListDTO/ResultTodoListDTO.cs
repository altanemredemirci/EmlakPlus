using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.DTOs.TodoListDTO
{
    public class ResultTodoListDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]       
        public DateTime AddDate { get; set; }
    }
}

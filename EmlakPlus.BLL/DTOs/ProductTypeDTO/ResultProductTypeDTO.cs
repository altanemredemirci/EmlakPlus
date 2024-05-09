﻿using EmlakPlus.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.BLL.DTOs.ProductTypeDTO
{
    public class ResultProductTypeDTO
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Icon { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}

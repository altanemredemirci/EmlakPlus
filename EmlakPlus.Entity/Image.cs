using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmlakPlus.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }

        [JsonIgnore]
        public int ProductDetailId { get; set; }
        [JsonIgnore]
        public ProductDetail ProductDetail { get; set; }
    }
}

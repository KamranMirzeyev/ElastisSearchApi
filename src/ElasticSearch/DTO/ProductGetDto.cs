using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.DTO
{
    public class ProductGetDto
    {
        public long Id { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public string Photo { get; set; }

        public string Description { get; set; }
        public DateTime AddedAt { get; set; }

        public bool IsActive { get; set; }
    }
}

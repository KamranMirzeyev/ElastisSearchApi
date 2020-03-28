using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.DTO
{
    public class ProductEditDto
    {
        public long Id { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public IFormFile Photo { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}

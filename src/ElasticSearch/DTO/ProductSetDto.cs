using Microsoft.AspNetCore.Http;

namespace ElasticSearch.DTO
{
    public class ProductSetDto
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public IFormFile Photo { get; set; }

        public string Description { get; set; }

       
    }


}

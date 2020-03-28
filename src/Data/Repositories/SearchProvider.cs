using Core.Models;
using Core.Repositories;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SearchProvider : ISearchProvider
    {
        private readonly ElasticClient _elasticsearchClient;
        public SearchProvider()
        {
            var uri = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(uri).DefaultIndex("products");
            _elasticsearchClient = new ElasticClient(settings);
        }
        public bool CreateProduct(Product product)
        {
          bool result = ValidateIfIdIsAlreadyUsedForIndex(product.Id.ToString());
            if (result)
            {
                var index = _elasticsearchClient.Index(product, i => i.Index("products"));
                if (index.ApiCall.HttpStatusCode == 201)
                    return true;
            }
           
            return false;
        }

        public bool DeleteById(long id)
        {
            _elasticsearchClient.Delete<Product>(id,z=>z.Index("products"));
            return true;
        }

       
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var model = await _elasticsearchClient.SearchAsync<Product>(x => x.Index("products").MatchAll().Size(12));
            return model.Documents;
        }

        public bool UpdateProduct(Product product)
        {
            var index = _elasticsearchClient.Index(product, i => i.Index("products").Id(product.Id));
            return false;
        }

        private bool ValidateIfIdIsAlreadyUsedForIndex(string id)
        {
            
            var result = _elasticsearchClient.Search<Product>(x => x.Index("products").QueryOnQueryString("id:"+id));
            if (result.Documents.Count == 0)
                return true;
           
            return false;
        }

        public async Task<IEnumerable<Product>> GetProduct(long id)
        
        {
            var model = await _elasticsearchClient.SearchAsync<Product>(s => s.Index("products").QueryOnQueryString("id:"+id));
           
            return model.Documents;
        }
    }
}

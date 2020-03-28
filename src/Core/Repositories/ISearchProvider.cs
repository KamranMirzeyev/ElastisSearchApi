using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
   public interface ISearchProvider
    {
        bool CreateProduct(Product product);

        bool UpdateProduct(Product product);

        Task<IEnumerable<Product>> GetProducts();
        bool DeleteById(long id);
       
        Task<IEnumerable<Product>> GetProduct(long id);
    }
}

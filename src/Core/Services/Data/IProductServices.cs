using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IProductServices
    {
        Task<Product> Create(Product product);
        Task<Product> Edit (Product product);
        Task<bool> Delete(long id);

        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<Product>> GetById(long id);

    }
}
using Core;
using Core.Models;
using Core.Repositories;
using Core.Services.Data;
using Core.Services.Rest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ProductService :IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISearchProvider _searchProvider;
        public ProductService(IUnitOfWork unitOfWork,ISearchProvider searchProvider)
        {
            _unitOfWork=unitOfWork;
            _searchProvider = searchProvider;
        }

        public async Task<Product> Create(Product product)
        {
                      
            product.AddedAt = DateTime.UtcNow.AddHours(4);
            product.Status = true;
            product.IsActive = true;
            await  _unitOfWork.Product.AddAsync(product);
            await  _unitOfWork.CommitAsync();

            _searchProvider.CreateProduct(product);

            return product;
        }

        public async Task<bool> Delete(long id)
        {
           var product= _unitOfWork.Product.FindId(id);
            if (product!=null)
            {
                _unitOfWork.Product.Remove(product);
                await _unitOfWork.CommitAsync();
                _searchProvider.DeleteById(id);
                return true;
            }
            return false;
        }

        public async Task<Product> Edit(Product product)
        {
           var model=  _unitOfWork.Product.FindId(product.Id);
            if (model!=null)
            {
                model.Description = product.Description;
                if (product.Photo!=null)
                    model.Photo = product.Photo;
                model.Quantity = product.Quantity;
                model.ProductName = product.ProductName;
                model.ModifiedAt = DateTime.UtcNow.AddHours(4);
                await _unitOfWork.CommitAsync();
                _searchProvider.UpdateProduct(product);
            }

            return  model;
        }

        public async Task<IEnumerable<Product>> GetById(long id) => await _searchProvider.GetProduct(id);


        public async Task<IEnumerable<Product>> GetProducts()
        {
          var model=  await _searchProvider.GetProducts();
            return model;
        }



    }


}
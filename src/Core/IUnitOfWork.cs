using System.Threading.Tasks;
using System;
using Core.Repositories;

namespace Core
{
       public interface IUnitOfWork
    {
        IProductRepository Product {get;}
        Task<int> CommitAsync();
    } 
}